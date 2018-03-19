using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamingRoads
{
    class Program
    {
        bool namingRoads(int[][] roads)
        {
            var dict = new Dictionary<int, SortedSet<int>>();

            foreach (int[] road in roads)
            {
                int city1 = road[0], city2 = road[1], nameRoad = road[2];
                if (!dict.ContainsKey(city1))
                    dict[city1] = new SortedSet<int>();
                if (!dict.ContainsKey(city2))
                    dict[city2] = new SortedSet<int>();
                dict[city1].Add(nameRoad);
                dict[city2].Add(nameRoad);
            }

            foreach (int dictKey in dict.Keys)
            {
                var names = dict[dictKey].ToArray();
                for (int i = 1; i < names.Length; i++)
                    if (names[i] - names[i - 1] == 1)
                        return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
        }
    }
}
