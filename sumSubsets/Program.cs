using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sumSubsets
{
    class Program
    {
        int[][] sumSubsets(int[] arr, int num)
        {
            var l = new List<int>();
            var r = new List<int[]>();
            sumSubsets1(arr, 0, num, l, r);
            return r.ToArray();
        }

        private void sumSubsets1(int[] arr, int currentPos, int num, List<int> values, List<int[]> result)
        {
            if (num == 0)
            {
                var newVal = values.ToArray();
                bool flag = true;
                foreach (int[] otherValues in result)
                    if (newVal.Length == otherValues.Length && Enumerable.Zip(newVal, otherValues, (a, b) => a - b).All(i => i == 0))
                    {
                        flag = false;
                        break;
                    }
                if (flag)
                    result.Add(newVal);
            }
            else
            {
                if (currentPos == arr.Length) return;

                if (arr[currentPos] <= num)
                {
                    values.Add(arr[currentPos]);
                    sumSubsets1(arr, currentPos + 1, num - arr[currentPos], values, result);
                    values.RemoveAt(values.Count - 1);
                }

                sumSubsets1(arr, currentPos + 1, num, values, result);
            }
        }


        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.sumSubsets(new[] { 1, 2, 3, 4, 5 }, 5));
        }
    }
}
