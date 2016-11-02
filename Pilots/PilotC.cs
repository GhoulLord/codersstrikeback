using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGame;

namespace Pilots
{
    public class PilotC : IPilot
    {
        public PodRacer PodRacer { get; set; }

        public PodRacerCommand EvaluateCommand(Race race)
        {
            PodRacerCommand command;

            //command = new PodRacerCommand()
            //{
            //    Thrust = 100,
            //    Destination = new Vector(0,0)
            //};

            command = new PodRacerCommand()
            {
                Thrust = 70,
                Destination = race.
                RaceState.
                PodRacerRaceStates[PodRacer].
                CurrentCheckPoint.
                Position
            };

            return command;
        }
    }
}
