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
            sum[0] = arr[0];
            int iStart = -1, iEnd = 0;

            for (int i = 1; i < arr.Length; i++)
                sum[i] = arr[i] + sum[i - 1];

            for (int i = 0; i < arr.Length; i++)
                for (int j = i; j < arr.Length; j++)
                {
                    int sumInterval = sum[j] - sum[i] + arr[i];
                    if (sumInterval == s && (iStart == -1 || i < iStart || (i == iStart && j >= iEnd)))
                    {
                        iStart = i;
                        iEnd = j;
                    }
                }

            return iStart == -1 ? new int[] { -1 } : new int[] { iStart + 1, iEnd + 1 };
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.findLongestSubarrayBySum(15, new int[] { 1, 2, 3, 4, 5, 0, 0, 0, 6, 7, 8, 9, 10 }).StringValue());
        }
    }
}
