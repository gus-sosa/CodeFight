using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace combinationSum
{
    class Program
    {
        List<List<int>> listOfCombinations = new List<List<int>>();
        int[] A;
        List<int> currentCombination = new List<int>();
        string combinationSum(int[] a, int sum)
        {
            Array.Sort(a);
            A = a;
            combinationSum1(sum, 0);
            var result = new StringBuilder();
            foreach (List<int> combination in listOfCombinations)
                result.Append($"({combination.Aggregate("", (seed, i) => $"{seed} {i}").Remove(0, 1)})");
            return result.Length == 0 ? "Empty" : result.ToString();
        }

        private void combinationSum1(int sum, int pos)
        {
            if (sum == 0)
            {
                if (listOfCombinations.Any(lCombination => lCombination.Count == currentCombination.Count
                && lCombination.Zip(currentCombination, Tuple.Create).All(tuple => tuple.Item1 == tuple.Item2)))
                    return;
                listOfCombinations.Add(new List<int>(currentCombination));
            }

            if (A.Length == pos)
                return;

            int num = A[pos];
            if (num > sum)
                return;

            int length = sum / num;
            while (length >= 0)
            {
                currentCombination.AddRange(Enumerable.Repeat(num, length));
                combinationSum1(sum - num * length, pos + 1);
                currentCombination.RemoveRange(currentCombination.Count - length, length);
                length--;
            }
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.combinationSum(new[] { 5, 2, 2, 6 }, 3));
        }
    }
}
