using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetics
{
    [Serializable]
    public class Genom
    {
        public List<double> Gens { get; set; }

        public Genom(Genom g)
        {
            Gens = new List<double>(g.Gens);
        }
    }
}
