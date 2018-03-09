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

            int p = 1;
            int s = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                s = nums[i] * s % m;
                p *= nums[i - 1];
                p %= m;
                s += p;
            }

            return s % m;
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.productExceptSelf(new int[] { 3, 3, 9, 5, 5, 4, 2, 8, 5, 9 }, 17));
        }
    }
}
