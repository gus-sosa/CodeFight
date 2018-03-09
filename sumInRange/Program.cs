using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sumInRange
{
    class Program
    {
        private int[] PreSum(int[] nums)
        {
            int[] result = new int[nums.Length];
            result[0] = nums[0];
            for (int i = 1; i < result.Length; i++)
                result[i] = nums[i] + result[i - 1];
            return result;
        }

        int sumInRange(int[] nums, int[][] queries)
        {
            int[] preSum = PreSum(nums);
            int result = 0;
            int mod = 1000000007;
            foreach (int[] item in queries)
            {
                int index1 = item[0];
                int index2 = item[1];
                result += preSum[index2] - preSum[index1] + nums[index1];
                result %= mod;
            }
            return result < 0 ? mod + result : result;
        }

        static void Main(string[] args)
        {
        }
    }
}
