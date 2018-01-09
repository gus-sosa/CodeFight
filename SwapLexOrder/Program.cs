using System;
using System.Collections.Generic;
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

            var dict = new Dictionary<int, SortedSet<int>>();
            foreach (int[] pair in pairs)
                Merge(pair[0], pair[1], set, dict);

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

        private void Merge(int pos1, int pos2, int[] set, Dictionary<int, SortedSet<int>> dict)
        {
            int parent1 = GetSet(pos1, set);
            int parent2 = GetSet(pos2, set);
            if (parent1 == parent2)
                return;

            if (parent1 == pos1)
            {
                set[pos1] = parent2;
                AddToDict(dict, set, pos2, pos1);
            }
            else if (parent2 == pos2)
            {
                set[pos2] = parent1;
                AddToDict(dict, set, pos1, pos2);
            }
        }

        private void AddToDict(Dictionary<int, SortedSet<int>> dict, int[] set, int pos1, int pos2)
        {
            int parent = GetSet(pos1, set);
            if (!dict.ContainsKey(parent))
                dict[parent] = new SortedSet<int>() { pos1 };
            dict[parent].Add(pos2);
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
            Console.WriteLine(p.swapLexOrder("abdc", new[]
            {
                new[]{1, 4},
                new[]{ 3, 4}
            }));
        }
    }
}
