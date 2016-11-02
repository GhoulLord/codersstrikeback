using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class NeuronLayer
    {
        public List<Neuron> Neurons { get; set; }
        
        public void UpdateNeuronsOutput()
        {
            Neurons.ForEach(n => n.UpdateOutput());
        }
    }
}
