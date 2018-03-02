using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productExceptSelf
{
    class Program
    {
        int productExceptSelf(int[] nums, int m)
        {
            int product = nums.Aggregate(1, (acc, v) => v * acc);
            IEnumerable<int> productArray = nums.Select(i => (product / i) % m);
            return productArray.Sum() % m;
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.productExceptSelf(new int[] { 3, 3, 9, 5, 5, 4, 2, 8, 5, 9 }, 17));
        }
    }
}
