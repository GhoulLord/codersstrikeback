using System;
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
using NeuralNetwork;
using Genetics;

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
            bestNn = NeuralNetwork.Storage.ReadNeuralNetworkFromFile(@"c:\temp\scored10.bin");

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
                new PilotC(bestNn),
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

        List<RaceState> raceStates = null;

        private double CalculateScoreForPodRacer(PodRacer podRacer)
        {
            double score = 0;

            PodRacerRaceState podRacerRaceState = race.RaceState.PodRacerRaceStates[podRacer];

            score += podRacerRaceState.CheckPointsReached * 10000;

            Vector vectorToCurrentCheckPoint = podRacer.Position - podRacerRaceState.CurrentCheckPoint.Position;

            score += 10000 - Math.Min(vectorToCurrentCheckPoint.Length, 10000);

            return score;
        }

        private void buttonExecuteRace_Click(object sender, EventArgs e)
        {
            RaceResult result;

            result = race.ExecuteRace();

            benchmarkStopWatch = new Stopwatch();
            benchmarkStopWatch.Start();

            raceStates = GenerateRaceStatesFor25FPS(result);

            currentRaceRound = 0;
            currentRaceStateIndex = 0;

            labelScore.Text = CalculateScoreForPodRacer(race.PodRacers[0]).ToString();
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

        NeuralNetwork.NeuralNetwork bestNn = null;

        private void FillWeightsWithGenom(NeuralNetwork.NeuralNetwork nn, Genom genom)
        {
            int genIndex = 0;

            foreach (var intputNeuron in nn.InputLayer.Neurons.Cast<InputNeuron>())
            {
                intputNeuron.Bias = genom.Gens[genIndex];
                genIndex++;
            }

            foreach (var hiddenLayer in nn.HiddenLayers)
            {
                foreach (var hiddenNeuron in hiddenLayer.Neurons.Cast<HiddenNeuron>())
                {
                    hiddenNeuron.Bias = genom.Gens[genIndex];
                    genIndex++;

                    foreach (var axon in hiddenNeuron.Inputs)
                    {
                        axon.Weight = genom.Gens[genIndex];
                        genIndex++;
                    }
                }
            }

            foreach (var outputNeuron in nn.OutputLayer.Neurons.Cast<OutputNeuron>())
            {
                outputNeuron.Bias = genom.Gens[genIndex];
                genIndex++;

                foreach (var axon in outputNeuron.Inputs)
                {
                    axon.Weight = genom.Gens[genIndex];
                    genIndex++;
                }
            }
        }

        private void FillGenomWithWeights(Genom genom, NeuralNetwork.NeuralNetwork nn)
        {
            int genIndex = 0;

            foreach (var intputNeuron in nn.InputLayer.Neurons.Cast<InputNeuron>())
            {
                genom.Gens[genIndex] = intputNeuron.Bias;
                genIndex++;
            }

            foreach (var hiddenLayer in nn.HiddenLayers)
            {
                foreach (var hiddenNeuron in hiddenLayer.Neurons.Cast<HiddenNeuron>())
                {
                    genom.Gens[genIndex] = hiddenNeuron.Bias;
                    genIndex++;

                    foreach (var axon in hiddenNeuron.Inputs)
                    {
                        genom.Gens[genIndex] = axon.Weight;
                        genIndex++;
                    }
                }
            }

            foreach (var outputNeuron in nn.OutputLayer.Neurons.Cast<OutputNeuron>())
            {
                genom.Gens[genIndex] = outputNeuron.Bias;
                genIndex++;

                foreach (var axon in outputNeuron.Inputs)
                {
                    genom.Gens[genIndex] = axon.Weight;
                    genIndex++;
                }
            }
        }

        protected void InitRace(Individual individual)
        {
            race = game.CreateRace(0);

            FillWeightsWithGenom(((PilotC)race.Teams[0].PodRacers[0].Pilot).nn, individual.Genom);
        }

        private void SearchTask(CancellationToken cancellationToken)
        {
            Population population;

            population = new Population();

            for (int individualIndex = 0; individualIndex < 100; individualIndex++)
            {
                population.Individuals.Add(new Individual(2 + 32 + 16 + 96 + 6));
            }

            FillGenomWithWeights(population.Individuals[0].Genom, bestNn);

            RaceResult result;
            double score = 0;

            int generationsCount = 0;
            double maxScore = -1;

            while (maxScore < 50000)
            {
                foreach (var individual in population.Individuals)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }

                    generationsCount++;

                    InitRace(individual);

                    result = race.ExecuteRace();

                    score = CalculateScoreForPodRacer(race.PodRacers[0]);

                    individual.Fitness = score;

                    if (maxScore < score)
                    {
                        maxScore = score;
                        NeuralNetwork.Storage.WriteNeuralNetworkToFile(((PilotC)(race.PodRacers[0].Pilot)).nn, @"c:\temp\scored11.bin");
                    }
                }

                UpdateSearchData(maxScore, generationsCount, population.AverageFitness());

                if (maxScore < 50000)
                {
                    population.Breed();
                }
            }

            bestNn = NeuralNetwork.Storage.ReadNeuralNetworkFromFile(@"c:\temp\scored11.bin");
        }

        CancellationTokenSource searchTaskCancellationSource = null;

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Task searchTask;

            searchTaskCancellationSource = new CancellationTokenSource();

            searchTask = Task.Factory.StartNew(() => { SearchTask(searchTaskCancellationSource.Token); }, searchTaskCancellationSource.Token);
        }

        private void UpdateSearchData(double score, int generationsCount, double avg)
        {
            if (labelScore.InvokeRequired)
            {
                labelScore.Invoke(new MethodInvoker(() => { UpdateSearchData(score, generationsCount, avg); }));
                return;
            }

            labelScore.Text = score.ToString();
            labelScoreAverage.Text = avg.ToString();
            labelGenerations.Text = generationsCount.ToString();
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            InitGame();

            raceStates = null;

            race = game.CreateRace(0);

            UpdateUi(race.RaceState);

        }

        private void buttonStopSearch_Click(object sender, EventArgs e)
        {
            searchTaskCancellationSource.Cancel();
        }
    }
}
