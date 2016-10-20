﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class PodRacerRaceState
    {
        public PodRacerCommand CurrentCommand { get; set; }
        public int ShieldPenaltyRoundsCounter { get; set; }
        public bool HasBoosted { get; set; }
        public bool Failed { get; set; }
        public CheckPoint CurrentCheckPoint { get; set; }
        public int RoundsFinished { get; set; }

        public PodRacerRaceState()
        {
            CurrentCommand = null;
            ShieldPenaltyRoundsCounter = 0;
            HasBoosted = false;
            Failed = false;
            CurrentCheckPoint = null;
            RoundsFinished = 0;
        }
    }
}
