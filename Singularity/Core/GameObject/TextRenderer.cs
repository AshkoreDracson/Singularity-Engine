using System;
using System.Drawing;

namespace Singularity.Core
{
    public class TextRenderer : Component
    {
        public Color foreColor { get; set; }
        public string font { get; set; }
        public string text { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int size { get; set; }

        public TextRenderer()
        {
            this.foreColor = Color.White;
            this.text = string.Empty;
            this.x = 0;
            this.y = 0;
            this.size = 16;
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            g.DrawString(text, new Font(font, size), new SolidBrush(foreColor), x, y);
        }
    }
}