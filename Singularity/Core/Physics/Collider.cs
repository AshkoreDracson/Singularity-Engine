using Singularity.Core;
namespace Singularity.Physics
{
    public abstract class Collider : Component
    {
        internal enum ColliderType
        {
            BoxCollider,
            CircleCollider
        }
        internal ColliderType colliderType;
        public bool isKinematic = false;
    }
}