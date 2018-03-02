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
            int[] sum = new int[arr.Length];
            var dict = new Dictionary<int, SortedSet<int>>();
            sum[0] = arr[0];
            dict.Add(0, new SortedSet<int>() { 0 });
            for (int i = 1; i < arr.Length; i++)
            {
                sum[i] = sum[i - 1] + arr[i];
                int key = sum[i] - arr[i];
                if (!dict.ContainsKey(key))
                    dict[key] = new SortedSet<int>();
                dict[key].Add(i);
            }

            int iStart = -1, iEnd = 0;
            for (int i = arr.Length - 1; i >= 0 && sum[i] >= s; i--)
            {
                int compl = sum[i] - s;
                if (dict.ContainsKey(compl))
                {
                    int index = dict[compl].First();
                    if (iStart == -1 || (i - index > iEnd - iStart))
                    {
                        iStart = index;
                        iEnd = i;
                    }
                }
            }

            return iStart == -1 ? new int[] { -1 } : new int[] { iStart + 1, iEnd + 1 };
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.findLongestSubarrayBySum(12, new int[] { 1, 2, 3, 7, 5 }).StringValue());
        }
    }
}
