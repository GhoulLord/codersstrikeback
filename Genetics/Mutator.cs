using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetics
{
    public class Mutator
    {
        private static Random r = new Random();

        public static Genom Mutate(Genom genom, double rate, double strength)
        {
            Genom mutatedGenom = new Genom(genom);

            mutatedGenom.Gens.ForEach(g => { if (r.NextDouble() < rate) g += (r.NextDouble() - r.NextDouble()) * strength; });

            return mutatedGenom;
        }
    }
}
