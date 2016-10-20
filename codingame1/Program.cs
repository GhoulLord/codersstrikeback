using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
public class Command
{
    public String Destination { get; set; }
    public String Power { get; set; }

    public override string ToString()
    {
        return string.Format("({0})-{1}", Destination, Power);
    }
}

public class State
{
    public int X { get; set; }
    public int Y { get; set; }
    public int NextCheckpointX { get; set; }
    public int NextCheckpointY { get; set; }
    public int NextCheckpointDist { get; set; }
    public int NextCheckpointAngle { get; set; }
    public int OpponentX { get; set; }
    public int OpponentY { get; set; }
}

public interface IDriver
{
    Command CalculateCommand(State state);
}

public struct Point
{
    public double X { get; set; }
    public double Y { get; set; }
}

public struct Vector
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Length { get { return Math.Sqrt(LengthSquared); } }
    public double LengthSquared { get { return X * X + Y * Y; } }

    public Vector Project(Vector projectOn)
    {
        Vector projectedVector;
        Vector projectOnNormalized = projectOn.Normalize();
        projectedVector = (this * projectOnNormalized) * projectOnNormalized;

        return projectedVector;
    }

    public Vector Normalize()
    {
        return this / Length;
    }

    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector() { X = a.X + b.X, Y = a.Y + b.Y };
    }

    public static Vector operator -(Vector a, Vector b)
    {
        return new Vector() { X = a.X - b.X, Y = a.Y - b.Y };
    }

    public static Vector operator -(Vector a)
    {
        return new Vector() { X = -a.X, Y = -a.Y };
    }

    public static double operator *(Vector a, Vector b)
    {
        return a.X * b.X + a.Y * b.Y;
    }

    public static Vector operator *(double r, Vector a)
    {
        return new Vector() { X = r * a.X, Y = r * a.Y };
    }

    public static Vector operator *(Vector a, double r)
    {
        return r * a;
    }

    public static Vector operator /(Vector a, double r)
    {
        return (1 / r) * a;
    }

    public static Vector operator *(Matrix m, Vector v)
    {
        return new Vector() { X = m.M11 * v.X + m.M12 * v.Y, Y = m.M21 * v.X + m.M22 * v.Y };
    }

    public override string ToString()
    {
        return string.Format("{0:0.00}/{1:0.00}({2:0.00})", X, Y, Length);
    }
}

public struct Matrix
{
    public double M11 { get; set; }
    public double M12 { get; set; }
    public double M21 { get; set; }
    public double M22 { get; set; }

    public static Matrix operator +(Matrix a, Matrix b)
    {
        return new Matrix() { M11 = a.M11 + b.M11, M12 = a.M12 + b.M12, M21 = a.M21 + b.M21, M22 = a.M22 + b.M22 };
    }

    public override string ToString()
    {
        return string.Format("(({0:0.00}, {1:0.00}), ({2:0.00}, {3:0.00}))", M11, M12, M21, M22);
    }
}

class Player
{
    static State CreateState(string line1, string line2)
    {
        State state;

        string[] inputs1 = line1.Split(' ');
        string[] inputs2 = line2.Split(' ');

        int x = int.Parse(inputs1[0]);
        int y = int.Parse(inputs1[1]);
        int nextCheckpointX = int.Parse(inputs1[2]);
        int nextCheckpointY = int.Parse(inputs1[3]);
        int nextCheckpointDist = int.Parse(inputs1[4]);
        int nextCheckpointAngle = int.Parse(inputs1[5]);
        int opponentX = int.Parse(inputs2[0]);
        int opponentY = int.Parse(inputs2[1]);

        state = new State()
        {
            X = x,
            Y = y,
            NextCheckpointX = nextCheckpointX,
            NextCheckpointY = nextCheckpointY,
            NextCheckpointDist = nextCheckpointDist,
            NextCheckpointAngle = nextCheckpointAngle,
            OpponentX = opponentX,
            OpponentY = opponentY
        };

        return state;
    }

    static void Main(string[] args)
    {

        IDriver driver;

        driver = new Driver();

        // game loop
        //while (true)
        {
            string line1 = "100 100 1000 0 1000 0";
            string line2 = "0 0";
            State state = CreateState(line1, line2);

            Command command = driver.CalculateCommand(state);

            Console.WriteLine(command.Destination + " " + command.Power);

            line1 = "0 0 1000 0 1000 0";
            line2 = "0 0";
            state = CreateState(line1, line2);

            command = driver.CalculateCommand(state);

            Console.WriteLine(command.Destination + " " + command.Power);
        }

        //Console.ReadKey();
    }
}