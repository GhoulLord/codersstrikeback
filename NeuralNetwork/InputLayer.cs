using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    [Serializable]
    public class InputLayer : NeuronLayer<InputNeuron>
    {
        public override InputNeuron CreateNeuron()
        {
            InputNeuron inputNeuron;

            inputNeuron = new InputNeuron();

            Neurons.Add(inputNeuron);

            return inputNeuron;
        }
    }
}
