using System.Diagnostics;
namespace Singularity.Core
{
    public static class Time
    {
        private static Stopwatch sW = Stopwatch.StartNew();
        private static float _deltaTime = 0;

        public static float deltaTime
        {
            get
            {
                return _deltaTime;
            }
        }
        public static float time
        {
            get
            {
                return sW.ElapsedMilliseconds / 1000f;
            }
        }
        public static float fps
        {
            get
            {
                return 1 / Time.deltaTime;
            }
        }

        internal static void SetDT(float dt)
        {
            dt = Mathf.Clamp(dt, 1f / GameSettings.targetFramerate, float.MaxValue);
            _deltaTime = dt;
        }
    }
}