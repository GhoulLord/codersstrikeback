using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class Driver : IDriver
{
    bool first = true;
    Vector lastPosition;

    public Command CalculateCommand(State state)
    {
        Vector position = new Vector() { X = state.X, Y = state.Y };

        int nextCheckpointX = state.NextCheckpointX;
        int nextCheckpointY = state.NextCheckpointY;
        int nextCheckpointDist = state.NextCheckpointDist;
        int nextCheckpointAngle = state.NextCheckpointAngle;
        int opponentX = state.OpponentX;
        int opponentY = state.OpponentY;

        double power = 100;
        bool boost = false;
        bool boosted = false;

        Vector target = new Vector() { X = nextCheckpointX, Y = nextCheckpointY };

        if (!first)
        {
            Vector speed = position - lastPosition;

            Console.Error.WriteLine("v:{0}", speed);

            Vector pt = target - position;

            Vector speedProjection = speed.Project(pt);

            if (speedProjection * pt < 0)
            {
                speedProjection = -speedProjection;
            }

            Vector speedMirrored = 2 * speedProjection - speed;

            speedMirrored = speedMirrored.Normalize() * 1000;

            Console.Error.WriteLine("vorth:{0}", speedMirrored);

            target = position + speedMirrored;
        }
        else
        {
            first = false;
            boost = true;
            boosted = true;
        }

        lastPosition = position;

        if (nextCheckpointDist < 2000)
        {
            power = (double)nextCheckpointDist / 2000 * 50 + 50;
        }
        if (Math.Abs(nextCheckpointAngle) > 90)
        {
            power = 50;
        }

        Console.Error.WriteLine("o:{0}/{1}", nextCheckpointAngle, nextCheckpointDist);

        if (boost)
        {
            return new Command() { Destination = string.Format("{0} {1}", (int)Math.Round(target.X), (int)Math.Round(target.Y)), Power = string.Format("{0}", "BOOST") };
        }
        else
        {
            return new Command() { Destination = string.Format("{0} {1}", (int)Math.Round(target.X), (int)Math.Round(target.Y)), Power = string.Format("{0}", (int)Math.Round(power)) };
        }
    }
}
