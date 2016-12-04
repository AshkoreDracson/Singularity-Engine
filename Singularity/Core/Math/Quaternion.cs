namespace Singularity.Core
{
    public class Quaternion
    {
        public float w { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public Quaternion identity
        {
            get
            {
                return new Quaternion(0, 0, 0, 0);
            }
        }

        public Quaternion(float w, float x, float y, float z)
        {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}