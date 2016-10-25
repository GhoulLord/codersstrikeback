using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class Arena
    {
        public int Width { get; set; }
        public int Height { get; set; }

        private List<CheckPoint> checkPoints = new List<CheckPoint>();
        public List<CheckPoint> CheckPoints { get { return checkPoints; } }

        public Arena(int width, int height)
        {
            Width = width;
            Height = 2 * height;
        }

        public void AddCheckPoint(CheckPoint checkPoint)
        {
            checkPoints.Add(checkPoint);
        }

        public CheckPoint CreateCheckPoint(int number, Vector position, int size)
        {
            CheckPoint newCheckPoint;

            newCheckPoint = new CheckPoint(number, position, size);
            AddCheckPoint(newCheckPoint);

            return newCheckPoint;
        }

        public CheckPoint GetStartFinish()
        {
            return checkPoints.FirstOrDefault();
        }

        public CheckPoint GetNextCheckPoint(CheckPoint checkPoint)
        {
            int checkPointIndex;
            int nextCheckPointIndex;
            
            checkPointIndex = checkPoints.IndexOf(checkPoint);
            nextCheckPointIndex = (checkPointIndex + 1) % checkPoints.Count;

            return checkPoints[nextCheckPointIndex];
        }
    }
}
