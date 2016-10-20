using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class PodRacer : Unit
    {
        public Team Owner { get; set; }
        public int Number { get; set; }
        public IPilot Pilot { get; set; }
        public IPodRacerPhysics PodRacerPhysics { get; private set; }

        public double PureMass { get; set; }
        override public double Mass { get { if (IsShielded) { return PureMass * 10.0; } else return PureMass; } }

        public bool IsShielded { get; set; }

        public PodRacer(Team owner, int number, IPilot pilot, Vector position, double heading, IPodRacerPhysics podRacerPhysics)
            : base(position, podRacerPhysics.POD_RACER_RADIUS)
        {
            Owner = owner;
            Number = number;
            Pilot = pilot;

            PureMass = 1;
            Position = position;
            Heading = heading;
            PodRacerPhysics = podRacerPhysics;
        }

        public PodRacer(PodRacer podRacer)
            : base(podRacer)
        {
            Owner = podRacer.Owner;
            Number = podRacer.Number;
            PureMass = podRacer.PureMass;
        }

        public void TurnShieldOn()
        {
            IsShielded = true;
        }

        public void TurnShieldOff()
        {
            IsShielded = false;
        }

        public override string ToString()
        {
            return string.Format("{5}:{0}, {1}, {2,3:0}, ({3}), '{4}'", Position, Velocity, Heading, IsShielded ? "S" : "-", Owner.Name, Number);
        }

    }
}
