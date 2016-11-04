using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    [Serializable]
    public class OutputLayer : NeuronLayer<OutputNeuron>
    {
        public override OutputNeuron CreateNeuron(string name)
        {
            OutputNeuron outputNeuron;

            outputNeuron = new OutputNeuron(name);

            Neurons.Add(outputNeuron);

            return outputNeuron;
        }
    }
}
