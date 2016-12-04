using System.Collections.Generic;
using Singularity.Core;
namespace Singularity.Physics
{
    public static class Physics
    {
        public static Collider[] OverlapPoint(Vector2 pos)
        {
            List<Collider> colliders = new List<Collider>();
            foreach (CircleCollider2D collider in GameObject.GetAllComponentsByType<CircleCollider2D>())
            {
                if (Vector2.Distance(pos, collider.gameObject.transform.position) < collider.Radius)
                {
                    colliders.Add(collider);
                }
            }
            return colliders.ToArray();
        }

        public static Collider[] OverlapCircle(Vector2 pos, float radius)
        {
            List<Collider> colliders = new List<Collider>();
            foreach (CircleCollider2D collider in GameObject.GetAllComponentsByType<CircleCollider2D>())
            {
                if (Vector2.Distance(pos, collider.gameObject.transform.position) < collider.Radius + radius)
                {
                    colliders.Add(collider);
                }
            }
            return colliders.ToArray();
        }
    }

    public struct HitInfo
    {
        public Collider other;
        public Vector2 position;
    }
}