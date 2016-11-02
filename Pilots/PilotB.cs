using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGame;

namespace Pilots
{
    public class PilotB : IPilot
    {
        public PodRacer PodRacer { get; set; }

        public PodRacerCommand EvaluateCommand(Race race)
        {
            PodRacerCommand command;

            command = new PodRacerCommand()
            {
                Thrust = 100,
                Destination = new Vector(0,0)
            };

            return command;
        }
    }
}
