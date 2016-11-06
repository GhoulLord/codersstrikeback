using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetics
{
    public class Fitness : IComparable<Fitness>
    {
        public double TurnsNeededToFinish { get; set; }
        public double RoundsFinished { get; set; }
        public double CheckPointsReached { get; set; }
        public double DistanceToNextCheckPoint { get; set; }

        public Fitness()
        {
            TurnsNeededToFinish = Double.MaxValue;
            RoundsFinished = 0;
            CheckPointsReached = 0;
            DistanceToNextCheckPoint = Double.MaxValue;
        }

        public int CompareTo(Fitness other)
        {
            int subCompareResult;

            subCompareResult = other.TurnsNeededToFinish.CompareTo(TurnsNeededToFinish);
            if (subCompareResult != 0)
            {
                return subCompareResult;
            }

            subCompareResult = other.RoundsFinished.CompareTo(other.RoundsFinished);
            if (subCompareResult != 0)
            {
                return subCompareResult;
            }

            subCompareResult = CheckPointsReached.CompareTo(other.CheckPointsReached);
            if (subCompareResult != 0)
            {
                return subCompareResult;
            }

            subCompareResult = other.DistanceToNextCheckPoint.CompareTo(DistanceToNextCheckPoint);
            if (subCompareResult != 0)
            {
                return subCompareResult;
            }

            return 0;
        }
    }
}
