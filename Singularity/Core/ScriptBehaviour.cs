using Singularity.Core;
using System.Drawing;
namespace Singularity.Core
{
    public abstract class ScriptBehaviour
    {
        public virtual void Start() {}
        public virtual void Update() {}
        public virtual void Draw(System.Drawing.Graphics Drawing) {}

        public void print(object data)
        {
            System.Diagnostics.Debug.WriteLine(data);
            
        }

        public void Destroy(GameObject go)
        {
            //foreach (Component comp in go.GetAllComponents())
            //{
            //    comp.gameObject.RemoveComponent<
            //}
            go.Dispose();
        }
    }
}