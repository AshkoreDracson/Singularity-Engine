using System.Drawing;
using System.Drawing.Drawing2D;
using Singularity.Core;
namespace Singularity
{
    public static class GameSettings
    {
        public static Vector2 screenSize = new Vector2(1280, 720);
        public static int targetFramerate = 60;
        public static SmoothingMode smoothingMode = SmoothingMode.Default;
        public static InterpolationMode interpolationMode = InterpolationMode.NearestNeighbor;
        public static int pixelToUnits = 16;
        public static Color BackColor = Color.CornflowerBlue;
    }
}