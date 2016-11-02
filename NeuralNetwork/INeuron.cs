using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public interface INeuron
    {
        double Bias { get; set; }
        double Output { get; }
        void UpdateOutput();
    }
}
