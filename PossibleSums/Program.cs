using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PossibleSums
{
    static class MyClass
    {
        public static string ToString(List<int> list)
        {
            var s = new StringBuilder();
            foreach (int i in list)
                s.Append($",{i}");
            s.Remove(0, 1);
            return s.ToString();
        }
    }

    class Program
    {
        int possibleSums(int[] coins, int[] quantity)
        {
            var hash = new HashSet<int>() { 0 };
            for (int i = 0; i < coins.Length; i++)
            {
                int currentCoin = coins[i];
                var newHash = new HashSet<int>();
                foreach (int calculatedSum in hash)
                {
                    for (int q = 1; q <= quantity[i]; q++)
                    {
                        int newValue = currentCoin * q + calculatedSum;
                        if (!hash.Contains(newValue) && !newHash.Contains(newValue))
                            newHash.Add(newValue);
                    }
                }
                hash.UnionWith(newHash);
            }
            return hash.Count - 1;
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.possibleSums(new[] { 10, 50, 100 }, new[] { 1, 2, 1 }));
        }
    }
}