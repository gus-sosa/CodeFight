using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace climbingStairs
{
    class Program
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int climbingStairs(int n)
        {
            if (dict.ContainsKey(n))
                return dict[n];
            if (n == 1)
                return 1;
            if (n == 2)
                return 2;
            return dict[n] = climbingStairs(n - 1) + climbingStairs(n - 2);
        }

        static void Main(string[] args)
        {
        }
    }
}
