using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateImage
{
    class Program
    {
        int[][] rotateImage(int[][] a)
        {
            for (int i = 0; i < a.Length; i++)
                for (int k = 0; k < a.Length; k++)
                    if (a[i][k] > 0 && !(i == k && a.Length % 2 == 1 && i == a.Length / 2))
                    {
                        int currentValue = a[i][k];
                        int currentRowIndex = i;
                        int currentColIndex = k;
                        for (int j = 0; j < 4; j++)
                        {
                            int nextRowIndex = currentColIndex;
                            int nextColIndex = a.Length - 1 - currentRowIndex;
                            int tmp = a[nextRowIndex][nextColIndex];
                            a[nextRowIndex][nextColIndex] = -currentValue;
                            currentValue = tmp;
                            currentRowIndex = nextRowIndex;
                            currentColIndex = nextColIndex;
                        }
                    }

            foreach (int[] array in a)
                for (int j = 0; j < a.Length; j++)
                    array[j] = Math.Abs(array[j]);

            return a;
        }

        static void Main(string[] args)
        {
            var p = new Program();
            PrintResult(p.rotateImage(new[]
            {
                new []{1,2,3},
                new []{4,5,6},
                new []{7,8,9}
            }));

            PrintResult(p.rotateImage(new[]
            {
                new []{1,2,3,4},
                new []{5,6,7,8},
                new []{9,10,11,12},
                new []{13,14,15,16}
            }));
        }

        private static void PrintResult(int[][] data)
        {
            Console.WriteLine();
            Console.WriteLine();
            foreach (int[] currentArray in data)
            {
                foreach (int value in currentArray)
                    Console.Write($"{value} ");
                Console.WriteLine();
            }
        }
    }
}
