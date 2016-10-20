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
    public partial class Path2
    {
        Path path;

        public Path2(Path path)
        {
            this.path = path;
        }

        protected Vector CalculateE2(Vector vectorT0, Vector vectorT1, Vector vectorT2, Vector vectorT3, Vector vectorT4, double r1, double r2, double r3)
        {
            
            System.Windows.Vector vectorM1;
            Vector vectorM2;
            Vector vectorM3;
            Vector vectorM1M2;
            Vector vectorM2M3;
            System.Windows.Media.Matrix m = new System.Windows.Media.Matrix();
            Vector vectorE = new Vector();

            vectorM1 = CalculateM2(vectorT1, vectorT0, vectorT2, r1);
            vectorM2 = CalculateM2(vectorT2, vectorT1, vectorT3, r2);
            vectorM3 = CalculateM2(vectorT3, vectorT2, vectorT4, r3);

            vectorM1M2 = (vectorT2 + vectorM2) - (vectorT1 + vectorM1);
            vectorM2M3 = (vectorT3 + vectorM3) - (vectorT2 + vectorM2);

            m.M11 = (r1 - r2) / vectorM1M2.Length;
            m.M12 = -Math.Sqrt(1 - ((r1 - r2) * (r1 - r2)) / vectorM1M2.LengthSquared);
            m.M21 = -m.M12;
            m.M22 = m.M11;

            vectorE = path.MatrixMultiplication(vectorM1M2, m);

            vectorE = (r2 / vectorE.Length) * vectorE;

            if ((vectorM1M2.X * vectorM2M3.Y - vectorM1M2.Y * vectorM2M3.X) > 0)
            {
                vectorE = -vectorE;
            }

            return vectorE;
        }

        protected Vector CalculateL2(Vector vectorT0, Vector vectorT1, Vector vectorT2, Vector vectorT3, Vector vectorT4, double r1, double r2, double r3)
        {
            Vector vectorM1;
            Vector vectorM2;
            Vector vectorM3;
            Vector vectorM1M2;
            Vector vectorM2M3;
            System.Windows.Media.Matrix m = new System.Windows.Media.Matrix();
            Vector vectorL = new Vector();

            vectorM1 = CalculateM2(vectorT1, vectorT0, vectorT2, r1);
            vectorM2 = CalculateM2(vectorT2, vectorT1, vectorT3, r2);
            vectorM3 = CalculateM2(vectorT3, vectorT2, vectorT4, r3);

            vectorM1M2 = (vectorT2 + vectorM2) - (vectorT1 + vectorM1);
            vectorM2M3 = (vectorT3 + vectorM3) - (vectorT2 + vectorM2);

            m.M11 = (r2 - r3) / vectorM2M3.Length;
            m.M12 = -Math.Sqrt(1 - ((r2 - r3) * (r2 - r3)) / vectorM2M3.LengthSquared);
            m.M21 = -m.M12;
            m.M22 = m.M11;

            vectorL = path.MatrixMultiplication(vectorM2M3, m);

            vectorL = (r2 / vectorL.Length) * vectorL;

            if ((vectorM1M2.X * vectorM2M3.Y - vectorM1M2.Y * vectorM2M3.X) > 0)
            {
                vectorL = -vectorL;
            }

            return vectorL;
        }

        protected Vector CalculateM2(Vector vectorT2, Vector vectorT1, Vector vectorT3, double r)
        {
            Vector vectorM;
            Vector vectorT2T1 = vectorT1 - vectorT2;
            Vector vectorT2T3 = vectorT3 - vectorT2;

            vectorM = vectorT2T1 + vectorT2T3;
            vectorM = (r / vectorM.Length) * vectorM;

            return vectorM;
        }

        public void Paint()
        {
            List<Vector> vectors = new List<Vector>()
            {
                new Vector(-200, 50),
                new Vector(300, 250),
                new Vector(150, -300),
                new Vector(150, 150)
            };

            List<double> radi = new List<double>()
            {
                50,
                50,
                50,
                20
            };

            List<Vector> vectorMs = new List<Vector>();
            List<Vector> vectorEs = new List<Vector>();
            List<Vector> vectorLs = new List<Vector>();

            Pen p = new Pen(Color.Aqua, 1);

            AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
            p.CustomEndCap = bigArrow;

            foreach (var vector in vectors)
            {
                int vectorIndex = vectors.IndexOf(vector);

                int vectorIndex0 = ((vectorIndex - 2) % vectors.Count + vectors.Count) % vectors.Count;
                int vectorIndex1 = ((vectorIndex - 1) % vectors.Count + vectors.Count) % vectors.Count;
                int vectorIndex3 = ((vectorIndex + 1) % vectors.Count + vectors.Count) % vectors.Count;
                int vectorIndex4 = ((vectorIndex + 2) % vectors.Count + vectors.Count) % vectors.Count;
                
                Vector vectorM;
                Vector vectorE;
                Vector vectorL;

                p.Color = Color.White;
                path.DrawVector(vector, p);

                vectorM = CalculateM2(vector, vectors[vectorIndex1], vectors[vectorIndex3], radi[vectorIndex]);

                p.Color = Color.Violet;
                path.DrawVector(vector, vectorM, p);

                vectorE = CalculateE2(vectors[vectorIndex0], vectors[vectorIndex1], vector, vectors[vectorIndex3], vectors[vectorIndex4], radi[vectorIndex1], radi[vectorIndex], radi[vectorIndex3]);
                vectorL = CalculateL2(vectors[vectorIndex0], vectors[vectorIndex1], vector, vectors[vectorIndex3], vectors[vectorIndex4], radi[vectorIndex1], radi[vectorIndex], radi[vectorIndex3]);

                p.Color = Color.Green;
                path.DrawVector(vector + vectorM, vectorE, p);
                p.Color = Color.Red;
                path.DrawVector(vector + vectorM, vectorL, p);

                vectorMs.Add(vector + vectorM);
                vectorEs.Add(vector + vectorM + vectorE);
                vectorLs.Add(vector + vectorM + vectorL);
            }

            for (int vectorIndex = 0; vectorIndex < vectors.Count; vectorIndex++)
            {
                p.Color = Color.Violet;
                path.DrawCircle(vectorMs[vectorIndex], radi[vectorIndex], p);
            }

            for (int vectorIndex = 0; vectorIndex < vectors.Count; vectorIndex++)
            {
                int nextVectorIndex = (vectorIndex + 1) % vectors.Count;

                p.Color = Color.Blue;
                path.DrawVector(vectorLs[vectorIndex], vectorEs[nextVectorIndex] - vectorLs[vectorIndex], p);
            }


            //vectorM1 = CalculateM2(vectorT1, vectorT2, vectorT3, r1);
            //vectorM2 = CalculateM2(vectorT2, vectorT3, vectorT1, r2);
            //vectorM3 = CalculateM2(vectorT3, vectorT1, vectorT2, r3);

            //vectorM1M2 = (vectorT2 + vectorM2) - (vectorT1 + vectorM1);
            //vectorM2M3 = (vectorT3 + vectorM3) - (vectorT2 + vectorM2);
            //vectorM3M1 = (vectorT1 + vectorM1) - (vectorT3 + vectorM3);

            //vectorE1 = CalculateE2(vectorT2, vectorT3, vectorT1, vectorT2, vectorT3, r3, r1, r2);
            //vectorL1 = CalculateL2(vectorT2, vectorT3, vectorT1, vectorT2, vectorT3, r3, r1, r2);

            //vectorE2 = CalculateE2(vectorT3, vectorT1, vectorT2, vectorT3, vectorT1, r1, r2, r3);
            //vectorL2 = CalculateL2(vectorT3, vectorT1, vectorT2, vectorT3, vectorT1, r1, r2, r3);

            //vectorE3 = CalculateE2(vectorT1, vectorT2, vectorT3, vectorT1, vectorT2, r2, r3, r1);
            //vectorL3 = CalculateL2(vectorT1, vectorT2, vectorT3, vectorT1, vectorT2, r2, r3, r1);

            //p.Color = Color.Violet;
            ////path.DrawVector(vectorT1, vectorM1, p);
            ////path.DrawVector(vectorT2, vectorM2, p);
            ////path.DrawVector(vectorT3, vectorM3, p);
            //path.DrawVector(vectorT1 + vectorM1, vectorM1M2, p);
            //path.DrawVector(vectorT2 + vectorM2, vectorM2M3, p);
            //path.DrawVector(vectorT3 + vectorM3, vectorM3M1, p);

            //path.DrawCircle(vectorT1 + vectorM1, r1, p);
            //path.DrawCircle(vectorT2 + vectorM2, r2, p);
            //path.DrawCircle(vectorT3 + vectorM3, r3, p);

            //p.Color = Color.Green;
            //path.DrawVector(vectorT1 + vectorM1, vectorE1, p);
            //path.DrawVector(vectorT2 + vectorM2, vectorE2, p);
            //path.DrawVector(vectorT3 + vectorM3, vectorE3, p);
            //p.Color = Color.Red;
            //path.DrawVector(vectorT1 + vectorM1, vectorL1, p);
            //path.DrawVector(vectorT2 + vectorM2, vectorL2, p);
            //path.DrawVector(vectorT3 + vectorM3, vectorL3, p);

            //p.Color = Color.Blue;
            //path.DrawVector(vectorT1 + vectorM1 + vectorL1, (vectorT2 + vectorM2 + vectorE2) - (vectorT1 + vectorM1 + vectorL1), p);
            //path.DrawVector(vectorT2 + vectorM2 + vectorL2, (vectorT3 + vectorM3 + vectorE3) - (vectorT2 + vectorM2 + vectorL2), p);
            //path.DrawVector(vectorT3 + vectorM3 + vectorL3, (vectorT1 + vectorM1 + vectorE1) - (vectorT3 + vectorM3 + vectorL3), p);
        }
    }


}
