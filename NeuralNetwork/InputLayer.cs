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
        public override InputNeuron CreateNeuron(string name)
        {
            InputNeuron inputNeuron;

            inputNeuron = new InputNeuron(name);

            Neurons.Add(inputNeuron);

            return inputNeuron;
        }
    }
}
