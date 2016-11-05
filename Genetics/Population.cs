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

        public Population()
        {
            Individuals = new List<Individual>();
        }

        private Individual GetRandomIndividualByFitnessProbability(IEnumerable<Individual> individualsSortedByFitness, double fitnessSum)
        {
            double targetFitness = r.NextDouble() * fitnessSum;

            double fitness = 0;

            Individual individual = individualsSortedByFitness.SkipWhile(i => { if ((fitness + i.Fitness) >= targetFitness) return false; fitness += i.Fitness; return true; }).FirstOrDefault();

            return individual;
        }

        public void Breed()
        {
            IEnumerable<Individual> individualsSortedByFitness;
            double fitnessSum;

            individualsSortedByFitness = Individuals.OrderByDescending(i => i.Fitness);
            fitnessSum = Individuals.Sum(i => i.Fitness);

            List<Individual> newIndividuals = new List<Individual>();

            newIndividuals.AddRange(individualsSortedByFitness.Take(10));

            while (newIndividuals.Count < (Individuals.Count - 10))
            {
                Individual mum = GetRandomIndividualByFitnessProbability(individualsSortedByFitness, fitnessSum);
                Individual dad = GetRandomIndividualByFitnessProbability(individualsSortedByFitness, fitnessSum);

                Individual[] babies = Combinator.Combine(mum, dad);

                Individual babyA = new Individual(Mutator.Mutate(babies[0].Genom, 0.1, 0.5));
                Individual babyB = new Individual(Mutator.Mutate(babies[1].Genom, 0.1, 0.5));

                newIndividuals.Add(babyA);
                newIndividuals.Add(babyB);
            }


            newIndividuals.Add(new Individual(2 + 32 + 16 + 96 + 6));
            newIndividuals.Add(new Individual(2 + 32 + 16 + 96 + 6));
            newIndividuals.Add(new Individual(2 + 32 + 16 + 96 + 6));
            newIndividuals.Add(new Individual(2 + 32 + 16 + 96 + 6));
            newIndividuals.Add(new Individual(2 + 32 + 16 + 96 + 6));
            newIndividuals.Add(new Individual(2 + 32 + 16 + 96 + 6));
            newIndividuals.Add(new Individual(2 + 32 + 16 + 96 + 6));
            newIndividuals.Add(new Individual(2 + 32 + 16 + 96 + 6));
            newIndividuals.Add(new Individual(2 + 32 + 16 + 96 + 6));
            newIndividuals.Add(new Individual(2 + 32 + 16 + 96 + 6));

            Individuals = newIndividuals;


        }

        public double MaxFitness()
        {
            return Individuals.Max(i => i.Fitness);
        }

        public double AverageFitness()
        {
            return Individuals.Average(i => i.Fitness);
        }
    }
}
