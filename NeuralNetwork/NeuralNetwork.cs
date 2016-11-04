using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    [Serializable]
    public class NeuralNetwork
    {
        public InputLayer InputLayer { get; set; }
        public List<HiddenLayer> HiddenLayers { get; set; }
        public OutputLayer OutputLayer { get; set; }

        private Random r = new Random();

        public NeuralNetwork()
        {
            InputLayer = null;
            HiddenLayers = new List<HiddenLayer>();
            OutputLayer = null;
        }

        public InputLayer CreateInputLayer()
        {
            InputLayer = new InputLayer();

            return InputLayer;
        }

        public HiddenLayer CreateHiddenLayer()
        {
            HiddenLayer hiddenLayer;
            
            hiddenLayer = new HiddenLayer();
            HiddenLayers.Add(hiddenLayer);

            return hiddenLayer;
        }

        public OutputLayer CreateOutputLayer()
        {
            OutputLayer = new OutputLayer();

            return OutputLayer;
        }

        public void UpdateOutput()
        {
            UpdateInputLayerOutput();
            UpdateHiddenLayerOutput();
            UpdateOutputLayerOutput();
        }

        private void CreateFullConnectionsBetweenTwoLayers(INeuronLayer firstLayer, INeuronLayer secondLayer)
        {
            foreach (var firstNeuron in firstLayer.Neurons)
            {
                foreach (var secondNeuron in secondLayer.Neurons.Cast<OutputNeuron>())
                {
                    secondNeuron.CreateAxon(firstNeuron, 0);
                }
            }
        }

        public void CreateFullConnections()
        {
            INeuronLayer layerBeforeCurrentLayer = InputLayer;

            foreach (var hiddenLayer in HiddenLayers)
            {
                CreateFullConnectionsBetweenTwoLayers(layerBeforeCurrentLayer, hiddenLayer);

                layerBeforeCurrentLayer = hiddenLayer;
            }

            CreateFullConnectionsBetweenTwoLayers(layerBeforeCurrentLayer, OutputLayer);
        }

        private double MyRandom()
        {
            return r.NextDouble() - r.NextDouble();
        }

        private void InitInputLayerWithRandomValues()
        {
            foreach (var neuron in InputLayer.Neurons)
            {
                neuron.Bias = 3 * MyRandom();
            }
        }

        private void InitHiddenLayerWithRandomValues(HiddenLayer layer)
        {
            foreach (var neuron in layer.Neurons.Cast<HiddenNeuron>())
            {
                neuron.Bias = 3 * MyRandom();

                foreach (var axon in neuron.Inputs)
                {
                    axon.Weight = 3 * MyRandom();
                }
            }
        }

        private void InitHiddenLayersWithRandomValues()
        {
            HiddenLayers.ForEach(h => InitHiddenLayerWithRandomValues(h));
        }

        private void InitOutputLayerWithRandomValues()
        {
            foreach (var neuron in OutputLayer.Neurons.Cast<OutputNeuron>())
            {
                neuron.Bias = 3 * MyRandom();

                foreach (var axon in neuron.Inputs)
                {
                    axon.Weight = 3 * MyRandom();
                }
            }
        }

        public void InitWithRandomValues()
        {
            InitInputLayerWithRandomValues();
            InitHiddenLayersWithRandomValues();
            InitOutputLayerWithRandomValues();
        }

        private void UpdateOutputLayerOutput()
        {
            OutputLayer.UpdateNeuronsOutput();
        }

        private void UpdateHiddenLayerOutput()
        {
            HiddenLayers.ForEach(h => h.UpdateNeuronsOutput());
        }

        private void UpdateInputLayerOutput()
        {
            InputLayer.UpdateNeuronsOutput();
        }
    }
}
