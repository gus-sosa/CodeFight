using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SwapLexOrder
{
    class Program
    {
        string swapLexOrder(string str, int[][] pairs)
        {
            foreach (int[] pair in pairs)
            {
                int min = Math.Min(pair[0], pair[1]);
                int max = Math.Max(pair[0], pair[1]);
                pair[0] = min - 1;
                pair[1] = max - 1;
            }

            var set = new int[str.Length];
            for (int i = 0; i < set.Length; i++)
                set[i] = -1;

            foreach (int[] pair in pairs)
                Merge(pair[0], pair[1], set);

            var dict = new Dictionary<int, SortedSet<int>>();
            for (int i = 0; i < set.Length; i++)
            {
                int parent = GetSet(i, set);
                if (parent == i)
                    continue;
                if (!dict.ContainsKey(parent))
                    dict[parent] = new SortedSet<int>() { parent };
                dict[parent].Add(i);
            }

            var bestStr = new StringBuilder(str);
            foreach (SortedSet<int> dictValue in dict.Values)
            {
                var charArr = new List<char>();
                foreach (int i in dictValue)
                    charArr.Add(str[i]);
                charArr.Sort();
                charArr.Reverse();
                foreach (var tuple in Enumerable.Zip(charArr, dictValue, Tuple.Create))
                {
                    char character = tuple.Item1;
                    int indexCharacter = tuple.Item2;
                    bestStr[indexCharacter] = character;
                }
            }

            return bestStr.ToString();
        }

        private void Merge(int v1, int v2, int[] set)
        {
            int parent1 = GetSet(v1, set);
            int parent2 = GetSet(v2, set);
            if (parent1 != parent2)
                set[parent2] = parent1;
        }

        private int GetSet(int pos, int[] set)
        {
            int index = pos;
            while (set[index] != -1)
                index = set[index];
            return index;
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.swapLexOrder("qvspxdrbvwfuaahtzbpjudfyzccgzwynkgihwmdshvfnvyvfjc", new[]
            {
                new[]{16,26},
                new[]{2,25},
                new[]{25,27},
                new[]{19,20},
                new[]{13,20},
                new[]{4,26},
                new[]{19,27},
                new[]{18,26},
                new[]{13,23},
                new[]{1,4},
                new[]{11,19},
                new[]{16,19},
                new[]{25,28},
                new[]{19,30},
                new[]{19,25},
                new[]{1,11},
                new[]{2,20},
                new[]{10,22},
                new[]{6,19},
                new[]{7,26},
                new[]{3,30},
                new[]{15,23},
                new[]{12,26},
                new[]{1,3},
                new[]{3,12},
                new[]{3,26},
                new[]{16,30},
                new[]{2,16},
                new[]{4,13}
            }));
        }
    }
}
