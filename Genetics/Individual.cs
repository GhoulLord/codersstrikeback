using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetics
{
    [Serializable]
    public class Individual
    {
        public Genom Genom { get; set; }
        public double Fitness { get; set; }

        public Individual(Genom genom)
        {
            Fitness = 0;
            Genom = genom;
        }
    }
}
