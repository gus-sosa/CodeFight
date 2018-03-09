using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fillingBlocks
{
    class Program
    {
        Dictionary<int, int> store = new Dictionary<int, int>()
        {
            {2,5},
            {3,11 }
        };

        int fillingBlocks(int n) { return n <= 1 ? 1 : (store.ContainsKey(n) ? store[n] : store[n] = fillingBlocks(n - 1) + 5 * fillingBlocks(n - 2) + fillingBlocks(n - 3) - fillingBlocks(n - 4)); }


        static void Main(string[] args)
        {
        }
    }
}
