using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    [Serializable]
    public class OutputNeuron : Neuron
    {
        public List<Axon> Inputs { get; set; }
        public override double Input { get { return CalculateInput(); } }

        public OutputNeuron(string name)
        {
            Name = name;
            Inputs = new List<Axon>();
        }

        private double CalculateInput()
        {
            double input;

            input = Inputs.Sum(i => i.Input.Output * i.Weight);

            return input;
        }

        public Axon CreateAxon(Neuron neuron, double weight)
        {
            Axon axon;

            axon = new Axon(neuron, weight);

            Inputs.Add(axon);

            return axon;
        }
    }
}
