using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class PodRacerCommand
    {
        public Vector Destination { get; set; }
        public int Thrust { get; set; }
        public bool Shield { get; set; }
        public bool Boost { get; set; }

        public override string ToString()
        {
            return string.Format("D:{0} T:{1} S:{2} B:{3}", Destination, Thrust, Shield, Boost);
        }

        public PodRacerCommand Copy()
        {
            PodRacerCommand copy;

            copy = new PodRacerCommand();

            copy.Destination = new Vector(Destination);
            copy.Thrust = Thrust;
            copy.Shield = Shield;
            copy.Boost = Boost;

            return copy;
        }
    }
}
