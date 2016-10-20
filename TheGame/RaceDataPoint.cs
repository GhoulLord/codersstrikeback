using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class RaceDataPoint
    {
        public double RoundTime { get; set; }
        public Dictionary<PodRacer, PodRacerRaceDataPoint> PodRacerRaceDataPoints { get; set; }
    }
}
