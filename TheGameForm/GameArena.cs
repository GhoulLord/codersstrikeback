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
using TheGame;

namespace TheGameForm
{
    public partial class GameArena : UserControl
    {
        Graphics g;

        Vector origin = new Vector(0, 0);

        RaceState raceState = null;

        Race race { get { return raceState == null ? null : raceState.Race; } }

        double scaleFactor = 1;

        Font drawFont = new Font("Arial", 16);
        SolidBrush drawBrushFont = new SolidBrush(Color.Black);

        public GameArena()
        {
            InitializeComponent();

            DoubleBuffered = true;

            SizeChanged += GameArena_SizeChanged;
        }

        void GameArena_SizeChanged(object sender, EventArgs e)
        {
            CalculateScaleFactorAndOrigin();
            Refresh();
        }

        private void CalculateScaleFactorAndOrigin()
        {
            if (race == null) return;

            double scaleFactorX;
            double scaleFactorY;

            scaleFactorX = (double)this.Width / race.Arena.Width;
            scaleFactorY = (double)this.Height / race.Arena.Height;

            scaleFactor = Math.Min(scaleFactorX, scaleFactorY);

            double originX;
            double originY;

            originX = (this.Width - race.Arena.Width * scaleFactor) / 2;
            originY = (this.Height - race.Arena.Height * scaleFactor) / 2;

            origin = new Vector((int)originX, (int)originY);
        }

        public void SetRaceState(RaceState raceState)
        {
            this.raceState = raceState;

            CalculateScaleFactorAndOrigin();
        }

        public void DrawString(Vector p, string text)
        {
            float x1 = (float)(origin.X + p.X * scaleFactor);
            float y1 = (float)(origin.Y + p.Y * scaleFactor);

            g.DrawString(text, drawFont, drawBrushFont, x1, y1);
        }

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
            DrawVector(new Vector(0, 0), v, g, p);
        }

        protected void DrawVector(Vector o, Vector v, Graphics g, Pen p)
        {
            float x1 = (float)(origin.X + o.X * scaleFactor);
            float y1 = (float)(origin.Y + o.Y * scaleFactor);
            float x2 = (float)(origin.X + (o.X + v.X) * scaleFactor);
            float y2 = (float)(origin.Y + (o.Y + v.Y) * scaleFactor);

            g.DrawLine(p, x1, y1, x2, y2);
        }

        protected void DrawCircle(Vector o, double r, Graphics g, Pen p)
        {
            float x = (float)(origin.X + o.X * scaleFactor);
            float y = (float)(origin.Y + o.Y * scaleFactor);

            g.DrawEllipse(p, new Rectangle((int)(x - r * scaleFactor), (int)(y - r * scaleFactor), (int)(r * 2 * scaleFactor), (int)(r * 2 * scaleFactor)));
        }

        protected void PaintPodRacer(Graphics g, PodRacer podRacer)
        {
            Pen p = new Pen(podRacer.Owner.Color, 1);

            AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
            p.CustomEndCap = bigArrow;

            DrawCircle(podRacer.Position, podRacer.Size, g, p);

            if (podRacer.Velocity.LengthSquared > 0)
            {
                p.Color = Color.Blue;
                //DrawVector(podRacer.Position, podRacer.Velocity.CreateNormalizedVector() * 1600, p);
                DrawVector(podRacer.Position, podRacer.Velocity, p);
            }

            p.Color = Color.Red;
            DrawVector(podRacer.Position, podRacer.Orientation * 1200, p);

            p.Color = Color.Black;
            DrawString(podRacer.Position, podRacer.Number.ToString());
        }

        private void PaintPodRacerRaceState(Graphics g, PodRacerRaceState podRacerRaceState)
        {
            PaintPodRacer(g, podRacerRaceState.PodRacer);

            if (podRacerRaceState.CurrentCommand != null)
            {
                PaintDestination(g, podRacerRaceState.PodRacer, podRacerRaceState.CurrentCommand.Destination);
            }
        }

        protected void PaintCheckPoint(Graphics g, CheckPoint checkPoint)
        {
            Pen p = new Pen(Color.Black, 1);

            DrawCircle(checkPoint.Position, checkPoint.Size, g, p);

            p.Color = Color.Red;

            DrawString(checkPoint.Position, checkPoint.Number.ToString());
        }

        protected void PaintDestination(Graphics g, PodRacer podRacer, Vector destination)
        {
            Pen p = new Pen(Color.Green, 1);

            DrawVector(podRacer.Position, destination - podRacer.Position, p);
        }

        protected void PaintGameState(Graphics g)
        {
            if (raceState == null) return;

            this.g = g;

            //DrawString(new Vector(0, 0), string.Format("Round:{0,4}({1,8:0.000})", gs.Round, gs.Time));

            foreach (var podRacerRaceState in raceState.PodRacerRaceStates.Values)
            {
                PaintPodRacerRaceState(g, podRacerRaceState);
            }

            foreach (var checkPoint in race.Arena.CheckPoints)
            {
                PaintCheckPoint(g, checkPoint);
            }

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            PaintGameState(pe.Graphics);

        }
    }
}
