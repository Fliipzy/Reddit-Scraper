using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz_Conjecture
{
    public static class Utilities
    {
        public static bool IsEven(this int val)
        {
            if (val % 2 == 0)
            {
                return true;
            }
            return false;
        }
    }
}
