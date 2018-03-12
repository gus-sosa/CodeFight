using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace roadsBuilding
{
    class Program
    {
        int[][] roadsBuilding(int cities, int[][] roads)
        {
            var matrix = new bool[cities, cities];
            foreach (int[] road in roads)
                matrix[road[0], road[1]] = matrix[road[1], road[0]] = true;

            var result = new List<int[]>();
            for (int i = 0; i < cities; i++)
                for (int j = i + 1; j < cities; j++)
                    if (!matrix[i, j])
                        result.Add(new int[] { i, j });

            return result.ToArray();
        }


        static void Main(string[] args)
        {
        }
    }
}
