using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class Game
    {
        private IGameRules gameRules;

        public Arena Arena { get; set; }
        public List<Team> Teams { get; set; }
        public List<PodRacer> PodRacers { get; set; }

        public Game(IGameRules gameRules)
        {
            this.gameRules = gameRules;

            Arena = new Arena(this.gameRules.ARENA_WIDTH, this.gameRules.ARENA_HEIGHT);
            Teams = new List<Team>();
            PodRacers = new List<PodRacer>();
        }

        public CheckPoint CreateCheckPoint(int number, Vector position)
        {
            return Arena.CreateCheckPoint(number, position, gameRules.CHECKPOINT_RADIUS);
        }

        public Team CreateTeam(string name, System.Drawing.Color color)
        {
            Team newTeam;

            newTeam = new Team(name, color);
            Teams.Add(newTeam);

            return newTeam;
        }

        public PodRacer CreatePodRacer(Team team, int number, IPilot pilot, Vector position, double heading)
        {
            return CreatePodRacer(team, number, pilot, position, heading, PodRacerPhysics.Instance);
        }

        public PodRacer CreatePodRacer(Team team, int number, IPilot pilot, Vector position, double heading, IPodRacerPhysics podRacerPhysics)
        {
            PodRacer newPodRacer;

            newPodRacer = new PodRacer(team, number, pilot, position, heading, podRacerPhysics);
            team.PodRacers.Add(newPodRacer);
            pilot.PodRacer = newPodRacer;
            PodRacers.Add(newPodRacer);

            return newPodRacer;
        }

        public Race CreateRace(int startingTeamIndex)
        {
            return CreateRace(RaceRules.Instance, startingTeamIndex);
        }

        public Race CreateRace(IRaceRules raceRules, int startingTeamIndex)
        {
            Race newRace;

            newRace = new Race(raceRules, Arena, Teams, startingTeamIndex);

            return newRace;
        }
    }
}
