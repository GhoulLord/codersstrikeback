using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    [Serializable]
    public class HiddenNeuron : OutputNeuron
    {
        public HiddenNeuron(string name)
            : base(name)
        {
        }
    }
}
