using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class PodRacerRaceState
    {
        public PodRacer PodRacer { get; set; }
        public PodRacerCommand CurrentCommand { get; set; }
        public int ShieldPenaltyRoundsCounter { get; set; }
        public bool HasBoosted { get; set; }
        public bool Failed { get; set; }
        public CheckPoint CurrentCheckPoint { get; set; }
        public int RoundsFinished { get; set; }

        public PodRacerRaceState(PodRacer podRacer)
        {
            PodRacer = podRacer;
            CurrentCommand = null;
            ShieldPenaltyRoundsCounter = 0;
            HasBoosted = false;
            Failed = false;
            CurrentCheckPoint = null;
            RoundsFinished = 0;
        }

        public PodRacerRaceState Copy()
        {
            PodRacerRaceState copy;

            copy = new PodRacerRaceState(PodRacer.Copy())
            {
                CurrentCommand = CurrentCommand.Copy(),
                ShieldPenaltyRoundsCounter = ShieldPenaltyRoundsCounter,
                HasBoosted = HasBoosted,
                Failed = Failed,
                CurrentCheckPoint = CurrentCheckPoint.Copy(),
                RoundsFinished = RoundsFinished,
            };

            return copy;
        }
    }
}
