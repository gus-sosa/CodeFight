using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace citiesConquering
{
    class Program
    {
        int[] citiesConquering(int n, int[][] roads)
        {
            //precomputation
            var outgoing = new int[n];
            var connections = new Dictionary<int, HashSet<int>>();

            foreach (int[] road in roads)
            {
                int a = road[0];
                int b = road[1];
                if (!connections.ContainsKey(a))
                    connections[a] = new HashSet<int>();
                if (!connections.ContainsKey(b))
                    connections[b] = new HashSet<int>();
                connections[a].Add(b);
                connections[b].Add(a);
                outgoing[a]++;
                outgoing[b]++;
            }

            //computing solution
            var conquering = Enumerable.Repeat(-1, n).ToArray();
            bool flag = true;
            int day = 0;
            var newOutgoing = new int[outgoing.Length];
            Array.Copy(outgoing, newOutgoing, outgoing.Length);
            var emptyList = new HashSet<int>();
            do
            {
                flag = true;
                day++;

                for (int i = 0; i < n; i++)
                {
                    if (conquering[i] != -1)
                        continue;
                    int degree = outgoing[i];
                    if (degree <= 1)
                    {
                        conquering[i] = day;
                        newOutgoing[i]--;
                        var conn = connections.ContainsKey(i) ? connections[i] : emptyList;
                        foreach (int node in conn)
                        {
                            connections[node].Remove(i);
                            newOutgoing[node]--;
                        }
                        if (connections.ContainsKey(i))
                            connections.Remove(i);
                        flag = false;
                    }
                }
                Array.Copy(newOutgoing, outgoing, outgoing.Length);
            } while (!flag);

            return conquering;
        }


        static void Main(string[] args)
        {
            var p = new Program();
            p.citiesConquering(10, new[]
            {
                new[] {1, 0},
                new[] {1, 2},
                new[] {8, 5},
                new[] {9, 7},
                new[] {5, 6},
                new[] {5, 4},
                new[] {4, 6},
                new[] {6, 7}
            });
        }
    }
}
