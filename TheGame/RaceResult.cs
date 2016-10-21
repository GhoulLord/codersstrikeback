using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class RaceResult
    {
        public Team WinningTeam { get; set; }
        public Dictionary<PodRacer, List<PodRacerCommand>> CommandsForPodRacers { get; set; }
        public Dictionary<PodRacer, PodRacerRaceResult> PodRacerRaceResults { get; set; }
        public List<RaceState> RaceStates { get; set; }

        public RaceResult()
        {
            WinningTeam = null;
            CommandsForPodRacers = new Dictionary<PodRacer, List<PodRacerCommand>>();
            PodRacerRaceResults = new Dictionary<PodRacer, PodRacerRaceResult>();
            RaceStates = new List<RaceState>();
        }
    }
}
