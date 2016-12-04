using Singularity.Physics;
namespace Singularity.Core
{
    public class Ray
    {
        public Vector2 Origin { get; private set; }
        public Vector2 Direction { get; private set; }
        public Ray(Vector2 origin, Vector2 direction)
        {
            this.Origin = origin;
            this.Direction = direction;
        }

        public RayHitInfo Cast()
        {
            foreach (Collider c in GameObject.GetAllComponentsByType<Collider>())
            {

                switch (c.colliderType)
                {
                    case (Collider.ColliderType.BoxCollider):
                        BoxCollider2D boxCollider = (BoxCollider2D)c;

                        break;
                    case (Collider.ColliderType.CircleCollider):
                        CircleCollider2D circleCollider = (CircleCollider2D)c;
                        
                        // IT BEGINS

                        Vector2 o = Origin - circleCollider.gameObject.transform.position;
                        float det, b, r;
                        r = circleCollider.Radius;
                        b = -Vector2.Dot(o, Direction);
                        det = b * b - Vector2.Dot(o, o) + r*r;

                        if (det >= 0)
                        {
                            det = Mathf.Sqrt(det);
                            float distance = b + det;

                            Vector2 position = Origin + (Direction * distance);

                            RayHitInfo hit = new RayHitInfo();
                            hit.collider = circleCollider;
                            hit.distance = distance;
                            hit.position = position;

                            if (distance >= 0)
                                return hit; // annnnnnnd return it, still untested.
                        }

                        break;

                        // http://thingsiamdoing.com/intro-to-ray-tracing/ (Well explained stuff)
                        // http://www.ccs.neu.edu/home/fell/CSU540/programs/RayTracingFormulas.htm
                        // http://paulbourke.net/geometry/circlesphere/index.html#linesphere
                        // http://en.wikipedia.org/wiki/Line%E2%80%93sphere_intersection
                        // http://www.lighthouse3d.com/tutorials/maths/ray-sphere-intersection/
                        // http://stackoverflow.com/questions/481144/equation-for-testing-if-a-point-is-inside-a-circle
                }
            }
            return new RayHitInfo(); // return bascially nothing, check within the variable if it contains a collider to avoid errors.
        }

        public void Show()
        {
            Game.Window.ShowRay(this);
        }
    }

    public struct RayHitInfo
    {
        public Collider collider;
        public Vector2 position;
        public float distance;
    }
}