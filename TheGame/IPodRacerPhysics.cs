using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public interface IPodRacerPhysics
    {
        int MIN_THRUST { get; }
        int MAX_THRUST { get; }
        double FRACTION_FACTOR { get; }
        double MAX_ROTATION_SPEED { get; }
        int BOOST_THRUST { get; }
        int POD_RACER_RADIUS { get; }
    }
}
