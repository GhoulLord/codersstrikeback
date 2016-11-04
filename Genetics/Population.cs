using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetics
{
    [Serializable]
    public class Population
    {
        public static Random r = new Random();

        public List<Individual> Individuals { get; set; }

        private Individual GetRandomIndividualByFitnessProbability(IEnumerable<Individual> individualsSortedByFitness, double fitnessSum)
        {
            double targetFitness = r.NextDouble() * fitnessSum;

            double fitness = 0;

            Individual individual = individualsSortedByFitness.SkipWhile(i => { if (fitness >= targetFitness) return true; fitness += i.Fitness; return false; }).First();

            return individual;
        }

        public void Breed()
        {
            IEnumerable<Individual> individualsSortedByFitness;
            double fitnessSum;

            individualsSortedByFitness = Individuals.OrderBy(i => i.Fitness);
            fitnessSum = Individuals.Sum(i => i.Fitness);

            List<Individual> newIndividuals = new List<Individual>();

            while (newIndividuals.Count < Individuals.Count)
            {
                Individual mum = GetRandomIndividualByFitnessProbability(individualsSortedByFitness, fitnessSum);
                Individual dad = GetRandomIndividualByFitnessProbability(individualsSortedByFitness, fitnessSum);

                Individual[] babies = Combinator.Combine(mum, dad);

                Individual babyA = new Individual(Mutator.Mutate(babies[0].Genom, 0.05, 2));
                Individual babyB = new Individual(Mutator.Mutate(babies[1].Genom, 0.05, 2));

                newIndividuals.Add(babyA);
                newIndividuals.Add(babyB);
            }
        }
    }
}
