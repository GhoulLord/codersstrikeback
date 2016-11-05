using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetics
{
    [Serializable]
    public class Genom
    {
        private static Random r = new Random();

        public List<double> Gens { get; set; }

        public Genom(Genom g)
        {
            Gens = new List<double>(g.Gens);
        }

        public Genom(int genomSize, double randomness)
        {
            Gens = new List<double>();

            for (int genIndex = 0; genIndex < genomSize; genIndex++)
            {
                Gens.Add((r.NextDouble() - r.NextDouble()) * randomness);
            }
        }
    }
}
