using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace Singularity.Core
{
    public class GameForm : Form
    {
        private Graphics _g;
        internal static List<Ray> raysToDraw = new List<Ray>();
        public string Title { get; set; }
        public Graphics Drawing
        {
            get
            {
                return _g;
            }
        }

        public GameForm(string title)
        {
            _g = this.CreateGraphics();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer,
                    true);
            this.Title = title;
            this.ClientSize = new Size((int)GameSettings.screenSize.x, (int)GameSettings.screenSize.y);
            this.Show();
        }

        internal void ShowRay(Ray r)
        {
            raysToDraw.Add(r);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.Text = Title;
            e.Graphics.Clear(GameSettings.BackColor);
            GameSettings.screenSize = new Vector2(this.ClientSize.Width, this.ClientSize.Height);
            e.Graphics.InterpolationMode = GameSettings.interpolationMode;
            e.Graphics.SmoothingMode = GameSettings.smoothingMode;
            GameCore.Draw(e.Graphics);
            foreach (Ray r in raysToDraw)
            {
                Vector2 s = GameSettings.screenSize;
                Vector2 screenCenter = GameSettings.screenSize / 2;
                float posx = ((r.Origin.x + screenCenter.x) + (r.Origin.x * (s.y / Camera.orthographicSize))) - (Camera.transform.position.x * (s.y / Camera.orthographicSize));
                float posy = ((r.Origin.y + screenCenter.y) + (r.Origin.y * (s.y / Camera.orthographicSize))) - (Camera.transform.position.y * (s.y / Camera.orthographicSize));
                float finalposx = ((r.Origin.x + r.Direction.x * 100 + screenCenter.x) + (r.Origin.x * (s.y / Camera.orthographicSize))) - (Camera.transform.position.x * (s.y / Camera.orthographicSize));
                float finalposy = ((r.Origin.y + r.Direction.y * 100 + screenCenter.y) + (r.Origin.y * (s.y / Camera.orthographicSize))) - (Camera.transform.position.y * (s.y / Camera.orthographicSize));
                e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Red)), (int)posx, (int)posy, (int)finalposx, (int)finalposy);
            }
            raysToDraw.Clear();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            int BorderWidth = (this.Width - this.ClientSize.Width);
            int TitlebarHeight = this.Height - this.ClientSize.Height - 2 * BorderWidth;
            Input.Input.MouseX = e.X;
            Input.Input.MouseY = e.Y;
            base.OnMouseMove(e);
        }
    }
}