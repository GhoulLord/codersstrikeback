using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGame;

namespace TheGameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Game game = new Game(GameRules.Instance);

            //Team playerA;
            //Team playerB;

            //List<Vector> checkPointPositions = new List<Vector>()
            //{
            //    /* 16000x9000 */
            //    new Vector(3000, 3000),
            //    new Vector(10000, 1000),
            //    new Vector(5000, 6000),
            //};

            //List<Team> teams = new List<Team>();
            //List<CheckPoint> checkPoints = new List<CheckPoint>();

            //playerA = game.CreateTeam("A");
            //teams.Add(playerA);
            //playerB = game.CreateTeam("B");
            //teams.Add(playerB);

            //int checkPointIndex = 0;

            //foreach (var checkPointPosition in checkPointPositions)
            //{
            //    checkPoints.Add(game.CreateCheckPoint(checkPointIndex, checkPointPosition));
            //    checkPointIndex++;
            //}

            //Dictionary<Team, List<PodRacer>> podRacers = new Dictionary<Team, List<PodRacer>>();

            //List<PodRacer> podRacersForPlayer;
            //PodRacer podRacerA;
            //PodRacer podRacerB;

            //podRacersForPlayer = new List<PodRacer>();
            //podRacerA = game.CreatePodRacer(
            //    playerA,
            //    0,
            //    new Vector(
            //        5000,
            //        1000
            //    ),
            //        90
            //        );
            //podRacerB = game.CreatePodRacer(
            //    playerA,
            //    1,
            //    new Vector(
            //        5000,
            //        9000
            //    ),
            //        270
            //        );

            //podRacersForPlayer.Add(podRacerA);
            //podRacersForPlayer.Add(podRacerB);
            //podRacers.Add(playerA, podRacersForPlayer);

            //podRacersForPlayer = new List<PodRacer>();
            //podRacerA = game.CreatePodRacer(
            //    playerB,
            //    1,
            //    new Vector(
            //        9000,
            //        5000
            //    ),
            //        180
            //        );
            //podRacerB = game.CreatePodRacer(
            //    playerB,
            //    2,
            //    new Vector(
            //        1000,
            //        5000
            //    ),
            //        0
            //        );

            //podRacersForPlayer.Add(podRacerA);
            //podRacersForPlayer.Add(podRacerB);
            //podRacers.Add(playerB, podRacersForPlayer);

            //Console.WriteLine(game.CreateGameStateString());

            //Dictionary<PodRacer, PodRacerCommand> commands = new Dictionary<PodRacer, PodRacerCommand>();

            //commands.Add(podRacers[playerA][0], new PodRacerCommand() { Thrust = 100, Destination = new Vector(5000, 5000) });
            //commands.Add(podRacers[playerA][1], new PodRacerCommand() { Thrust = 100, Destination = new Vector(5000, 5000) });
            //commands.Add(podRacers[playerB][0], new PodRacerCommand() { Thrust = 100, Destination = new Vector(5000, 5000) });
            //commands.Add(podRacers[playerB][1], new PodRacerCommand() { Thrust = 100, Destination = new Vector(5000, 5000) });

            //for (int round = 0; round < 20; round++)
            //{
            //    game.SimulatePreRound();
            //    for (int i = 0; i < 25; i++)
            //    {
            //        game.SimulateRound(1.0/25);

            //        if (i < 24)
            //        {
            //            Console.WriteLine(game.CreateGameStateString());
            //        }
            //    }
            //    game.SimulatePostRound();
            //    Console.WriteLine(game.CreateGameStateString());
            //}

            //Console.ReadKey();
        }
    }
}
