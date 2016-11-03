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
        public override OutputNeuron CreateNeuron()
        {
            OutputNeuron outputNeuron;

            outputNeuron = new OutputNeuron();

            Neurons.Add(outputNeuron);

            return outputNeuron;
        }
    }
}
