using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public abstract class Neuron : INeuron
    {
        public double Bias { get; set; }
        public double Output { get; private set; }

        public abstract double Input { get; }

        public void UpdateOutput()
        {
            double output;

            output = Input;

            output += Bias;

            output = 1.0 / (1.0 + Math.Exp(-output));

            Output = output;
        }
    }
}
