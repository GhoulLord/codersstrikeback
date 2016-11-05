using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Genetics
{
    public class Storage
    {
        public static void WritePopulationToFile(Population population, string filePath)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream =
                new FileStream(filePath,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None);
            formatter.Serialize(stream, population);
            stream.Close();
        }

        public static Population ReadPopulationFromFile(string filePath)
        {
            Population population;

            IFormatter formatter = new BinaryFormatter();
            Stream stream =
                new FileStream(filePath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.None);
            population = (Population)formatter.Deserialize(stream);
            stream.Close();

            return population;
        }
    }
}
