using System.Drawing;
using System.Diagnostics;
namespace Singularity.Core
{
    public class SpriteRenderer : Component
    {
        public Image texture = Properties.Resources.defaultTexture;

        public override void Start()
        {
            
        }

        public override void Update()
        {
            
        }

        public override void Draw(Graphics g)
        {
            Vector2 s = GameSettings.screenSize;
            Vector2 pos = gameObject.transform.position;
            Vector2 scale = gameObject.transform.scale;
            Vector2 center = new Vector2((float)texture.Width / 2, (float)texture.Height / 2);
            Vector2 screenCenter = GameSettings.screenSize / 2;
            float ratio = (float)texture.Width / (float)texture.Height;
            float sizex = (scale.x) * (s.y / Camera.orthographicSize) * ratio * ((float)texture.Height / GameSettings.pixelToUnits);
            float sizey = (scale.y) * (s.y / Camera.orthographicSize) * ((float)texture.Height / GameSettings.pixelToUnits);
            float posx = ((pos.x + screenCenter.x) - (sizex/2) + (pos.x * (s.y/Camera.orthographicSize))) - (Camera.transform.position.x * (s.y/Camera.orthographicSize));
            float posy = ((pos.y + screenCenter.y) - (sizey/2) + (pos.y * (s.y/Camera.orthographicSize))) - (Camera.transform.position.y * (s.y/Camera.orthographicSize));
            g.DrawImage(texture, new Rectangle((int)posx, (int)posy, (int)sizex, (int)sizey));
        }
    }
}