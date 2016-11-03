using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    [Serializable]
    public class Axon
    {
        public INeuron Input { get; set; }
        public double Weight { get; set; }

        public Axon(Neuron input, double weight)
        {
            Input = input;
            Weight = weight;
        }
    }
}
