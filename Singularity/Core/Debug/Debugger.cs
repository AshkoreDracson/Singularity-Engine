using Singularity;
using Singularity.Core;
using System.Drawing;

namespace Singularity.Core
{
    public static class EngineDebugger
    {
        public static void DrawPosition(Vector2 pos)
        {
            Color c = Color.Red;
        }
        public static void DrawPosition(Vector2 pos, Color c)
        {
            Graphics g = Game.Window.Drawing;
            Vector2 s = GameSettings.screenSize;
            Vector2 screenCenter = GameSettings.screenSize / 2;
            float posx = ((pos.x + screenCenter.x) + (pos.x * (s.y / Camera.orthographicSize))) - (Camera.transform.position.x * (s.y / Camera.orthographicSize));
            float posy = ((pos.y + screenCenter.y) + (pos.y * (s.y / Camera.orthographicSize))) - (Camera.transform.position.y * (s.y / Camera.orthographicSize));
            g.FillRectangle(new SolidBrush(c), new Rectangle((int)posx, (int)posy, 2, 2));
        }
    }
}