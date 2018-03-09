using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitTreeSum
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

        long digitTreeSum(Tree<int> t)
        {
            return sum(t, 0);
        }

        private long sum(Tree<int> tree, long currentNum)
        {
            if (tree == null) return 0;
            currentNum = currentNum * 10 + tree.value;
            if (tree.left == null && tree.right == null) return currentNum;
            return sum(tree.left, currentNum) + sum(tree.right, currentNum);
        }


        static void Main(string[] args)
        {
        }
    }
}
