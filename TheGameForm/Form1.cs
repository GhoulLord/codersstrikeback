﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using TheGame;
using Pilots;

namespace TheGameForm
{
    public partial class Form1 : Form
    {
        private Game game = null;
        private Race race = null;
        private Team teamA;
        //private Team teamB;
        private Dictionary<Team, List<PodRacer>> podRacers = new Dictionary<Team, List<PodRacer>>();
        Dictionary<PodRacer, PodRacerCommand> commands = new Dictionary<PodRacer, PodRacerCommand>();


        public Form1()
        {
            InitGame();

            InitializeComponent();

            gameArena.SetRaceState(race.RaceState);
        }

        protected void InitGame()
        {
            game = new Game(GameRules.Instance);

            List<Vector> checkPointPositions = new List<Vector>()
            {
                /* 16000x9000 */
                new Vector(3000, 3000),
                new Vector(10000, 1000),
                new Vector(10000 - 1201, 1000),
                new Vector(5000, 6000),
                new Vector(6000, 2000),
            };

            int checkPointIndex = 0;

            foreach (var checkPointPosition in checkPointPositions)
            {
                game.CreateCheckPoint(checkPointIndex, checkPointPosition);
                checkPointIndex++;
            }

            List<Team> players = new List<Team>();

            teamA = game.CreateTeam("A", Color.Red);
            players.Add(teamA);
            //teamB = game.CreateTeam("B", Color.Green);
            //players.Add(teamB);

            PodRacer podRacerA = null;
            //PodRacer podRacerB = null;
            List<PodRacer> podRacersForPlayer;

            podRacersForPlayer = new List<PodRacer>();
            podRacerA = game.CreatePodRacer(
                teamA,
                0,
                new PilotC(),
                new Vector(
                    5000,
                    1000
                ),
                    90
                    );
            //podRacerB = game.CreatePodRacer(
            //    teamA,
            //    1,
            //    new PilotC(),
            //    new Vector(
            //        5000,
            //        9000
            //    ),
            //        270
            //        );

            podRacersForPlayer.Add(podRacerA);
            //podRacersForPlayer.Add(podRacerB);
            podRacers.Add(teamA, podRacersForPlayer);

            //podRacersForPlayer = new List<PodRacer>();
            //podRacerA = game.CreatePodRacer(
            //    teamB,
            //    2,
            //    new PilotB(),
            //    new Vector(
            //        9000,
            //        5000
            //    ),
            //        180
            //        );
            //podRacerB = game.CreatePodRacer(
            //    teamB,
            //    3,
            //    new PilotC(),
            //    new Vector(
            //        1000,
            //        5000
            //    ),
            //        0
            //        );

            //podRacersForPlayer.Add(podRacerA);
            //podRacersForPlayer.Add(podRacerB);
            //podRacers.Add(teamB, podRacersForPlayer);

            race = game.CreateRace(0);

            //Dictionary<Team, TeamRaceState> teamGameStates = race.RaceState.TeamGameStates;

            //Dictionary<PodRacer, PodRacerRaceState> podRacerGameStates = race.RaceState.PodRacerRaceStates;

            //podRacerGameStates[podRacers[teamA][0]].CurrentCommand = new PodRacerCommand() { Thrust = 100, Destination = podRacerGameStates[podRacers[teamA][0]].CurrentCheckPoint.Position };
            //podRacerGameStates[podRacers[teamA][1]].CurrentCommand = new PodRacerCommand() { Thrust = 100, Destination = podRacerGameStates[podRacers[teamA][1]].CurrentCheckPoint.Position };
            //podRacerGameStates[podRacers[teamB][0]].CurrentCommand = new PodRacerCommand() { Thrust = 100, Destination = podRacerGameStates[podRacers[teamB][0]].CurrentCheckPoint.Position };
            //podRacerGameStates[podRacers[teamB][1]].CurrentCommand = new PodRacerCommand() { Thrust = 100, Destination = podRacerGameStates[podRacers[teamB][1]].CurrentCheckPoint.Position };
        }

        private void buttonInitRace_Click(object sender, EventArgs e)
        {
            raceStates = null;

            race = game.CreateRace(0);

            UpdateUi(race.RaceState);
        }

        private void DoNRounds(int rounds)
        {
            for (int round = 0; round < rounds; round++)
            {
                DoOneRound();
            }
        }

        int frameCounter = 0;

        private void buttonInitRaceSwapped_Click(object sender, EventArgs e)
        {
            raceStates = null;

            race = game.CreateRace(1);

            UpdateUi(race.RaceState);
        }

        private void UpdateUi(RaceState raceState)
        {
            if (gameArena.InvokeRequired)
            {
                gameArena.Invoke(new MethodInvoker(() => { UpdateUi(raceState); }));
                return;
            }

            gameArena.SetRaceState(raceState);

            gameArena.Refresh();

            labelRound.Text = raceState.Round.ToString();
            labelTime.Text = string.Format("{0,8:0.000}", raceState.Time);

            //labelPlayerARounds.Text = string.Format("{0}/{1}", raceState.PodRacerRaceStates[teamA.PodRacers[0]].RoundsFinished, raceState.PodRacerRaceStates[teamA.PodRacers[1]].RoundsFinished);
            labelPlayerARounds.Text = string.Format("{0}", raceState.PodRacerRaceStates[teamA.PodRacers[0]].RoundsFinished);
            labelPlayerATimeout.Text = raceState.TeamRaceStates[teamA].Timeout.ToString();
            if (raceState.PodRacerRaceStates[teamA.PodRacers[0]].CurrentCheckPoint != null)
            {
                labelPlayerACheckpoint1.Text = raceState.PodRacerRaceStates[teamA.PodRacers[0]].CurrentCheckPoint.ToString();
                labelPlayerACheckpoint2.Text = raceState.PodRacerRaceStates[teamA.PodRacers[0]].PodRacer.ToString();
            }
            //labelPlayerBRounds.Text = string.Format("{0}/{1}", raceState.PodRacerRaceStates[teamB.PodRacers[0]].RoundsFinished, raceState.PodRacerRaceStates[teamB.PodRacers[1]].RoundsFinished);
            //labelPlayerBTimeout.Text = raceState.TeamRaceStates[teamB].Timeout.ToString();
            //if (raceState.PodRacerRaceStates[teamB.PodRacers[0]].CurrentCheckPoint != null)
            //{
            //    labelPlayerBCheckpoint1.Text = raceState.PodRacerRaceStates[teamB.PodRacers[0]].CurrentCheckPoint.ToString();
            //    labelPlayerBCheckpoint2.Text = raceState.PodRacerRaceStates[teamB.PodRacers[1]].CurrentCheckPoint.ToString();
            //}
        }

        private void DoOneFrame()
        {
            //if (frameCounter == 0)
            //{
            //    game.SimulatePreRound();
            //}

            //game.SimulateRound(1.0 / 25);
            //frameCounter++;

            //if (frameCounter == 25)
            //{
            //    game.SimulatePostRound();
            //    frameCounter = 0;
            //}

            //race.ExecuteRace();

            //UpdateUi();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (raceStates != null)
            {
                AnimationTaskNext(raceStates);
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (raceStates != null)
            {
                AnimationTaskPrev(raceStates);
            }
        }

        private void DoOneRound()
        {
            //Dictionary<Team, TeamRaceState> playerGameStates = game.GetGameState().PlayerGameStates;

            //Dictionary<PodRacer, PodRacerRaceState> podRacerGameStates = game.GetGameState().PodRacerGameStates;

            //podRacerGameStates[podRacers[teamA][0]].CurrentCommand = new PodRacerCommand() { Thrust = 100, Destination = podRacerGameStates[podRacers[teamA][0]].CurrentCheckPoint.Position };
            //podRacerGameStates[podRacers[teamA][1]].CurrentCommand = new PodRacerCommand() { Thrust = 100, Destination = podRacerGameStates[podRacers[teamA][1]].CurrentCheckPoint.Position };
            ////podRacerGameStates[podRacers[playerA][0]].Command = new PodRacerCommand() { Thrust = 100, Destination = new Vector(5000, 5000) };
            ////podRacerGameStates[podRacers[playerA][1]].Command = new PodRacerCommand() { Thrust = 100, Destination = new Vector(5000, 5000) };
            //podRacerGameStates[podRacers[teamB][0]].CurrentCommand = new PodRacerCommand() { Thrust = 100, Destination = podRacerGameStates[podRacers[teamB][0]].CurrentCheckPoint.Position };
            //podRacerGameStates[podRacers[teamB][1]].CurrentCommand = new PodRacerCommand() { Thrust = 100, Destination = podRacerGameStates[podRacers[teamB][1]].CurrentCheckPoint.Position };

            //for (int i = 0; i < 25; i++)
            //{
            //    DoOneFrame();
            //}
        }

        List<RaceState> raceStates = null;

        private void buttonExecuteRace_Click(object sender, EventArgs e)
        {
            RaceResult result;

            result = race.ExecuteRace();

            benchmarkStopWatch = new Stopwatch();
            benchmarkStopWatch.Start();

            raceStates = GenerateRaceStatesFor25FPS(result);

            currentRaceRound = 0;
            currentRaceStateIndex = 0;
        }

        Task animationTask = null;
        CancellationTokenSource animationTaskCancellationSource = null;

        int currentRaceRound = 0;
        int currentRaceStateIndex = 0;

        private void AnimationTaskWholeRace(List<RaceState> raceStates, CancellationToken cancellationToken)
        {
            while ((currentRaceStateIndex + 1) < raceStates.Count)
            {
                currentRaceStateIndex++;

                UpdateUi(raceStates[currentRaceStateIndex]);

                if (raceStates[currentRaceStateIndex].Round != currentRaceRound)
                {
                    currentRaceRound = raceStates[currentRaceStateIndex].Round;
                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }
                }

                //Thread.Sleep(2);
            }
        }

        private bool IsInteger(double d)
        {
            return (Math.Abs(d % 1) < Double.Epsilon);
        }

        private void AnimationTaskNext(List<RaceState> raceStates)
        {
            double currentRaceStateTime = raceStates[currentRaceStateIndex].Time;

            double destinationTime;

            destinationTime = Math.Ceiling(currentRaceStateTime) + 1;

            while ((currentRaceStateIndex + 1) < raceStates.Count)
            {
                currentRaceStateIndex++;

                UpdateUi(raceStates[currentRaceStateIndex]);

                currentRaceRound = raceStates[currentRaceStateIndex].Round;

                if (raceStates[currentRaceStateIndex].Time >= destinationTime)
                {
                    break;
                }
            }
        }

        private void AnimationTaskPrev(List<RaceState> raceStates)
        {
            double currentRaceStateTime = raceStates[currentRaceStateIndex].Time;

            double destinationTime;

            destinationTime = Math.Floor(currentRaceStateTime) - 1;

            while (currentRaceStateIndex > 0)
            {
                currentRaceStateIndex--;

                UpdateUi(raceStates[currentRaceStateIndex]);

                currentRaceRound = raceStates[currentRaceStateIndex].Round;

                if (raceStates[currentRaceStateIndex].Time <= destinationTime)
                {
                    break;
                }
            }
        }

        Stopwatch benchmarkStopWatch;

        private List<RaceState> GenerateRaceStatesFor25FPS(RaceResult raceResult)
        {
            List<RaceState> raceStates;

            raceStates = new List<RaceState>();

            RaceState raceStateA;
            RaceState raceStateB;

            int raceStateIndex = 0;
            double time = 0;
            double stopTime = Math.Ceiling(raceResult.RaceStates.Last().Time);

            int timeIndex = 0;

            raceStateA = raceResult.RaceStates[0];
            raceStateB = raceResult.RaceStates[1];

            while (time < stopTime)            
            {
                int frameIndex;

                for (frameIndex = 0; frameIndex < 25; frameIndex++)
                {
                    time = timeIndex + frameIndex / 25.0;

                    while (((raceStateIndex + 1) < raceResult.RaceStates.Count) && (time >= raceResult.RaceStates[raceStateIndex + 1].Time))
                    {
                        raceStateIndex++;

                        if (raceStateIndex < raceResult.RaceStates.Count)
                        {
                            raceStateA = raceStateB;
                            raceStateB = raceResult.RaceStates[raceStateIndex + 1];
                        }
                    }

                    RaceState raceStateForFrame;

                    //raceStateForFrame = raceResult.RaceStates[raceStateIndex].Copy();
                    //raceStateForFrame.Time = time;
                    raceStateForFrame = RaceState.CreateInterpolation(raceStateA, raceStateB, time);

                    //raceStateA = raceResult.RaceStates[raceStateIndex];
                    //raceStateB = raceResult.RaceStates[raceStateIndex + 1];

                    raceStates.Add(raceStateForFrame);
                }

                timeIndex++;
                time = timeIndex;
            }

            return raceStates;
        }

        private void buttonStartRace_Click(object sender, EventArgs e)
        {
            animationTaskCancellationSource = new CancellationTokenSource();

            animationTask = Task.Factory.StartNew(() => { AnimationTaskWholeRace(raceStates, animationTaskCancellationSource.Token); }, animationTaskCancellationSource.Token);

            buttonStartRace.Enabled = false;
            buttonStopRace.Enabled = true;

            animationTask.ContinueWith(t =>
            {
                buttonStartRace.Enabled = true;
                buttonStopRace.Enabled = false;
            }, TaskScheduler.FromCurrentSynchronizationContext());

        }

        private async void buttonStopRace_Click(object sender, EventArgs e)
        {
            animationTaskCancellationSource.Cancel();
            await animationTask;

            benchmarkStopWatch.Stop();

            labelBenchmark.Text = string.Format("{0}", benchmarkStopWatch.Elapsed.ToString());

            buttonStartRace.Enabled = true;
            buttonStopRace.Enabled = false;
        }
    }
}
