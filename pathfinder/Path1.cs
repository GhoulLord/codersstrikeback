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
    public partial class Path1
    {
        Path path;

        public Path1(Path path)
        {
            this.path = path;
        }

        protected Vector CalculateB(Vector vectorP, Vector vectorM, double r)
        {
            Vector vectorC = vectorM - vectorP;
            Vector vectorB;
            Vector vectorR;

            float b = (float)Math.Sqrt(vectorC.LengthSquared - r * r);

            System.Windows.Media.Matrix m = new System.Windows.Media.Matrix(-r, -b, b, -r, 0, 0);

            vectorR = path.MatrixMultiplication(vectorC, m);
            vectorR = (r / vectorC.LengthSquared) * vectorR;

            vectorB = vectorM + vectorR - vectorP;

            return vectorB;
        }

        protected Vector CalculateT1M(Vector vectorT1, Vector vectorT2, double r)
        {
            Vector vectorT1M = new Vector();
            Vector vectorT1T2 = vectorT2 - vectorT1;

            vectorT1M.X = -vectorT1T2.Y / vectorT1T2.Length * r;
            vectorT1M.Y = vectorT1T2.X / vectorT1T2.Length * r;

            return -vectorT1M;
        }

        public void Paint()
        {
            Vector vectorP = new Vector(-250, 100);
            Vector vectorT1 = new Vector(0, 200);
            Vector vectorT2 = new Vector(200, 50);

            double r = 100;


            Vector vectorT1P = vectorP - vectorT1;
            Vector vectorT1T2 = vectorT2 - vectorT1;

            Vector vectorT1M;

            vectorT1M = CalculateT1M(vectorT1, vectorT2, r);

            Vector vectorM;

            vectorM = vectorT1 + vectorT1M;

            Pen p = new Pen(Color.Aqua, 1);

            AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
            p.CustomEndCap = bigArrow;

            p.Color = Color.White;
            path.DrawVector(vectorT1, p);
            path.DrawVector(vectorT2, p);
            p.Color = Color.Violet;
            path.DrawVector(vectorT1, vectorT1P, p);
            path.DrawVector(vectorT1, vectorT1T2, p);
            path.DrawVector(vectorM, p);
            path.DrawCircle(vectorM, r, p);
            p.Color = Color.Blue;
            path.DrawVector(vectorT1, vectorT1M, p);

            Vector vectorB;

            //vectorB = CalculateB(vectorP, vectorM, r);

            //p.Color = Color.Red;
            //DrawVector(vectorP, g, p);
            //p.Color = Color.Green;
            //DrawVector(vectorP, vectorB, g, p);

            //vectorP = new Vector(-350, 100);
            //vectorB = CalculateB(vectorP, vectorM, r);

            //p.Color = Color.Red;
            //DrawVector(vectorP, g, p);
            //p.Color = Color.Green;
            //DrawVector(vectorP, vectorB, g, p);

            vectorP = new Vector(0, -100);
            vectorB = CalculateB(vectorP, vectorM, r);

            p.Color = Color.Red;
            path.DrawVector(vectorP, p);
            p.Color = Color.Green;
            path.DrawVector(vectorP, vectorB, p);

            for (int i = 0; i < 15; i++)
            {
                vectorP = vectorP + 40 / vectorB.Length * vectorB;

                vectorB = CalculateB(vectorP, vectorM, r);

                p.Color = Color.Red;
                path.DrawVector(vectorP, p);
                p.Color = Color.Green;
                path.DrawVector(vectorP, vectorB, p);
            }

            //Vector vectorWH = vectorT1P + vectorT1T2;

            //Vector vectorR = -(r / vectorWH.Length) * vectorWH;

            //Vector vectorM = vectorT1 - vectorR;

            //Vector vectorC = vectorM - vectorP;

            //Vector vectorPR;

            //Vector vectorB = CalculateB(vectorP, vectorM, r);

            //float b = (float)Math.Sqrt(vectorC.LengthSquared - r * r);
            //System.Windows.Media.Matrix m = new System.Windows.Media.Matrix(-r, -b, b, -r, 0, 0);

            //vectorPR = MatrixMultiplication(vectorC, m);
            //vectorPR = (r / vectorC.LengthSquared) * vectorPR;


            //Pen p = new Pen(Color.Aqua, 1);

            //AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
            //p.CustomEndCap = bigArrow;

            //p.Color = Color.White;
            //DrawVector(vectorT1, g, p);
            //DrawVector(vectorT2, g, p);
            //p.Color = Color.Violet;
            //DrawVector(vectorT1, vectorT1P, g, p);
            //DrawVector(vectorT1, vectorT1T2, g, p);
            //DrawVector(vectorT1, vectorWH, g, p);

            //p.Color = Color.Yellow;
            //DrawVector(vectorM, g, p);
            //p.Color = Color.Red;
            //DrawVector(vectorP, g, p);

            //p.Color = Color.Black;
            //DrawVector(vectorP, vectorC, g, p);
            //p.Color = Color.Blue;
            //DrawVector(vectorM, vectorPR, g, p);
            //DrawCircle(vectorM, r, g, p);
            //p.Color = Color.Green;
            //DrawVector(vectorP, vectorB, g, p);

            //vectorP = new Vector(-350, 100);
            //vectorB = CalculateB(vectorP, vectorM, r);

            //p.Color = Color.Red;
            //DrawVector(vectorP, g, p);
            //p.Color = Color.Green;
            //DrawVector(vectorP, vectorB, g, p);

            //vectorP = new Vector(-150, 100);
            //vectorB = CalculateB(vectorP, vectorM, r);

            //p.Color = Color.Red;
            //DrawVector(vectorP, g, p);
            //p.Color = Color.Green;
            //DrawVector(vectorP, vectorB, g, p);

            //vectorP = new Vector(-150, 400);
            //vectorB = CalculateB(vectorP, vectorM, r);

            //p.Color = Color.Red;
            //DrawVector(vectorP, g, p);
            //p.Color = Color.Green;
            //DrawVector(vectorP, vectorB, g, p);
        }
    }


}
