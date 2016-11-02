using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class NeuralNetwork
    {
        public InputLayer InputLayer { get; set; }
        public List<HiddenLayer> HiddenLayers { get; set; }
        public OutputLayer OutputLayer { get; set; }

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
            InputLayer.UpdateNeuronsOutput();
            HiddenLayers.ForEach(h => h.UpdateNeuronsOutput());
            OutputLayer.UpdateNeuronsOutput();
        }
    }
}
