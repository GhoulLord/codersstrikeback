using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public struct Matrix
    {
        public double M11 { get; set; }
        public double M12 { get; set; }
        public double M21 { get; set; }
        public double M22 { get; set; }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            return new Matrix() { M11 = a.M11 + b.M11, M12 = a.M12 + b.M12, M21 = a.M21 + b.M21, M22 = a.M22 + b.M22 };
        }

        public static Matrix RotationMatrix (double angleInDegrees)
        {
            double sinAngle = Math.Sin(angleInDegrees / 180.0 * Math.PI);
            double cosAngle = Math.Cos(angleInDegrees / 180.0 * Math.PI);

            return new Matrix() { M11 = cosAngle, M12 = -sinAngle, M21 = sinAngle, M22 = cosAngle };
        }

        public override string ToString()
        {
            return string.Format("(({0:0.00}, {1:0.00}), ({2:0.00}, {3:0.00}))", M11, M12, M21, M22);
        }
    }
}
