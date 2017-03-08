using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    static class Utilities
    {
        public static int Clamp(this int val, int min, int max)
        {
            if (val < min)
            {
                return min;
            }
            else if (val > max)
            {
                return max;
            }
            else return val;
        }

        public static float Clamp(this float val, float min, float max)
        {
            if (val < min)
            {
                return min;
            }
            else if (val > max)
            {
                return max;
            }
            else return val;
        }
    }
}
