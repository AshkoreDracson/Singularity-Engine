using Singularity;
using Singularity.Core;
using Singularity.Input;
namespace Singularity.Physics
{
    public class BodyBox : Component
    {
        public BoxCollider2D Collider
        {
            get
            {
                return gameObject.GetComponent<BoxCollider2D>();
            }
        }

        public BodyBox()
        {
            if (gameObject != null && Collider == null)
            {
                gameObject.AddComponent<BoxCollider2D>();
            }
        }

        public override void Start()
        {
            Collider.Colliding += new BoxCollider2D.OnCollidingHandler(OnColliding);
        }

        public override void Update()
        {

        }

        void OnColliding(HitInfo info)
        {
            while (Collider.IsColliding())
            {
                Vector2 dir = (this.gameObject.transform.position - info.other.gameObject.transform.position).normalized;
                this.gameObject.transform.Translate(dir * 0.005f);
            } 
        }
    }
}