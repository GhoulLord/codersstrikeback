using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    [Serializable]
    public abstract class NeuronLayer<N> : INeuronLayer
    {
        public List<Neuron> Neurons { get; set; }
        
        public abstract N CreateNeuron();

        public NeuronLayer()
        {
            Neurons = new List<Neuron>();
        }

        public void UpdateNeuronsOutput()
        {
            Neurons.ForEach(n => n.UpdateOutput());
        }
    }
}
