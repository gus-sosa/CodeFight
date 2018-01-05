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
            {
                Merge(pair[0], pair[1], set, dict);
                int setIndex = GetSet(pair[0], set);
                if (!dict.ContainsKey(setIndex))
                    dict[setIndex] = new SortedSet<int>();
                dict[setIndex].Add(pair[0]);
                dict[setIndex].Add(pair[1]);
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

        private void Merge(int pos1, int pos2, int[] set, Dictionary<int, SortedSet<int>> dict)
        {
            if ((set[pos1] == -1 && set[pos2] == -1) || (set[pos1] != -1 && set[pos2] != -1))
            {
                if (set[pos1] != -1)
                {
                    int parentSet1 = GetSet(pos1, set);
                    int parentSet2 = GetSet(pos2, set);
                    if (parentSet1 != parentSet2)
                    {
                        dict[parentSet1].UnionWith(dict[parentSet2]);
                        dict.Remove(parentSet2);
                    }
                }
                set[pos2] = set[pos1] == -1 ? pos1 : set[pos1];
            }
            else
            {
                if (set[pos1] == -1) set[pos1] = set[pos2];
                else set[pos2] = set[pos1];
            }
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
            Console.WriteLine(p.swapLexOrder("fixmfbhyutghwbyezkveyameoamqoi", new[]
            {
                new[]{8,5},
                new[]{10,8},
                new[]{4,18},
                new[]{20,12},
                new[]{5,2},
                new[]{17,2},
                new[]{13,25},
                new[]{29,12},
                new[]{22,2},
                new[]{17,11}
            }));
        }
    }
}
