using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class PodRacerPhysics : IPodRacerPhysics
    {
        private static readonly int MIN_THRUST = 0;
        private static readonly int MAX_THRUST = 100;
        private static readonly int BOOST_THRUST = 650;
        private static readonly int POD_RACER_RADIUS = 400;
        private static readonly double FRACTION_FACTOR = 0.15;
        private static readonly double ROTATION_SPEED = 18;

        int IPodRacerPhysics.MIN_THRUST { get { return MIN_THRUST; } }
        int IPodRacerPhysics.MAX_THRUST { get { return MAX_THRUST; } }
        int IPodRacerPhysics.BOOST_THRUST { get { return BOOST_THRUST; } }
        int IPodRacerPhysics.POD_RACER_RADIUS { get { return POD_RACER_RADIUS; } }
        double IPodRacerPhysics.FRACTION_FACTOR { get { return FRACTION_FACTOR; } }
        double IPodRacerPhysics.MAX_ROTATION_SPEED { get { return ROTATION_SPEED; } }

        private static readonly Lazy<PodRacerPhysics> lazy =
            new Lazy<PodRacerPhysics>(() => new PodRacerPhysics());

        public static PodRacerPhysics Instance { get { return lazy.Value; } }

        private PodRacerPhysics()
        {
        }
    }
}
