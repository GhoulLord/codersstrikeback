using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class Race
    {
        public List<Team> Teams { get; set; }
        public List<PodRacer> PodRacers { get; private set; }
        public List<Unit> Units { get; private set; }
        public Arena Arena { get; set; }
        public IRaceRules RaceRules { get; set; }
        public RaceState RaceState { get; set; }

        public Race(IRaceRules raceRules, Arena arena, List<Team> teams, int startingTeamIndex = 0)
        {
            RaceRules = raceRules;
            Arena = arena;
            Teams = teams;

            PodRacers = Teams.SelectMany(t => t.PodRacers).ToList();
            Units = PodRacers.Select(p => (Unit)p).Concat(Arena.CheckPoints).ToList();

            InitRaceState();
            InitPodRacer(startingTeamIndex);
        }

        private void InitPodRacer(int startingTeamIndex)
        {
            CheckPoint startFinishCheckPoint = Arena.GetStartFinish();
            CheckPoint firstTargetCheckPoint = Arena.GetNextCheckPoint(startFinishCheckPoint);
            double maxPodSize = PodRacers.Max(p => p.Size);

            double angleDelta = 2.0 * Math.PI / PodRacers.Count;
            double alpha = Math.Sqrt(1.0/ (2.0 * (1 - Math.Cos(angleDelta))));
            double startingPositionOffset = 2 * alpha * maxPodSize;

            startingPositionOffset += RaceRules.INITIAL_POSITION_OFFSET;

            Vector startingPositionOffsetVector = new Vector(0, startingPositionOffset);

            double rotatingAngle = 360.0 / PodRacers.Count;

            int teamMaxPodCount = Teams.Max(t => t.PodRacers.Count);

            for (int podIndex = 0; podIndex < teamMaxPodCount; podIndex++)
            {
                int teamIndex = startingTeamIndex;
                for (int index = 0; index < Teams.Count; index++)
                {
                    if (podIndex < Teams[teamIndex].PodRacers.Count)
                    {
                        Teams[teamIndex].PodRacers[podIndex].Velocity = new Vector(0, 0);
                        Teams[teamIndex].PodRacers[podIndex].Position = startFinishCheckPoint.Position + startingPositionOffsetVector;
                        Teams[teamIndex].PodRacers[podIndex].Heading = (firstTargetCheckPoint.Position - Teams[teamIndex].PodRacers[podIndex].Position).GetAngle();
                        Teams[teamIndex].PodRacers[podIndex].ConvertStateToInt();
                        startingPositionOffsetVector = startingPositionOffsetVector.Rotate(rotatingAngle);
                    }
                    teamIndex = (teamIndex + 1) % Teams.Count;
                }
            }
        }

        private void InitRaceState()
        {
            RaceState = new RaceState(this);

            foreach (var team in Teams)
            {
                RaceState.TeamRaceStates.Add(team, new TeamRaceState());
                foreach (var podRacer in team.PodRacers)
                {
                    RaceState.PodRacerRaceStates.Add(podRacer, new PodRacerRaceState(podRacer));
                }
            }
        }

        public RaceResult ExecuteRace()
        {
            return RaceMechanic.ExecuteRace(this);
        }
    }
}
