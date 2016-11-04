using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetics
{
    public class Combinator
    {
        private static Random r = new Random();

        public static Individual[] Combine(Individual mum, Individual dad)
        {
            Individual babyA;
            Individual babyB;

            Genom genomA;
            Genom genomB;

            genomA = new Genom(mum.Genom);
            genomB = new Genom(dad.Genom);

            if (mum != dad)
            {
                int genDistance = r.Next(mum.Genom.Gens.Count);

                for (int genIndex = genDistance; genIndex < mum.Genom.Gens.Count; genIndex++)
                {
                    double genA = genomA.Gens[genIndex];

                    genomA.Gens[genIndex] = genomB.Gens[genIndex];
                    genomB.Gens[genIndex] = genA;
                }
            }

            babyA = new Individual(genomA);
            babyB = new Individual(genomB);

            return new Individual[] { babyA, babyB };
        }
    }
}
