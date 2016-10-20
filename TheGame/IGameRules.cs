using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public interface IGameRules
    {
        int ARENA_WIDTH { get; }
        int ARENA_HEIGHT { get; }
        int CHECKPOINT_RADIUS { get; }
    }
}
