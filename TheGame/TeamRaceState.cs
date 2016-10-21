using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class TeamRaceState
    {
        public int Timeout { get; set; }
        public bool FinishedRace { get; set; }
        public bool Disqualified { get; set; }

        public TeamRaceState()
        {
            Timeout = 0;
            FinishedRace = false;
            Disqualified = false;
        }

        public TeamRaceState Copy()
        {
            TeamRaceState copy;

            copy = new TeamRaceState();

            copy.Timeout = Timeout;
            copy.FinishedRace = FinishedRace;
            copy.Disqualified = Disqualified;

            return copy;
        }
    }
}
