using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Media;

namespace pathfinder
{
    public partial class Path : UserControl
    {
        public Path()
        {
            InitializeComponent();
        }

        Vector v;

        Vector origin = new Vector();

        Graphics g;

        public void DrawVector(Vector v, Pen p)
        {
            DrawVector(v, g, p);
        }

        public void DrawVector(Vector o, Vector v, Pen p)
        {
            DrawVector(o, v, g, p);
        }

        public void DrawCircle(Vector o, double r, Pen p)
        {
            DrawCircle(o, r, g, p);
        }

        protected void DrawVector(Vector v, Graphics g, Pen p)
        {
            DrawVector(new Vector(), v, g, p);
        }

        protected void DrawVector(Vector o, Vector v, Graphics g, Pen p)
        {
            float x1 = (float)(origin.X + o.X);
            float y1 = (float)(origin.Y - o.Y);
            float x2 = (float)(origin.X + o.X + v.X);
            float y2 = (float)(origin.Y - (o.Y + v.Y));

            g.DrawLine(p, x1, y1, x2, y2);
        }

        protected void DrawCircle(Vector o, double r, Graphics g, Pen p)
        {
            float x = (float)(origin.X + o.X);
            float y = (float)(origin.Y - o.Y);

            g.DrawEllipse(p, new Rectangle((int)(x - r), (int)(y - r), (int)(r * 2), (int)(r * 2)));
        }

        public Vector MatrixMultiplication(Vector v, System.Windows.Media.Matrix m)
        {
            return new Vector(m.M11 * v.X + m.M12 * v.Y, m.M21 * v.X + m.M22 * v.Y);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            g = pe.Graphics;

            origin.X = this.Width / 2;
            origin.Y = this.Height / 2;

            Path2 p = new Path2(this);
            p.Paint();
        }
    }


}
