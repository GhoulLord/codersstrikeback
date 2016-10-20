using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public interface IUnit
    {
        Vector Position { get; }
        Vector Velocity { get; }
        double Thrust { get; }
        double Size { get; }
        double Mass { get; }
        double Heading { get; }
        Vector Orientation { get; }

        double Rotate(double angle);
        Vector Accelerate(double time);
        Vector Move(double time);
        Vector ApplyFraction(double factor);

        Vector PositionAfter(double time);
        double SquareDistanceTo(Unit otherUnit);

        void ConvertStateToInt();
    }
}
