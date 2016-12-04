using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
namespace Singularity.Core
{
    public static class GameCore
    {
        private static IEnumerable<Type> _scriptsType;
        private static List<object> _scripts = new List<object>();
        public static void Initialize(string formTitle = "Game")
        {
            Debug.WriteLine("Initializing");
            Game.Window = new GameForm(formTitle);

            // Manage assets

            Debug.WriteLine("Initialized");
            GameCore.Start();
        }

        private static void Start()
        {
            _scriptsType = FindSubClassesOf<ScriptBehaviour>();
            foreach (Type scriptType in _scriptsType)
            {
                object script = Activator.CreateInstance(scriptType);
                _scripts.Add(script);
                MethodInfo methodInfo = scriptType.GetMethod("Start");
                methodInfo.Invoke(script, null);
            }
            try
            {
                _scriptsType = FindSubClassesOf2<ScriptBehaviour>();
                foreach (Type scriptType in _scriptsType)
                {
                    object script = Activator.CreateInstance(scriptType);
                    _scripts.Add(script);
                    MethodInfo methodInfo = scriptType.GetMethod("Start");
                    methodInfo.Invoke(script, null);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            GameCore.Update();
        }

        private static void Update()
        {
            while (Game.Window.Visible)
            {
                float startTime = Time.time;
                
                if (Game.Window.Visible)
                {
                    foreach (object script in _scripts)
                    {
                        script.GetType().GetMethod("Update").Invoke(script, null);
                    }
                    UpdateGameObjects();
                }  

                Application.DoEvents();
                Game.Window.Invalidate();

                float endTime = Time.time;
                float realDeltaTime = endTime - startTime;
                Time.SetDT(realDeltaTime);

                if (GameSettings.targetFramerate > 0)
                {
                    int intDeltaTime = (int)(realDeltaTime * 1000);
                    int waitTime = (1000 / GameSettings.targetFramerate) - intDeltaTime;
                    if (waitTime > 0)
                        Thread.Sleep(waitTime);
                }
            }
        }

        public static void Draw(Graphics g)
        {
            GameObject[] gos = GameObject.GetAllGameObjects();
            gos = GameObject.SortGameObjects(gos);
            foreach (GameObject go in gos)
            {
                Component[] components = go.GetAllComponents();
                foreach (Component comp in components)
                {
                    comp.Draw(g);
                }
            }
            foreach (object script in _scripts)
            {
                try
                { script.GetType().GetMethod("Draw").Invoke(script, new object[] { g }); }
                finally {}
            }
        }

        private static void UpdateGameObjects()
        {
            GameObject[] gos = GameObject.GetAllGameObjects();
            foreach (GameObject go in gos)
            {
                Component[] components = go.GetAllComponents();
                foreach (Component comp in components)
                {
                    comp.Update();
                }
            }
        }

        private static IEnumerable<Type> FindSubClassesOf<TBaseType>()
        {
            var baseType = typeof(TBaseType);
            var assembly = baseType.Assembly;

            return assembly.GetTypes().Where(t => t.IsSubclassOf(baseType));
        }

        private static IEnumerable<Type> FindSubClassesOf2<TBaseType>()
        {
            var baseType = typeof(TBaseType);
            var assembly = Assembly.GetEntryAssembly();

            return assembly.GetTypes().Where(t => t.IsSubclassOf(baseType));
        }
    }
}