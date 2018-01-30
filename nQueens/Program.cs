using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nQueens
{
    class Program
    {
        int[][] nQueens(int n)
        {
            int[] board = new int[n];
            var r = new List<int[]>();
            nQueens1(board, 0, r);
            return r.ToArray();
        }

        private void nQueens1(int[] board, int currentPos, List<int[]> r)
        {
            if (currentPos == board.Length)
            {
                int[] newBoardConfig = new int[board.Length];
                Array.Copy(board, newBoardConfig, board.Length);
                r.Add(newBoardConfig);
            }
            else
            {
                foreach (int rowPos in GoodPositions(board, currentPos))
                {
                    board[currentPos] = rowPos;
                    nQueens1(board, currentPos + 1, r);
                }
                board[currentPos] = 0;
            }
        }

        private IEnumerable<int> GoodPositions(int[] board, int currentPos)
        {
            bool[] goodPos = Enumerable.Repeat(true, board.Length).ToArray();

            for (int i = 0; i < currentPos; i++)
            {
                goodPos[board[i] - 1] = false;//invalidating row
                //invalidating diagonal in one direction
                int colLength = currentPos + 1;
                int col = i + 1;
                int row = board[i];
                int minLengthToEdges = Math.Min(board.Length - row, colLength - col);
                int colEdge = col + minLengthToEdges;
                int rowEdge = row + minLengthToEdges;
                Invalidate(currentPos, colEdge, goodPos, rowEdge);
                //invalidating diagonal in the other direction
                minLengthToEdges = Math.Min(row, colLength - col);
                rowEdge = row - minLengthToEdges;
                colEdge = col + minLengthToEdges;
                Invalidate(currentPos, colEdge, goodPos, rowEdge);
            }

            for (int i = 0; i < goodPos.Length; i++)
                if (goodPos[i])
                    yield return i + 1;
        }

        private static void Invalidate(int currentPos, int colEdge, bool[] goodPos, int rowEdge)
        {
            if (colEdge == currentPos + 1 && rowEdge > 0 && rowEdge <= goodPos.Length)
                goodPos[rowEdge - 1] = false;
        }

        static void Main(string[] args)
        {
            var p = new Program();
            var r = p.nQueens(4);
            foreach (int[] board in r)
            {
                foreach (int row in board)
                    Console.Write($"{row} ");
                Console.WriteLine();
            }
        }
    }
}
