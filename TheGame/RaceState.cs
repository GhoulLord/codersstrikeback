using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGame
{
    public class RaceState
    {
        public Race Race { get; set; }
        public Dictionary<PodRacer, PodRacerRaceState> PodRacerRaceStates;
        public Dictionary<Team, TeamRaceState> TeamRaceStates;

        public int Round { get; set; }
        public double Time { get; set; }

        public bool Finished { get; set; }

        public RaceState(Race race)
        {
            Race = race;
            Round = 0;
            Time = 0;

            PodRacerRaceStates = new Dictionary<PodRacer, PodRacerRaceState>();
            TeamRaceStates = new Dictionary<Team, TeamRaceState>();
        }

        public static RaceState CreateInterpolation(RaceState a, RaceState b, double time)
        {
            RaceState interpolation;

            interpolation = a.Copy();

            List<PodRacer> keys;

            keys = interpolation.PodRacerRaceStates.Keys.ToList();

            foreach (var podRacerRaceStateKeys in keys)
            {
                interpolation.PodRacerRaceStates[podRacerRaceStateKeys] = PodRacerRaceState.CreateInterpolation(a.PodRacerRaceStates[podRacerRaceStateKeys], b.PodRacerRaceStates[podRacerRaceStateKeys], (time - a.Time) / (b.Time - a.Time));
            }

            return interpolation;
        }

        public RaceState Copy()
        {
            RaceState copy;

            copy = new RaceState(this.Race);
            copy.Round = Round;
            copy.Time = Time;
            copy.Finished = Finished;

            foreach (var vkp in PodRacerRaceStates)
            {
                copy.PodRacerRaceStates.Add(vkp.Key, vkp.Value.Copy());
            }

            foreach (var vkp in TeamRaceStates)
            {
                copy.TeamRaceStates.Add(vkp.Key, vkp.Value.Copy());
            }

            return copy;
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
