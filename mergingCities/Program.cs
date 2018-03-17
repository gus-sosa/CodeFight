using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mergingCities
{
    class Program
    {
        bool[][] mergingCities(bool[][] roadRegister)
        {
            var edges = GetEdges(roadRegister);
            int length = roadRegister.Length;
            var newEdges = new List<int[]>();
            bool flag = false;
            for (int pivote = 0; pivote < length; pivote += (flag ? 1 : 2), flag = false)
                if (edges.Any(e => e[0] == pivote && e[1] == pivote + 1))
                {
                    flag = false;
                    newEdges.Clear();
                    length--;
                    foreach (int[] edge in edges)
                    {
                        if (edge[0] == pivote && edge[1] == pivote + 1)
                            continue;

                        if (edge[0] == pivote)
                        {
                            newEdges.Add(new[] { edge[0], edge[1] - 1 });
                            flag = true;
                            continue;
                        }

                        if (edge[0] == pivote + 1)
                        {
                            newEdges.Add(new[] { edge[0] - 1, edge[1] - 1 });
                            flag = true;
                            continue;
                        }

                        int edge0 = edge[0] < pivote + 1 ? edge[0] : edge[0] - 1;
                        int edge1 = edge[1] < pivote + 1 ? edge[1] : edge[1] - 1;
                        newEdges.Add(new[] { edge0, edge1 });
                        flag = true;
                    }

                    edges.Clear();
                    edges.AddRange(newEdges);
                }
            return BuildGraph(edges, length);
        }

        private bool[][] BuildGraph(List<int[]> edges, int length)
        {
            var graph = new bool[length][];
            for (int i = 0; i < length; i++)
                graph[i] = new bool[length];

            foreach (int[] edge in edges)
                graph[edge[0]][edge[1]] = graph[edge[1]][edge[0]] = true;

            return graph;
        }

        private List<int[]> GetEdges(bool[][] roadRegister)
        {
            var list = new List<int[]>();
            for (int i = 0, n = roadRegister.Length; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (roadRegister[i][j])
                        list.Add(new[] { i, j });
            return list;
        }

        static void Main(string[] args)
        {
            var p = new Program();
            p.mergingCities(new[]
            {
                new[]{false,true,true,false,false,false,false},
                new[]{true,false,false,false,true,false,true},
                new[]{true,false,false,false,true,true,true},
                new[]{false,false,false,false,true,true,true},
                new[]{false,true,true,true,false,false,false},
                new[]{false,false,true,true,false,false,true},
                new[]{false,true,true,true,false,true,false}
            });
        }
    }
}
