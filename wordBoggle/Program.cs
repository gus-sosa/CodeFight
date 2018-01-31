using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordBoggle
{
    class Program
    {
        Dictionary<char, List<Tuple<int, int>>> cache = null;

        private int[] rowMovs = new[] { -1, -1, 0, 1, 1, 1, 0, -1 },
            colMovs = new[] { 0, 1, 1, 1, 0, -1, -1, -1 };

        string[] wordBoggle(char[][] board, string[] words)
        {
            var r = new List<string>();
            GetCache(board);
            foreach (string word in words)
                if (IsInBoard(board, new bool[board.Length, board[0].Length], word, -1, -1))
                    r.Add(word);
            return r.Distinct().OrderBy(i => i).ToArray();
        }

        private bool IsInBoard(char[][] board, bool[,] marks, string word, int row, int col)
        {
            if (string.IsNullOrEmpty(word))
                return true;

            char c = word[0];
            foreach (Tuple<int, int> newPos in GetNextPos(board, marks, c, row, col))
            {
                marks[newPos.Item1, newPos.Item2] = true;
                if (IsInBoard(board, marks, word.Substring(1), newPos.Item1, newPos.Item2))
                    return true;
                marks[newPos.Item1, newPos.Item2] = false;
            }
            return false;
        }

        private IEnumerable<Tuple<int, int>> GetNextPos(char[][] board, bool[,] marks, char c, int row, int col)
        {
            var cache = GetCache();
            if (row == -1)
            {
                var enumerator = cache.ContainsKey(c) ? cache[c] : new List<Tuple<int, int>>();
                foreach (Tuple<int, int> tuple in enumerator)
                    yield return tuple;
            }

            for (int i = 0; i < colMovs.Length; i++)
            {
                int nextRow = row + rowMovs[i];
                int nextCol = col + colMovs[i];
                if (nextRow >= 0 && nextRow < board.Length && nextCol >= 0 && nextCol < board[0].Length && !marks[nextRow, nextCol] && board[nextRow][nextCol] == c)
                    yield return Tuple.Create(nextRow, nextCol);
            }
        }

        private Dictionary<char, List<Tuple<int, int>>> GetCache(char[][] board = null)
        {
            if (cache != null)
                return cache;

            if (board == null)
                return null;

            cache = new Dictionary<char, List<Tuple<int, int>>>();
            for (int i = 0; i < board.Length; i++)
            {
                char[] row = board[i];
                for (int j = 0; j < row.Length; j++)
                {
                    if (!cache.ContainsKey(row[j]))
                        cache[row[j]] = new List<Tuple<int, int>>();
                    cache[row[j]].Add(Tuple.Create(i, j));
                }
            }

            return cache;
        }


        static void Main(string[] args)
        {
            var p = new Program();
            char[][] board = new[]
            {
                new[]{'S','A'},
                new[]{'M','O'},
                new[]{'W','E'},
                new[]{'H','R'}
            };
            string[] words = new[]
            {
                "SOME",
                "DRONE",
                "WHERE",
                "SOMEWHERE",
                "WORD",
                "WE",
                "MORE"
            };
            string[] result = p.wordBoggle(board, words);
            foreach (string s in result)
                Console.WriteLine(s);
        }
    }
}
