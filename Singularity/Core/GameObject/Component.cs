using System.Diagnostics;
using System.Drawing;
namespace Singularity.Core
{
    public abstract class Component 
    {
        public GameObject gameObject { get; internal set; }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {
            
        }

        public virtual void Draw(Graphics g)
        {

        }
    }
}