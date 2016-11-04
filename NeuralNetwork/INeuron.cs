using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public interface INeuron
    {
        string Name { get; set; }
        double Bias { get; set; }
        double Output { get; }
        void UpdateOutput();
    }
}
