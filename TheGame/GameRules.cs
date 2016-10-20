using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class GameRules : IGameRules
    {
        private static readonly int ARENA_WIDTH = 16000;
        private static readonly int ARENA_HEIGHT = 9000;
        private static readonly int CHECKPOINT_RADIUS = 600;

        int IGameRules.CHECKPOINT_RADIUS { get { return CHECKPOINT_RADIUS; } }
        int IGameRules.ARENA_WIDTH { get { return ARENA_WIDTH; } }
        int IGameRules.ARENA_HEIGHT { get { return ARENA_HEIGHT; } }

        private static readonly Lazy<GameRules> lazy =
            new Lazy<GameRules>(() => new GameRules());

        public static GameRules Instance { get { return lazy.Value; } }

        private GameRules()
        {
        }
    }
}
