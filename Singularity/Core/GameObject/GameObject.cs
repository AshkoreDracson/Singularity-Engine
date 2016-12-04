using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace Singularity.Core
{
    public class GameObject : IDisposable
    {
        // ALL GAMEOBJECTS
        private static List<GameObject> _gameObjects = new List<GameObject>();
        private List<Component> _components = new List<Component>();
        private Dictionary<string, object> _properties = new Dictionary<string, object>();

        public string name { get; set; }
        public float layer = 0.0f;
        public string guid { get; private set; }
        public Dictionary<string, object> properties
        {
            get
            {
                return _properties;
            }
        }
        public Transform2D transform
        {
            get
            {
                return GetComponent<Transform2D>();
            }
        }

        public GameObject(string name)
        {
            this.name = name;
            this.guid = Guid.NewGuid().ToString();
            this.AddComponent<Transform2D>();
            _gameObjects.Add(this);
        }

        public T AddComponent<T>() where T : Component, new()
        {
            T newComp = new T();
            newComp.gameObject = this;
            _components.Add(newComp);
            newComp.Start();
            return (T)newComp;
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (Component comp in _components)
            {
                if (comp is T)
                {
                    return (T)comp;
                }
            }
            return null;
        }

        public Component[] GetAllComponents()
        {
            return _components.ToArray();
        }

        public void RemoveComponent<T>() where T : Component
        {
            foreach (Component comp in _components)
            {
                if (comp.GetType() == typeof(T))
                {
                    _components.Remove(comp);
                }
            }
        }

        // STATIC METHODS & FUNCTIONS

        public enum SortMode
        {
            Layer
        }

        public static GameObject[] GetAllGameObjects()
        {
            return _gameObjects.ToArray();
        }

        public static T[] GetAllComponentsByType<T>() where T : Component
        {
            List<T> components = new List<T>();
            GameObject[] gameObjects = GameObject.GetAllGameObjects();
            foreach (GameObject go in gameObjects)
            {
                foreach (Component comp in go.GetAllComponents())
                {
                    if (comp is T)
                    {
                        components.Add((T)comp);
                    }
                }
            }
            return components.ToArray();
        }

        public static GameObject[] SortGameObjects(GameObject[] gameObjects, SortMode sortmode = SortMode.Layer)
        {
            Dictionary<GameObject, float> layers = new Dictionary<GameObject, float>();
            foreach (GameObject go in gameObjects)
            {
                layers.Add(go, go.layer);
            }
            layers = layers.OrderBy(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            return layers.Keys.ToArray();
        }


        // Destruction & Dispose
        private bool isDisposed = false;
        public void Dispose(bool explicitCall)
        {
            if (!isDisposed)
            {
                if (explicitCall)
                {
                    // Dispose other shit
                    _gameObjects.Remove(this);
                    _components.Clear();
                    _properties.Clear();
                    _components = null;
                    _properties = null;
                }
                Debug.WriteLine("Cleaning up");
                isDisposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}