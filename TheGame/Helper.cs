using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public static class Helper
    {
        public static double LimitDoubleToAbsValue(double value, double maxAbsValue)
        {
            if (value < -maxAbsValue)
            {
                value = -maxAbsValue;
            }
            else if (value > maxAbsValue)
            {
                value = maxAbsValue;
            }
            return value;
        }

    }
}
