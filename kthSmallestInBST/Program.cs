using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kthSmallestInBST
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

        int kthSmallestInBST(Tree<int> t, int k)
        {
            return recur(t, ref k);
        }

        int recur(Tree<int> t, ref int k)
        {
            if (t.left != null)
            {
                int r = recur(t.left, ref k);
                if (k == 0)
                    return r;
            }
            k--;
            if (k == 0)
                return t.value;
            if (t.right != null)
            {
                int r = recur(t.right, ref k);
                if (k == 0)
                    return r;
            }
            return 0;
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.kthSmallestInBST(new Tree<int>()
            {
                value = 1,
                left = new Tree<int>() { value = 0 },
                right = new Tree<int>() { value = 2 }
            }, 3));
        }
    }
}
