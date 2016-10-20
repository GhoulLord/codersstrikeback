using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheGame
{
    public class Team
    {
        public string Name { get; set; }
        public List<PodRacer> PodRacers { get; set; }
        public Color Color { get; set; }

        public Team(string name, Color color)
        {
            Name = name;
            Color = color;
            PodRacers = new List<PodRacer>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Team:{0}", Name).AppendLine();

            int index = 1;

            foreach (var podRacer in PodRacers)
            {
                sb.AppendFormat("{0,2}:{1}", index, podRacer.ToString());
                index++;
            }

            return sb.ToString();
        }
    }
}
