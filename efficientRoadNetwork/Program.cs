using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efficientRoadNetwork
{
    class Program
    {
        bool efficientRoadNetwork(int n, int[][] roads)
        {
            bool[,] matrix = BuildAdjMatrix(roads, n);

            var queue = new Queue<Tuple<int, int>>();
            var marks = new bool[n];
            bool flag = true;
            for (int i = 0; flag && i < n; i++)
            {
                queue.Enqueue(Tuple.Create(i, 0));
                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    var node = current.Item1;
                    var level = current.Item2;
                    if (level < 3)
                    {
                        marks[node] = true;
                        foreach (int adj in GetAdj(matrix, node, n))
                            if (!marks[adj])
                                queue.Enqueue(Tuple.Create(adj, level + 1));
                    }
                }

                for (int j = 0; j < n; j++)
                {
                    flag = flag && marks[j];
                    marks[j] = false;
                }
                queue.Clear();
            }

            return flag;
        }

        private bool[,] BuildAdjMatrix(int[][] roads, int n)
        {
            var matrix = new bool[n, n];
            foreach (int[] road in roads)
                matrix[road[0], road[1]] = matrix[road[1], road[0]] = true;
            return matrix;
        }

        private IEnumerable<int> GetAdj(bool[,] matrix, int node, int n)
        {
            for (int i = 0; i < n; i++)
                if (matrix[node, i])
                    yield return i;
        }

        static void Main(string[] args)
        {
        }
    }
}
