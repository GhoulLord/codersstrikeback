using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class GameState
    {
        public int Round { get; set; }
        public double Time { get; set; }
        public Arena Arena;
        public Team Winner;
        public List<Team> Players;
        public Dictionary<Team, TeamRaceState> TeamRaceStates;
        public List<PodRacer> PodRacers;
        public Dictionary<PodRacer, PodRacerRaceState> PodRacerGameStates;
        public bool Finished { get; set; }

        public GameState()
        {
            Round = 0;
            Time = 0;
            Arena = new Arena(16000,9000);
            Players = new List<Team>();
            TeamRaceStates = new Dictionary<Team, TeamRaceState>();
            PodRacers = new List<PodRacer>();
            PodRacerGameStates = new Dictionary<PodRacer, PodRacerRaceState>();
            Winner = null;
            Finished = false;
        }

        public List<Unit> GetUnits()
        {
            List<Unit> units = new List<Unit>();

            units.AddRange(GetPodRacers());
            units.AddRange(GetCheckPoints());

            return units;
        }

        public List<PodRacer> GetPodRacers()
        {
            return new List<PodRacer>(PodRacers);
        }

        public Dictionary<Team, List<PodRacer>> GetPlayersPodracers()
        {
            Dictionary<Team, List<PodRacer>> playersPodracers = new Dictionary<Team, List<PodRacer>>();

            foreach (var player in Players)
            {
                List<PodRacer> podRacers = new List<PodRacer>();
                playersPodracers.Add(player, podRacers);
            }

            foreach (var podRacer in PodRacers)
            {
                playersPodracers[podRacer.Owner].Add(podRacer);
            }

            return playersPodracers;
        }

        public List<CheckPoint> GetCheckPoints()
        {
            List<CheckPoint> checkPoints = new List<CheckPoint>();

            checkPoints.AddRange(Arena.CheckPoints);

            return checkPoints;
        }

        internal string CreateGameStateString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("Round:{0,4}({1,8:0.000})", Round, Time));

            sb.AppendLine("Pods:");

            int podIndex = 0;

            foreach (var podRacer in PodRacers)
            {
                sb.AppendLine(string.Format("{0}:{1}", podIndex, podRacer.ToString()));
                podIndex++;
            }

            return sb.ToString();
        }
    }
}
