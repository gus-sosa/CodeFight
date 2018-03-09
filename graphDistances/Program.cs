using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphDistances
{
    class Program
    {
        int[] graphDistances(int[][] g, int s)
        {
            int[] distances = new int[g.GetLength(0)];
            for (int i = 0; i < distances.Length; i++)
                distances[i] = int.MaxValue;
            distances[s] = 0;

            var unvistedNodes = new List<int>() { s };
            if (s > 0)
                unvistedNodes = unvistedNodes.Concat(Enumerable.Range(0, s)).ToList();
            if (distances.Length - 1 - s > 0)
                unvistedNodes = unvistedNodes.Concat(Enumerable.Range(s + 1, distances.Length - 1 - s)).ToList();
            var sorter = new NodeSorter(distances);
            while (unvistedNodes.Count > 0)
            {
                int currentNode = unvistedNodes[0];
                unvistedNodes.RemoveAt(0);
                foreach (var connectedNode in ConnectedNodes(currentNode, g))
                {
                    int dst = distances[currentNode] + g[currentNode][connectedNode];
                    if (dst < distances[connectedNode])
                        distances[connectedNode] = dst;
                }
                unvistedNodes.Sort(sorter);
            }

            return distances;
        }

        private IEnumerable<int> ConnectedNodes(int node, int[][] g)
        {
            int length = g.GetLength(0);
            for (int i = 0; i < length; i++)
                if (g[node][i] != -1)
                    yield return i;
        }

        internal class NodeSorter : IComparer<int>
        {
            private readonly int[] _distances;

            public NodeSorter(int[] distances)
            {
                _distances = distances;
            }

            public int Compare(int x, int y)
            {
                return _distances[x].CompareTo(_distances[y]);
            }
        }

        static void Main(string[] args)
        {
            var p = new Program();
            int[][] g = new[]{new[]{-1, -1, 19, 8, 18, -1, -1, -1, -1, -1},
                new[]{10, 6, 4, 7, 0, 10, 18, -1, 0, -1},
                new[]{-1, -1, 15, -1, 17, 3, -1, 14, 16, 3},
                new[]{4, 19, 3, 15, 8, 4, 6, 11, 5, 8},
                new[]{5, 3, 10, -1, 0, 14, 15, 1, 16, 5},
                new[]{-1, 8, -1, -1, 5, -1, 5, 0, 1, -1},
                new[]{-1, 18, -1, 19, 2, -1, 10, -1, 8, 6},
                new[]{14, 8, 12, 16, -1, -1, 0, 16, 15, 17},
                new[]{4, 5, 1, 12, 0, 4, 8, 15, 1, -1},
                new[]{13, 7, 17, -1, 4, 13, 16, 3, 12, 9}};
            var r = p.graphDistances(g, 8);
            foreach (int i in r)
                Console.Write($"{i} ");
            Console.WriteLine();
        }
    }
}
