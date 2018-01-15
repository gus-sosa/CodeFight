using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isSubtree
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

        bool isSubtree(Tree<int> t1, Tree<int> t2)
        {
            return t2 == null
                   || (t1 != null
                   && (IsEqual(t1, t2)
                   || (t1.left != null && isSubtree(t1.left, t2))
                   || (t1.right != null && isSubtree(t1.right, t2))));
        }

        private bool IsEqual(Tree<int> t1, Tree<int> t2)
        {
            if (t1 == null && t2 == null)
                return true;

            if (t1 == null || t2 == null)
                return false;

            if (t1.value != t2.value)
                return false;

            return IsEqual(t1.left, t2.left) && IsEqual(t1.right, t2.right);
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.isSubtree());
        }
    }
}
