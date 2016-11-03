using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public interface INeuronLayer
    {
        List<Neuron> Neurons { get; set; }
        
        void UpdateNeuronsOutput();
    }
}
