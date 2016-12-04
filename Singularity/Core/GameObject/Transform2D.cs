namespace Singularity.Core
{
    public class Transform2D : Component
    {
        private Vector2 _position = Vector2.zero;
        private Vector2 _eulerAngles = Vector2.zero;
        private Vector2 _scale = Vector2.one;

        public Vector2 position
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
        public Vector2 eulerAngles
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
        public Vector2 scale
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

        public void Translate(Vector2 a)
        {
            this._position += a;
        }
    }
}