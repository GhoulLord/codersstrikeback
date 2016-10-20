using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public interface IPilot
    {
        PodRacer PodRacer { get; set; }
        PodRacerCommand EvaluateCommand(Race race);
    }
}
