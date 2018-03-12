using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace financialCrisis
{
    class Program
    {
        bool[][][] financialCrisis(bool[][] roadRegister)
        {
            int[][] roads = GetRoads(roadRegister);
            bool[][][] results = new bool[roadRegister.Length][][];

            int newLength = roadRegister.Length - 1;
            for (int i = 0; i < roadRegister.Length; i++)
                results[i] = BuildMap(roads.Where(road => road[0] != i && road[1] != i), newLength);

            return results;
        }

        private bool[][] BuildMap(IEnumerable<int[]> roads, int n)
        {
            var result = new bool[n][];
            for (int i = 0; i < n; i++)
                result[i] = new bool[n];

            foreach (int[] road in roads)
                result[road[0]][road[1]] = true;

            return result;
        }

        private int[][] GetRoads(bool[][] roadRegister)
        {
            var roads = new List<int[]>();
            int n = roadRegister.Length;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (roadRegister[i][j])
                        roads.Add(new int[] { i, j });

            return roads.ToArray();
        }


        static void Main(string[] args)
        {
        }
    }
}
