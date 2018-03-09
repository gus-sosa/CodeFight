using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace largestValuesInTreeRows
{
    class Program
    {
        //
        // Definition for binary tree:
        class Tree<T>
        {
            public T value { get; set; }
            public Tree<T> left { get; set; }
            public Tree<T> right { get; set; }
        }

        int[] largestValuesInTreeRows(Tree<int> t)
        {
            var list = new List<int>();
            recur(t, 0, list);
            return list.ToArray();
        }

        private void recur(Tree<int> tree, int level, List<int> list)
        {
            if (tree == null)
                return;

            if (level >= list.Count) list.Add(tree.value);
            else list[level] = Math.Max(list[level], tree.value);

            recur(tree.left, level + 1, list);
            recur(tree.right, level + 1, list);
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Tree<int> t = new Tree<int>()
            {
                value = -1,
                left = new Tree<int>() { value = 5 },
                right = new Tree<int>()
                {
                    value = 7,
                    right = new Tree<int>() { value = 1 }
                }
            };
            var r = p.largestValuesInTreeRows(t);
        }
    }
}
