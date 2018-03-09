using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku2
{
    class Program
    {
        bool sudoku2(char[][] grid)
        {
            int[,] squareMarks = new int[3, 3];
            int[] rowMarks = new int[grid.Length];
            int[] colMarks = new int[grid.Length];
            for (int i = 0; i < grid.Length; i++)
            {
                char[] currentRow = grid[i];
                for (int j = 0; j < currentRow.Length; j++)
                {
                    char currentValue = currentRow[j];
                    if (!char.IsDigit(currentValue))
                        continue;

                    int value = Convert.ToInt32(currentValue);
                    int rowSquare = i / 3;
                    int colSquare = j / 3;
                    if (IsSet(rowMarks[i], value) || IsSet(colMarks[j], value) ||
                        IsSet(squareMarks[rowSquare, colSquare], value))
                        return false;

                    rowMarks[i] = Set(rowMarks[i], value);
                    colMarks[j] = Set(colMarks[j], value);
                    squareMarks[rowSquare, colSquare] = Set(squareMarks[rowSquare, colSquare], value);
                }
            }

            return true;
        }

        private int Set(int mask, int pos)
        {
            return mask | (2 << pos);
        }

        private bool IsSet(int mask, int pos)
        {
            return (mask & (2 << pos)) != 0;
        }


        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.sudoku2(null));
        }
    }
}
