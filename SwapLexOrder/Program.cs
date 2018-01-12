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
                AddToDict(dict, set, pos2, pos1);
                set[pos1] = parent2;
            }
            else
            {
                AddToDict(dict, set, pos1, pos2);
                set[pos2] = parent1;
            }
        }

        private void AddToDict(Dictionary<int, SortedSet<int>> dict, int[] set, int pos1, int pos2)
        {
            int parent1 = GetSet(pos1, set);
            int parent2 = GetSet(pos2, set);
            if (!dict.ContainsKey(parent1))
                dict[parent1] = new SortedSet<int>() { pos1 };
            dict[parent1].Add(pos2);
            if (dict.ContainsKey(parent2))
            {
                dict[parent1].UnionWith(dict[parent2]);
                dict.Remove(parent2);
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
            Console.WriteLine(p.swapLexOrder("wdbmjpxusweoaxfybkikectlgvrxyracjxeghyctvvexpoxibunjvswhuwduirybhrfvcybuaisbujcngdiaotysffkxocnajloq", new[]
            {
                new[]{60,65},
                new[]{41,93},
                new[]{41,58},
                new[]{87,92},
                new[]{34,87},
                new[]{37,56},
                new[]{35,79},
                new[]{10,54},
                new[]{35,73},
                new[]{56,57},
                new[]{5,65},
                new[]{69,91},
                new[]{6,65},
                new[]{72,95},
                new[]{8,49},
                new[]{35,62},
                new[]{26,73},
                new[]{38,58},
                new[]{14,88},
                new[]{38,41},
                new[]{25,66},
                new[]{29,47},
                new[]{4,65},
                new[]{44,59},
                new[]{40,89},
                new[]{7,86},
                new[]{26,53},
                new[]{39,81},
                new[]{6,8},
                new[]{3,68},
                new[]{88,91},
                new[]{42,71},
                new[]{8,67},
                new[]{34,89},
                new[]{5,53},
                new[]{76,79},
                new[]{16,75},
                new[]{44,70},
                new[]{37,44},
                new[]{62,94},
                new[]{66,83},
                new[]{42,70},
                new[]{3,76},
                new[]{22,37},
                new[]{27,36},
                new[]{81,96},
                new[]{11,25},
                new[]{29,58},
                new[]{33,81},
                new[]{36,44}
            }));
        }
    }
}
