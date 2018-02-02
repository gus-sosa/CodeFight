using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace houseRobber
{
    class Program
    {
        int houseRobber(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            int previousBestEndings = nums[0], previousBestNonEndings = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                int tmp = previousBestNonEndings;
                previousBestNonEndings = Math.Max(previousBestNonEndings, previousBestEndings);
                previousBestEndings = tmp + nums[i];
            }

            return Math.Max(previousBestNonEndings, previousBestEndings);
        }


        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.houseRobber(new[] { 2, 1 }));
        }
    }
}
