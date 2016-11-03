using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    [Serializable]
    public class HiddenLayer : NeuronLayer<HiddenNeuron>
    {
        public override HiddenNeuron CreateNeuron()
        {
            HiddenNeuron hiddenNeuron;

            hiddenNeuron = new HiddenNeuron();

            Neurons.Add(hiddenNeuron);

            return hiddenNeuron;
        }
    }
}
