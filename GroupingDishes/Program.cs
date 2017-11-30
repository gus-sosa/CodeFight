using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupingDishes
{
    class Program
    {
        string[][] groupingDishes(string[][] dishes)
        {
            var hash = new Dictionary<string, List<string>>();
            foreach (string[] dish in dishes)
            {
                var nameDish = dish[0];
                var ingredients = dish.Skip(1);
                foreach (var ingredient in ingredients)
                {
                    if (!hash.ContainsKey(ingredient))
                        hash[ingredient] = new List<string>();
                    hash[ingredient].Add(nameDish);
                }
            }

            var list = new List<string[]>();

            foreach (string hashKey in hash.Keys)
            {
                hash[hashKey].Sort();
                list.Add(new[] { hashKey }.Concat(hash[hashKey].ToArray()).ToArray());
            }

            list.Sort(new DishComparison());
            return list.ToArray();
        }

        class DishComparison : IComparer<string[]>
        {
            public int Compare(string[] x, string[] y)
            {
                return String.CompareOrdinal(x[0], y[0]);
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
