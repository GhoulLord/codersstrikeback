using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    [Serializable]
    public class InputNeuron : Neuron
    {
        public override double Input { get { return inputValue; } }

        private double inputValue { get; set; }

        public void SetInput(double input)
        {
            inputValue = input;
        }
    }
}
