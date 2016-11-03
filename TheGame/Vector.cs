using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Length { get { return Math.Sqrt(LengthSquared); } }
        public double LengthSquared { get { return X * X + Y * Y; } }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vector(double length)
        {
            X = length;
            Y = 0;
        }

        public Vector(Vector vector)
        {
            X = vector.X;
            Y = vector.Y;
        }

        public Vector Project(Vector projectOn)
        {
            Vector projectedVector;
            Vector projectOnNormalized = projectOn.CreateNormalizedVector();
            projectedVector = (this * projectOnNormalized) * projectOnNormalized;

            return projectedVector;
        }

        public Vector CreateNormalizedVector()
        {
            return this / Length;
        }

        public bool IsEqual(Vector other)
        {
            return ((X == other.X) && (Y == other.Y));
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }

        public static Vector operator -(Vector a)
        {
            return new Vector(-a.X, -a.Y);
        }

        public static double operator *(Vector a, Vector b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        public static Vector operator *(double r, Vector a)
        {
            return new Vector(r * a.X, r * a.Y);
        }

        public static Vector operator *(Vector a, double r)
        {
            return r * a;
        }

        public static Vector operator /(Vector a, double r)
        {
            return (1 / r) * a;
        }

        public static Vector operator *(Matrix m, Vector v)
        {
            return new Vector(m.M11 * v.X + m.M12 * v.Y, m.M21 * v.X + m.M22 * v.Y);
        }

        public double GetAngle()
        {
            double angle;

            angle = Math.Atan2(Y, X) * 180.0 / Math.PI;

            return angle;
        }

        public double GetAngle(Vector otherVector)
        {
            double angle;

            angle = otherVector.GetAngle() - GetAngle();

            if (angle <= -180)
            {
                angle += 360;
            }
            else if (angle >= 180)
            {
                angle -= 360;
            }

            return angle;
        }

        public Vector Rotate(double angleInDegrees)
        {
            Vector rotated = Matrix.RotationMatrix(angleInDegrees) * this;
            
            return rotated;
        }

        public override string ToString()
        {
            return string.Format("{0,8:0.00}/{1,8:0.00}({2,9:0.00})", X, Y, Length);
        }
    }
}
