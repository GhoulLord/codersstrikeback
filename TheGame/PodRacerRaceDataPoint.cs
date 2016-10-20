using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class PodRacerRaceDataPoint
    {
        public Vector Position { get; set; }
        public Vector Velocity { get; set; }
        public double Heading { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2:000.00}", Position, Velocity, Heading);
        }
    }
}
