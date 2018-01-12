using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hasPathWithGivenSum
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

        bool hasPathWithGivenSum(Tree<int> t, int s)
        {
            if (t == null)
                return s == 0;

            var queue = new Queue<Tuple<Tree<int>, int>>();
            queue.Enqueue(Tuple.Create(t, t.value));

            bool flag = false;
            while (!flag && queue.Count > 0)
            {
                var current = queue.Dequeue();
                var currentTree = current.Item1;
                var currentSum = current.Item2;

                if (IsLeaf(currentTree)) flag = currentSum == s;
                else
                {
                    if (currentTree.left != null)
                        queue.Enqueue(Tuple.Create(currentTree.left, currentSum + currentTree.left.value));
                    if (currentTree.right != null)
                        queue.Enqueue(Tuple.Create(currentTree.right, currentSum + currentTree.right.value));
                }
            }

            return flag;
        }

        private bool IsLeaf(Tree<int> tree)
        {
            return tree != null && tree.left == null && tree.right == null;
        }

        static void Main(string[] args)
        {
        }
    }
}
