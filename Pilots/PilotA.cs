using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGame;

namespace Pilots
{
    public class PilotA : IPilot
    {
        public PodRacer PodRacer { get; set; }

        public PodRacerCommand EvaluateCommand(Race race)
        {
            PodRacerCommand command;

            command = new PodRacerCommand() {
                Thrust = 100,
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
