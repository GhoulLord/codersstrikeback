using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class PodRacerRoundResult
    {
        public int RoundsFinished { get; set; }
        public bool GameWon { get; set; }
        public Vector Position { get; set; }
        public CheckPoint CurrentCheckPoint { get; set; }
    }
}
