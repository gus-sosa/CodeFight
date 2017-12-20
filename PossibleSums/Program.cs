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
            var q = new Queue<List<int>>();
            q.Enqueue(Enumerable.Repeat(0, coins.Length).ToList());
            var hash = new HashSet<int>();

            while (q.Count > 0)
            {
                List<int> current = q.Dequeue();
                int sum = current.Select((count, index) => coins[index] * count).Sum();
                for (int i = 0; i < coins.Length; i++)
                    if (quantity[i] - current[i] - 1 >= 0 && !hash.Contains(sum + coins[i]))
                    {
                        hash.Add(sum + coins[i]);
                        var newList = new int[current.Count];
                        current.CopyTo(newList, 0);
                        newList[i]++;
                        var list = newList.ToList();
                        Console.WriteLine(MyClass.ToString(list));
                        q.Enqueue(list);
                    }
            }

            return hash.Count;
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.possibleSums(new[] { 6, 12, 7, 16, 8, 5, 17, 18, 6 }, new[] { 3, 4, 4, 2, 6, 4, 4, 2, 5 }));
        }
    }
}