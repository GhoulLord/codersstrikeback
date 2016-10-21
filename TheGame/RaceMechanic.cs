using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class RaceMechanic
    {
        private PodRacerMechanics racePodRacerMechanics;

        private Race race;
        private IRaceRules raceRules { get { return race.RaceRules; } }
        private RaceState raceState { get { return race.RaceState; } }
        private Arena arena { get { return race.Arena; } }
        private List<Team> teams { get { return race.Teams; } }
        private List<PodRacer> podRacers { get { return race.PodRacers; } }
        private Dictionary<PodRacer, PodRacerRaceState> podRacerRaceStates { get { return raceState.PodRacerRaceStates; } }

        private RaceResult raceResult;

        public static RaceResult ExecuteRace(Race race)
        {
            RaceMechanic raceMechanic;

            raceMechanic = new RaceMechanic(race);

            return raceMechanic.ExecuteRace();
        }

        private RaceMechanic(Race race)
        {
            this.race = race;
            this.racePodRacerMechanics = new PodRacerMechanics(raceRules);
        }

        private RaceResult ExecuteRace()
        {
            Init();
            EvaluateRace();

            return raceResult;
        }

        private void Init()
        {
            raceResult = new RaceResult();

            foreach (var team in teams)
            {
                raceState.TeamRaceStates[team].Timeout = raceRules.TIMEOUT + 1;
            }

            foreach (var podRacer in podRacers)
            {
                raceState.PodRacerRaceStates[podRacer].CurrentCheckPoint = arena.CheckPoints[1];

                raceResult.CommandsForPodRacers.Add(podRacer, new List<PodRacerCommand>());
            }

            raceState.Finished = false;
        }

        private void EvaluateRace()
        {
            while (!raceState.Finished)
            {
                Dictionary<PodRacer, PodRacerCommand> commands;

                commands = GetRacerCommandsFromPilots();

                EvaluateOneRound(commands);
            }
        }

        private Dictionary<PodRacer, PodRacerCommand> GetRacerCommandsFromPilots()
        {
            Dictionary<PodRacer, PodRacerCommand> commands;

            commands = new Dictionary<PodRacer, PodRacerCommand>();

            foreach (var podRacer in podRacers)
            {
                PodRacerCommand command = null;

                if (!raceState.PodRacerRaceStates[podRacer].Failed)
                {
                    try
                    {
                        command = podRacer.Pilot.EvaluateCommand(race);
                    }
                    catch
                    {
                        raceState.PodRacerRaceStates[podRacer].Failed = true;
                    }
                }

                raceResult.CommandsForPodRacers[podRacer].Add(command);
                commands.Add(podRacer, command);
            }

            return commands;
        }

        private void EvaluateOneRound(Dictionary<PodRacer, PodRacerCommand> commands)
        {
            foreach (var podRacer in commands.Keys)
            {
                podRacerRaceStates[podRacer].CurrentCommand = commands[podRacer];
                raceResult.CommandsForPodRacers[podRacer].Add(commands[podRacer]);
            }

            CopyCurrentRaceStateToRaceResult();

            EvaluatePreRound();
            EvaluateRound();
            EvaluatePostRound();
        }

        private void CopyCurrentRaceStateToRaceResult()
        {
            if (raceResult.RaceStates.Count > 0)
            {
                if (raceResult.RaceStates.Last().Time == raceState.Time)
                {
                    raceResult.RaceStates.RemoveAt(raceResult.RaceStates.Count - 1);
                }
            }
            raceResult.RaceStates.Add(raceState.Copy());
        }

        public void EvaluatePreRound()
        {
            foreach (var podRacer in podRacers)
            {
                HandleDestinationCommandForPodRacer(podRacer);
                HandleShieldCommandForPodRacer(podRacer);
                HandleAccelerateCommandsForPodRacer(podRacer);
            }
        }

        private void HandleDestinationCommandForPodRacer(PodRacer podRacer)
        {
            racePodRacerMechanics.RotatePodRacerToPosition(podRacer, podRacerRaceStates[podRacer].CurrentCommand.Destination);
        }

        private void HandleAccelerateCommandsForPodRacer(PodRacer podRacer)
        {
            if (CanPodRacerAccelerate(podRacer))
            {
                if (CurrentCommandForPodRacerIsBoost(podRacer))
                {
                    if (CanPodRacerBoost(podRacer))
                    {
                        BoostPodRacer(podRacer);
                    }
                    else
                    {
                        throw new InvalidOperationException("PodRacer already boosted!");
                    }
                }
                else
                {
                    AcceleratePodRacer(podRacer);
                }
            }
        }

        private bool CanPodRacerAccelerate(PodRacer podRacer)
        {
            return podRacerRaceStates[podRacer].ShieldPenaltyRoundsCounter == 0;
        }

        private bool CurrentCommandForPodRacerIsBoost(PodRacer podRacer)
        {
            return podRacerRaceStates[podRacer].CurrentCommand.Boost;
        }

        private bool CanPodRacerBoost(PodRacer podRacer)
        {
            return !podRacerRaceStates[podRacer].HasBoosted;
        }

        private void BoostPodRacer(PodRacer podRacer)
        {
            podRacerRaceStates[podRacer].HasBoosted = true;
            racePodRacerMechanics.BoostPodRacer(podRacer);
        }

        private void AcceleratePodRacer(PodRacer podRacer)
        {
            racePodRacerMechanics.AcceleratePodRacer(podRacer, podRacerRaceStates[podRacer].CurrentCommand.Thrust);
        }

        private void HandleShieldCommandForPodRacer(PodRacer podRacer)
        {
            if (CurrentCommandForPodRacerIsShield(podRacer))
            {
                ShieldPodRacer(podRacer);
            }
            else
            {
                UnShieldPodRacer(podRacer);
            }
        }

        private bool CurrentCommandForPodRacerIsShield(PodRacer podRacer)
        {
            return podRacerRaceStates[podRacer].CurrentCommand.Shield;
        }

        private void ShieldPodRacer(PodRacer podRacer)
        {
            podRacerRaceStates[podRacer].ShieldPenaltyRoundsCounter = raceRules.SHIELD_PENALTY_ROUNDS;
            podRacer.TurnShieldOn();
        }

        private static void UnShieldPodRacer(PodRacer podRacer)
        {
            podRacer.TurnShieldOff();
        }

        private void HandlePodRacerHitCheckpoint(PodRacer podRacer, CheckPoint checkPoint)
        {
            PodRacerRaceState podRacerRaceState = raceState.PodRacerRaceStates[podRacer];
            Team team = podRacer.Owner;
            TeamRaceState teamRaceState = raceState.TeamRaceStates[team];
            CheckPoint nextCheckPoint;

            if (podRacerRaceState.CurrentCheckPoint == checkPoint)
            {
                teamRaceState.Timeout = raceRules.TIMEOUT + 1;

                if (checkPoint == arena.GetStartFinish())
                {
                    podRacerRaceState.RoundsFinished++;

                    if (raceResult.WinningTeam == null)
                    {
                        if (podRacerRaceState.RoundsFinished == raceRules.RACE_LENGTH)
                        {
                            raceResult.WinningTeam = team;
                            raceState.Finished = true;
                            teamRaceState.FinishedRace = true;
                        }
                    }
                }

                nextCheckPoint = arena.GetNextCheckPoint(checkPoint);
                podRacerRaceState.CurrentCheckPoint = nextCheckPoint;
            }
        }

        private void FinalizeRoundForPodRacer(PodRacer podRacer, PodRacerRaceState podRacerRaceState)
        {
            podRacer.ConvertStateToInt();

            if (podRacerRaceState.ShieldPenaltyRoundsCounter > 0)
            {
                podRacerRaceState.ShieldPenaltyRoundsCounter--;
            }
        }

        private void FinalizeRoundForPlayer(Team player, TeamRaceState teamRaceState)
        {
            if (teamRaceState.Timeout > 0)
            {
                teamRaceState.Timeout--;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Player Timeout!");
            }
        }

        public void EvaluateRound(double duration = 1.0)
        {
            double timePassed = 0;

            while (timePassed < duration)
            {
                double collisionTime;

                List<Collision> collisions;

                collisions = Collision.CalculateCollisions(race, duration - timePassed);

                if (collisions.Count > 0)
                {
                    collisionTime = collisions.First().Time;
                }
                else
                {
                    collisionTime = duration - timePassed;
                }

                foreach (var podRacer in podRacers)
                {
                    podRacer.Move(collisionTime);
                }

                foreach (Collision collision in collisions)
                {
                    if (collision.UnitA is CheckPoint)
                    {
                        HandlePodRacerHitCheckpoint((PodRacer)collision.UnitB, (CheckPoint)collision.UnitA);
                    }
                    else if (collision.UnitB is CheckPoint)
                    {
                        HandlePodRacerHitCheckpoint((PodRacer)collision.UnitA, (CheckPoint)collision.UnitB);
                    }
                    else
                    {
                        racePodRacerMechanics.Bounce((PodRacer)collision.UnitA, (PodRacer)collision.UnitB);
                    }
                }

                timePassed += collisionTime;

                raceState.Time += collisionTime;

                CopyCurrentRaceStateToRaceResult();
            }
        }

        public void EvaluatePostRound()
        {
            foreach (var podRacer in podRacers)
            {
                racePodRacerMechanics.ApplyFractionToPodRacer(podRacer);
                FinalizeRoundForPodRacer(podRacer, raceState.PodRacerRaceStates[podRacer]);
            }

            foreach (var team in teams)
            {
                FinalizeRoundForPlayer(team, raceState.TeamRaceStates[team]);

                if (raceState.TeamRaceStates[team].Timeout == 0)
                {
                    raceState.TeamRaceStates[team].Disqualified = true;
                }
            }

            List<KeyValuePair<Team, TeamRaceState>> teamsNotDisqualified = raceState.TeamRaceStates.Where(kvp => kvp.Value.Disqualified == false).ToList();

            if (teamsNotDisqualified.Count == 1)
            {
                raceResult.WinningTeam = teamsNotDisqualified[0].Key;
                raceState.Finished = true;
            }
            else if (teamsNotDisqualified.Count == 0)
            {
                raceState.Finished = true;
            }

            raceState.Round++;
        }
    }
}
