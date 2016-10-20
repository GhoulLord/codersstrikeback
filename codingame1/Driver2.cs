using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Driver2 : IDriver
{
    List<Point> checkpoints = new List<Point>();
    int nextCheckpointIndex = 0;
    int nextnextCheckpointIndex = 0;
    int targetCheckpointIndex = 0;
    int longestDistanceCheckpointIndex = 0;
    bool allCheckpointsKnown = false;
    Point lastCheckPoint = new Point() { X = -1, Y = -1 };
    bool boosted = false;

    public Command CalculateCommand(State state)
    {
        int x = state.X;
        int y = state.Y;
        int nextCheckpointX = state.NextCheckpointX;
        int nextCheckpointY = state.NextCheckpointY;
        int nextCheckpointDist = state.NextCheckpointDist;
        int nextCheckpointAngle = state.NextCheckpointAngle;
        int opponentX = state.OpponentX;
        int opponentY = state.OpponentY;

        int targetX = nextCheckpointX;
        int targetY = nextCheckpointY;
        int power = 80;

        if (!allCheckpointsKnown)
        {
            if ((lastCheckPoint.X != nextCheckpointX) || (lastCheckPoint.Y != nextCheckpointY))
            {
                lastCheckPoint.X = nextCheckpointX;
                lastCheckPoint.Y = nextCheckpointY;

                if (checkpoints.Count > 0)
                {
                    if ((checkpoints[0].X == nextCheckpointX) && (checkpoints[0].Y == nextCheckpointY))
                    {
                        nextCheckpointIndex = 0;
                        targetCheckpointIndex = 0;
                        allCheckpointsKnown = true;

                        int longestDistance;
                        int distance;
                        int dx = (int)(checkpoints[0].X - checkpoints[checkpoints.Count - 1].X);
                        int dy = (int)(checkpoints[0].Y - checkpoints[checkpoints.Count - 1].Y);

                        longestDistance = dx * dx + dy * dy;
                        longestDistanceCheckpointIndex = 0;

                        for (int index = 1; index < checkpoints.Count; index++)
                        {
                            dx = (int)(checkpoints[index].X - checkpoints[index - 1].X);
                            dy = (int)(checkpoints[index].Y - checkpoints[index - 1].Y);

                            distance = dx * dx + dy * dy;

                            if (distance > longestDistance)
                            {
                                longestDistance = distance;
                                longestDistanceCheckpointIndex = index;
                            }
                        }

                        foreach (Point p in checkpoints)
                        {
                            Console.Error.WriteLine("{0}/{1}", p.X, p.Y);
                        }
                    }
                }

                if (!allCheckpointsKnown)
                {
                    Point newP = new Point() { X = nextCheckpointX, Y = nextCheckpointY };
                    checkpoints.Add(newP);
                }
            }
        }

        if (allCheckpointsKnown)
        {
            for (int index = 0; index < checkpoints.Count; index++)
            {
                if (checkpoints[index].X == nextCheckpointX && checkpoints[index].Y == nextCheckpointY)
                {
                    nextCheckpointIndex = index;
                    nextnextCheckpointIndex = (nextCheckpointIndex + 1) % checkpoints.Count;
                    break;
                }
            }
        }


        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");


        // You have to output the target position
        // followed by the power (0 <= thrust <= 100)
        // i.e.: "x y thrust"

        int correctedDistance = nextCheckpointDist - 0;

        if (correctedDistance < 0)
        {
            correctedDistance = 0;
        }

        if (!allCheckpointsKnown)
        {
            if (Math.Abs(nextCheckpointAngle) < 30)
            {
                if (correctedDistance > 5000)
                {
                    power = 100;
                }
                else
                {
                    power = 25 + (int)(75.0 * (1.0 - (5000.0 - (double)correctedDistance) / 5000.0));
                }
            }
            else
            {
                power = 0;
            }
        }
        else
        {
            if (correctedDistance > 5000)
            {
                power = 100;
            }
            else
            {
                power = 50 + (int)(50.0 * (1.0 - (5000.0 - (double)correctedDistance) / 5000.0));
            }
        }

        if (allCheckpointsKnown)
        {
            if (correctedDistance < 1500)
            {
                targetCheckpointIndex = nextnextCheckpointIndex;
            }
            else
            {
                targetCheckpointIndex = nextCheckpointIndex;
            }

            targetX = (int)checkpoints[targetCheckpointIndex].X;
            targetY = (int)checkpoints[targetCheckpointIndex].Y;
        }

        Console.Error.WriteLine("{0}({1},{2}),{3}", targetCheckpointIndex, nextCheckpointIndex, nextnextCheckpointIndex, correctedDistance);

        if (!boosted && allCheckpointsKnown && (nextCheckpointIndex == longestDistanceCheckpointIndex))
        {
            if (Math.Abs(nextCheckpointAngle) < 5)
            {
                boosted = true;
                return new Command() { Destination = targetX + " " + targetY, Power = "BOOST" };
            }
            else
            {
                return new Command() { Destination = targetX + " " + targetY, Power = "" + power };
            }
        }
        else
        {
            return new Command() { Destination = targetX + " " + targetY, Power = "" + power };
        }
    }
}
