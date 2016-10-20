using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class Collision
    {
        public double Time { get; set; }
        public Unit UnitA { get; set; }
        public Vector PositionUnitA { get; set; }
        public Vector VelocityUnitA { get; set; }
        public Unit UnitB { get; set; }
        public Vector PositionUnitB { get; set; }
        public Vector VelocityUnitB { get; set; }

        static private double CollisionTimeBetweenTwoUnits(Unit unitA, Unit unitB)
        {
            double time = double.NaN;

            double radiiSumSquared;

            if ((unitA is CheckPoint) || ((unitB is CheckPoint)))
            {
                if (unitA.Size > unitB.Size)
                {
                    radiiSumSquared = unitA.Size * unitA.Size;
                }
                else
                {
                    radiiSumSquared = unitB.Size * unitB.Size;
                }
            }
            else
            {
                radiiSumSquared = (unitA.Size + unitB.Size) * (unitA.Size + unitB.Size);
            }

            Vector relativePosition = unitA.Position - unitB.Position;
            Vector relativeVelocity = unitA.Velocity - unitB.Velocity;

            if (unitA.Velocity.IsEqual(unitB.Velocity))
            {
                return double.NaN;
            }

            if ((unitA is PodRacer) && (unitB is PodRacer))
            {
                if (relativePosition.LengthSquared - radiiSumSquared < 0)
                {
                    double distanceDelta = relativePosition.Length / (unitA.Size + unitB.Size);
                    double subTime;
                    PodRacer unitAShrinked;
                    PodRacer unitBShrinked;

                    unitAShrinked = new PodRacer(unitA as PodRacer);
                    unitAShrinked.Size -= distanceDelta * unitAShrinked.Size;
                    unitBShrinked = new PodRacer(unitB as PodRacer);
                    unitBShrinked.Size -= distanceDelta * unitBShrinked.Size;

                    subTime = CollisionTimeBetweenTwoUnits(unitAShrinked, unitBShrinked);

                    if (subTime > 0)
                    {
                        return subTime;
                    }
                    else
                    {
                        return double.NaN;
                    }
                }
            }

            double pHalf = (relativePosition * relativeVelocity) / relativeVelocity.LengthSquared;
            double q = (relativePosition.LengthSquared - radiiSumSquared) / relativeVelocity.LengthSquared;

            double pHalfSquared = pHalf * pHalf;

            if (pHalfSquared >= q)
            {
                time = -pHalf - Math.Sqrt(pHalfSquared - q);
            }

            return time;
        }

        static private Collision CollisionBetweenTwoUnits(Unit unitA, Unit unitB, double maxTime)
        {
            Collision collision = null;

            double collisionTime = CollisionTimeBetweenTwoUnits(unitA, unitB);

            if ((!double.IsNaN(collisionTime)) && (collisionTime >= 0.0) && (collisionTime <= maxTime))
            {
                collision = new Collision()
                {
                    Time = collisionTime,
                    UnitA = unitA,
                    PositionUnitA = unitA.PositionAfter(collisionTime),
                    VelocityUnitA = new Vector(unitA.Velocity),
                    UnitB = unitB,
                    PositionUnitB = unitB.PositionAfter(collisionTime),
                    VelocityUnitB = new Vector(unitB.Velocity)
                };
            }

            return collision;
        }

        static public List<Collision> CalculateCollisions(Race race, double maxTime)
        {
            List<Unit> units = race.Units;

            List<Collision> collisions = new List<Collision>();
            double earliestCollisionTime = Double.MaxValue;

            for (int unitAIndex = 0;
                unitAIndex < units.Count;
                unitAIndex++)
            {
                for (int unitBIndex = unitAIndex + 1;
                    unitBIndex < units.Count;
                    unitBIndex++)
                {
                    Collision collision = null;
                    Unit unitA = units[unitAIndex];
                    Unit unitB = units[unitBIndex];

                    if ((unitA is PodRacer) || (unitB is PodRacer))
                    {
                        if (!
                            (
                            (unitA is CheckPoint) && (race.RaceState.PodRacerRaceStates[(PodRacer)unitB].CurrentCheckPoint != (CheckPoint)unitA)
                            ||
                            (unitB is CheckPoint) && (race.RaceState.PodRacerRaceStates[(PodRacer)unitA].CurrentCheckPoint != (CheckPoint)unitB)
                            )
                            )
                        {
                            collision = CollisionBetweenTwoUnits(unitA, unitB, maxTime);
                        }

                        if (collision != null)
                        {
                            if (collision.Time < earliestCollisionTime)
                            {
                                earliestCollisionTime = collision.Time;
                                collisions.Clear();
                            }
                            if (collision.Time == earliestCollisionTime)
                            {
                                collisions.Add(collision);
                            }
                        }
                    }
                }
            }

            return collisions;

        }

    }
}
