using Singularity.Core;
using System.Diagnostics;
namespace Singularity.Physics
{
    public class BoxCollider2D : Collider
    {
        public event OnCollidingHandler Colliding;
        public delegate void OnCollidingHandler(HitInfo info);

        public Vector2 Size { get; set; }
        private float left
        {
            get
            {
                return gameObject.transform.position.x - (Size.x / 2);
            }
        }
        private float right
        {
            get
            {
                return gameObject.transform.position.x + (Size.x / 2);
            }
        }
        private float up
        {
            get
            {
                return gameObject.transform.position.y - (Size.y / 2);
            }
        }
        private float down
        {
            get
            {
                return gameObject.transform.position.y + (Size.y / 2);
            }
        }

        public BoxCollider2D()
        {
            this.colliderType = ColliderType.BoxCollider;
            this.Size = Vector3.one;
        }

        public override void Update()
        {
            CheckForCollision();
        }

        internal bool IsColliding()
        {
            foreach (BoxCollider2D collider in GameObject.GetAllComponentsByType<BoxCollider2D>())
            {
                if (this != collider)
                {
                    bool isColliding = !(this.down < collider.up || this.up > collider.down || this.left > collider.right || this.right < collider.left);
                    if (isColliding)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void CheckForCollision()
        {
            foreach (BoxCollider2D collider in GameObject.GetAllComponentsByType<BoxCollider2D>())
            {
                if (this != collider)
                {
                    bool isColliding = !(this.down < collider.up || this.up > collider.down || this.left > collider.right || this.right < collider.left);
                    if (isColliding)
                    {
                        HitInfo h = new HitInfo() { other = collider, position = Vector2.zero };
                        if (Colliding != null)
                            Colliding(h);
                        
                        Debug.WriteLine(Time.time + h.other.gameObject.name);
                    }
                }
            }
        }
    }
}