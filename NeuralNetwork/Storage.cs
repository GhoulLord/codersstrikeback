using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace NeuralNetwork
{
    public class Storage
    {
        public static void WriteNeuralNetworkToFile(NeuralNetwork neuralNetwork, string filePath)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream =
                new FileStream(filePath,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None);
            formatter.Serialize(stream, neuralNetwork);
            stream.Close();
        }

        public static NeuralNetwork ReadNeuralNetworkFromFile(string filePath)
        {
            NeuralNetwork neuralNetwork;

            IFormatter formatter = new BinaryFormatter();
            Stream stream =
                new FileStream(filePath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.None);
            neuralNetwork = (NeuralNetwork)formatter.Deserialize(stream);
            stream.Close();

            return neuralNetwork;
        }
    }
}
