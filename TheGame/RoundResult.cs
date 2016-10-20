using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class RoundResult
    {
        public Team WinningTeam { get; set; }
        public Dictionary<PodRacer, PodRacerRaceResult> PodRacerRaceResults { get; set; }
        public List<PodRacerRaceDataPoint> PodRacerRaceDataPoints { get; set; }

        public RoundResult()
        {
            WinningTeam = null;
            PodRacerRaceResults = null;
            PodRacerRaceDataPoints = null;
        }
    }
}
