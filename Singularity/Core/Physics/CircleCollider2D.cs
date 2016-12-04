using Singularity.Core;
using System.Diagnostics;

namespace Singularity.Physics
{
    public class CircleCollider2D : Collider
    {
        public event OnCollidingHandler Colliding;
        public delegate void OnCollidingHandler(HitInfo info);

        public float Radius { get; set; }
        public CircleCollider2D()
        {
            this.colliderType = ColliderType.CircleCollider;
            this.Radius = 0.5f;
            this.Colliding += new OnCollidingHandler(OnColliding);
        }

        public override void Update()
        {
            if(!base.isKinematic)
            {
               CheckForCollision();
            }
        }

        internal bool IsColliding()
        {
            foreach (CircleCollider2D collider in GameObject.GetAllComponentsByType<CircleCollider2D>())
            {
                if (collider != this)
                {
                    float z = Vector2.Distance(collider.gameObject.transform.position, this.gameObject.transform.position);
                    if (collider.Radius + this.Radius > z)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal HitInfo GetHitInfo()
        {
            foreach (CircleCollider2D collider in GameObject.GetAllComponentsByType<CircleCollider2D>())
            {
                if (collider != this)
                {
                    float z = Vector2.Distance(collider.gameObject.transform.position, this.gameObject.transform.position);
                    if (collider.Radius + this.Radius > z)
                    {
                        return new HitInfo() { other = collider, position = Vector2.Lerp(this.gameObject.transform.position, collider.gameObject.transform.position, 0.5f) };
                    }
                }
            }
            return new HitInfo();
        }

        private void CheckForCollision()
        {
            foreach(CircleCollider2D collider in GameObject.GetAllComponentsByType<CircleCollider2D>())
            {
                if(collider != this)
                {
                    float z = Vector2.Distance(collider.gameObject.transform.position, this.gameObject.transform.position);
                    if(collider.Radius + this.Radius > z)
                    {
                        HitInfo h = new HitInfo() { other = collider, position = Vector2.Lerp(this.gameObject.transform.position, collider.gameObject.transform.position, 0.5f) };
                        if (Colliding != null)
                            Colliding(h);
                    }
                }
            }
        }

        public void OnColliding(HitInfo info)
        {

        }
    }
}