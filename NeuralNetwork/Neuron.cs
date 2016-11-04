using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    [Serializable]
    public abstract class Neuron : INeuron
    {
        public string Name { get; set; }
        public double Bias { get; set; }
        public double Output { get; private set; }

        public abstract double Input { get; }

        private double LogSigmoid(double z)
        {
            if (z < -20.0) return 0.0;
            else if (z > 20.0) return 1.0;
            else return 1.0 / (1.0 + Math.Exp(-z));
        }

        public void UpdateOutput()
        {
            double output;

            output = Input;

            output += Bias;

            output = LogSigmoid(output);

            Output = output;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
