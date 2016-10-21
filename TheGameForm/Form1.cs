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
        private Team teamB;
        private IPilot pilotTeamA;
        private IPilot pilotTeamB;
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
            teamB = game.CreateTeam("B", Color.Green);
            players.Add(teamB);

            pilotTeamA = new PilotA();
            pilotTeamB = new PilotA();

            PodRacer podRacerA = null;
            PodRacer podRacerB = null;
            List<PodRacer> podRacersForPlayer;

            podRacersForPlayer = new List<PodRacer>();
            podRacerA = game.CreatePodRacer(
                teamA,
                0,
                pilotTeamA,
                new Vector(
                    5000,
                    1000
                ),
                    90
                    );
            podRacerB = game.CreatePodRacer(
                teamA,
                1,
                pilotTeamA,
                new Vector(
                    5000,
                    9000
                ),
                    270
                    );

            podRacersForPlayer.Add(podRacerA);
            podRacersForPlayer.Add(podRacerB);
            podRacers.Add(teamA, podRacersForPlayer);

            podRacersForPlayer = new List<PodRacer>();
            podRacerA = game.CreatePodRacer(
                teamB,
                2,
                pilotTeamB,
                new Vector(
                    9000,
                    5000
                ),
                    180
                    );
            podRacerB = game.CreatePodRacer(
                teamB,
                3,
                pilotTeamB,
                new Vector(
                    1000,
                    5000
                ),
                    0
                    );

            podRacersForPlayer.Add(podRacerA);
            podRacersForPlayer.Add(podRacerB);
            podRacers.Add(teamB, podRacersForPlayer);

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
            race = game.CreateRace(0);

            UpdateUi();
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
            race = game.CreateRace(1);

            UpdateUi();
        }

        private void UpdateUi()
        {
            if (gameArena.InvokeRequired)
            {
                gameArena.Invoke(new MethodInvoker(() => { UpdateUi(); }));
                return;
            }

            gameArena.Refresh();

            labelRound.Text = race.RaceState.Round.ToString();
            labelTime.Text = string.Format("{0,8:0.000}", race.RaceState.Time);

            //labelPlayerARounds.Text = game.GetGameState().PlayerGameStates[playerA].RoundsFinished.ToString();
            labelPlayerATimeout.Text = race.RaceState.TeamRaceStates[teamA].Timeout.ToString();
            //labelPlayerBRounds.Text = game.GetGameState().PlayerGameStates[playerB].RoundsFinished.ToString();
            labelPlayerBTimeout.Text = race.RaceState.TeamRaceStates[teamB].Timeout.ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {
            RaceResult result;

            result = race.ExecuteRace();

            UpdateUi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            race.ExecuteRace();

            UpdateUi();
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

        private void button5_Click(object sender, EventArgs e)
        {
            DoNRounds(47);
            //for (int i = 0; i < 9; i++)
            //{
            //    DoOneFrame();
            //}
        }

        Task animationTask = null;
        CancellationTokenSource animationTaskCancellationSource = null;

        private void AnimationTask(RaceResult result, CancellationToken cancellationToken)
        {
            foreach (var raceState in result.RaceStates)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                gameArena.SetRaceState(raceState);
                UpdateUi();

                Thread.Sleep(25);
            }
        }

        Stopwatch benchmarkStopWatch;
        
        private void buttonStartRace_Click(object sender, EventArgs e)
        {
            RaceResult result;

            result = race.ExecuteRace();

            animationTaskCancellationSource = new CancellationTokenSource();

            benchmarkStopWatch = new Stopwatch();
            benchmarkStopWatch.Start();

            animationTask = Task.Factory.StartNew(() => { AnimationTask(result, animationTaskCancellationSource.Token); }, animationTaskCancellationSource.Token);

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
