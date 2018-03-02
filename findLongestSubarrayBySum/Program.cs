using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace findLongestSubarrayBySum
{
    public static class MyClass
    {
        public static string StringValue(this int[] arr)
        {
            return $"[{arr[0]},{arr[1]}]";
        }
    }

    class Program
    {
        int[] findLongestSubarrayBySum(int s, int[] arr)
        {
            if (arr.Length == 1)
                return arr[0] == s ? new int[] { 1, 1 } : new int[] { -1 };

            var sum = new int[arr.Length];
            sum[0] = arr[0];
            var dict = new Dictionary<int, SortedSet<int>>();
            for (int i = 1; i < arr.Length; i++)
            {
                sum[i] = arr[i] + sum[i - 1];
                if (sum[i] >= s)
                {
                    int compl = sum[i] - s;
                    if (!dict.ContainsKey(compl))
                        dict[compl] = new SortedSet<int>();
                    dict[compl].Add(i);
                }
            }

            for (int i = 0; i < arr.Length; i++)
                if (dict.ContainsKey(sum[i] - arr[i]))
                    return new int[] { i + 1, dict[sum[i] - arr[i]].Last() + 1 };

            return new int[] { -1 };
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.findLongestSubarrayBySum(3, new int[] { 3 }).StringValue());
        }
    }
}
