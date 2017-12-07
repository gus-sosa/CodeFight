using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace containsCloseNums
{
    class Program
    {
        bool containsCloseNums(int[] nums, int k)
        {
            int lastIndex = 0;
            var set = new HashSet<int>();
            k++;
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                if (i - lastIndex >= k)
                    set.Remove(nums[lastIndex++]);

                if (set.Contains(num))
                    return true;

                set.Add(num);
            }

            return false;
        }


        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.containsCloseNums(new[] { 0, 1, 2, 3, 5, 2 }, 3));
        }
    }
}
