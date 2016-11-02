using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class OutputNeuron : Neuron
    {
        public List<Axon> Inputs { get; set; }
        public override double Input { get { return CalculateInput(); } }

        private double CalculateInput()
        {
            double input;

            input = 0;

            int axonCount = Inputs.Count;

            for (int neuronIndex = 0; neuronIndex < axonCount; neuronIndex++)
            {
                input += Inputs[neuronIndex].Input.Output * Inputs[neuronIndex].Weight;
            }

            return input;
        }
    }
}
