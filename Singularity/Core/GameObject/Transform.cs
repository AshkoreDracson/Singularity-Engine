namespace Singularity.Core
{
    public class Transform : Component
    {
        private Vector3 _position = Vector3.zero;
        private Vector3 _eulerAngles = Vector3.zero;
        private Vector3 _scale = Vector3.one;

        public Vector3 position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }
        public Vector3 eulerAngles
        {
            get
            {
                return _eulerAngles;
            }
            set
            {
                _eulerAngles = value;
            }
        }
        public Vector3 scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
            }
        }

        public void Translate(Vector3 a)
        {
            this._position += a;
        }
    }
}