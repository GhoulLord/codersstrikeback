using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class RaceRules : IRaceRules
    {
        private static readonly int TIMEOUT = 100;
        private static readonly double MIN_HALF_IMPULSE = 120;
        private static readonly int SHIELD_PENALTY_ROUNDS = 3;
        private static readonly int RACE_LENGTH = 3;
        private static readonly int INITIAL_POSITION_OFFSET = 50;
        
        int IRaceRules.TIMEOUT { get { return TIMEOUT; } }
        double IRaceRules.MIN_HALF_IMPULSE { get { return MIN_HALF_IMPULSE; } }
        int IRaceRules.SHIELD_PENALTY_ROUNDS { get { return SHIELD_PENALTY_ROUNDS; } }
        int IRaceRules.RACE_LENGTH { get { return RACE_LENGTH; } }
        int IRaceRules.INITIAL_POSITION_OFFSET { get { return INITIAL_POSITION_OFFSET; } }

        private static readonly Lazy<RaceRules> lazy =
            new Lazy<RaceRules>(() => new RaceRules());

        public static RaceRules Instance { get { return lazy.Value; } }

        private RaceRules()
        {
        }
    }
}
