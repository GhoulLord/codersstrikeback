using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGame
{
    public class RaceState
    {
        public Dictionary<PodRacer, PodRacerRaceState> PodRacerRaceStates;
        public Dictionary<Team, TeamRaceState> TeamRaceStates;

        public int Round { get; set; }
        public double Time { get; set; }

        public bool Finished { get; set; }

        public RaceState()
        {
            Round = 0;
            Time = 0;

            PodRacerRaceStates = new Dictionary<PodRacer, PodRacerRaceState>();
            TeamRaceStates = new Dictionary<Team, TeamRaceState>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("Round:{0,4}({1,8:0.000})", Round, Time));

            sb.AppendLine("Pods:");

            int podIndex = 0;

            foreach (var podRacer in PodRacerRaceStates.Keys)
            {
                sb.AppendLine(string.Format("{0}:{1}", podIndex, podRacer.ToString()));
                podIndex++;
            }

            return sb.ToString();
        }
    }
}
