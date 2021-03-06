﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class CheckPoint : Unit
    {
        public int Number { get; set; }

        public CheckPoint(int number, Vector position, double size)
            : base(position, size)
        {
            Number = number;
        }

        public CheckPoint Copy()
        {
            return new CheckPoint(Number, new Vector(Position), Size);
        }

        public override string ToString()
        {
            return Position.ToString();
        }
    }
}
