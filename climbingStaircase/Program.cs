using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace climbingStaircase
{
    class Program
    {
        int[][] climbingStaircase(int n, int k)
        {
            var r = new List<int[]>();
            var currentSteps = new List<int>();
            climbingStaircase1(n, k, currentSteps, r);
            return r.ToArray();
        }

        private void climbingStaircase1(int n, int k, List<int> currentSteps, List<int[]> r)
        {
            if (n == 0) r.Add(currentSteps.ToArray());
            else
            {
                int lengthStep = Math.Min(k, n);
                for (int i = 1; i <= lengthStep; i++)
                {
                    currentSteps.Add(i);
                    climbingStaircase1(n - i, k, currentSteps, r);
                    currentSteps.RemoveAt(currentSteps.Count - 1);
                }
            }
        }

        static void Main(string[] args)
        {
            var p = new Program();
            var r = p.climbingStaircase(4, 2);

            PrintResult(r);
        }

        private static void PrintResult(int[][] r)
        {
            foreach (int[] row in r)
            {
                foreach (int i in row)
                    Console.Write($"{i} ");
                Console.WriteLine();
            }
        }
    }
}
