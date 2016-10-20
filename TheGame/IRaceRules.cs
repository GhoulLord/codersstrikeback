using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public interface IRaceRules
    {
        int TIMEOUT { get; }
        double MIN_HALF_IMPULSE { get; }
        int SHIELD_PENALTY_ROUNDS { get; }
        int RACE_LENGTH { get; }
        int INITIAL_POSITION_OFFSET { get; }        
    }
}
