using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public abstract class Unit : IUnit
    {
        virtual public Vector Position { get; set; }
        virtual public Vector Velocity { get; set; }
        virtual public double Thrust { get; set; }
        virtual public double Size { get; set; }
        virtual public double Mass { get; set; }
        private double heading;
        virtual public double Heading { get { return heading; } set { SetHeading(value); } }
        virtual public Vector Orientation { get { return CalculateOrientationVector(); } }

        private Vector CalculateOrientationVector()
        {
            return new Vector(1, 0).Rotate(Heading);
        }

        public Unit(Vector position, double size)
        {
            Position = position;
            Size = size;
            Thrust = 0;
            Velocity = new Vector(0, 0);
            Mass = 0;
            Heading = 0;
        }

        public Unit(Unit unit)
        {
            Position = unit.Position;
            Velocity = unit.Velocity;
            Thrust = unit.Thrust;
            Size = unit.Size;
            Mass = unit.Mass;
            Heading = unit.Heading;
        }

        private void SetHeading(double heading)
        {
            if (heading > 360)
            {
                heading -= 360;
            }
            else if (heading < 0)
            {
                heading += 360;
            }

            this.heading = heading;
        }

        public double Rotate(double angle)
        {
            Heading += angle;

            return Heading;
        }

        public Vector Accelerate(double time)
        {
            Velocity = Velocity + Thrust * Orientation * time;

            return Velocity;
        }

        public Vector Move(double time)
        {
            Position = Position + Velocity * time;

            return Position;
        }

        public Vector ApplyFraction(double factor)
        {
            Velocity = (1.0 - factor) * Velocity;

            return Velocity;
        }

        public double SquareDistanceTo(Unit otherUnit)
        {
            return (otherUnit.Position - Position).LengthSquared;
        }

        public Vector PositionAfter(double time)
        {
            return Position + Velocity * time;
        }

        public void ConvertStateToInt()
        {
            Position = new Vector(MyRound(Position.X), MyRound(Position.Y));
            Velocity = new Vector((int)Velocity.X, (int)Velocity.Y);
        }

        private int MyRound(double d)
        {
            if (d < 0)
            {
                return (int)(d - 0.5);
            }
            return (int)(d + 0.5);
        }
    }
}
