using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deleteFromBST
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

        Tree<int> deleteFromBST(Tree<int> t, int[] queries)
        {
            foreach (int query in queries)
                deleteFromBST1(query, ref t);
            return t;
        }

        private void deleteFromBST1(int query, ref Tree<int> t)
        {
            Tree<int> current = t;
            Tree<int> parent = null;

            while (current != null && current.value != query)
            {
                parent = current;
                current = query > current.value ? current.right : current.left;
            }

            if (current != null)
            {
                if (current.left != null) current.value = RemoveNode(current);
                else
                {
                    Tree<int> node = current.right;
                    if (parent == null) t = node;
                    else
                    {
                        if (parent.left == current) parent.left = node;
                        else parent.right = node;
                    }
                }
            }
        }

        private int RemoveNode(Tree<int> current)
        {
            Tree<int> parent = current;
            Tree<int> child = current.left;
            while (child.right != null)
            {
                parent = child;
                child = child.right;
            }
            if (parent.left == child) parent.left = child.left;
            else parent.right = child.left;
            return child.value;
        }

        static void Main(string[] args)
        {
            var p = new Program();
            var queries = new[] { 4, 5, 6 };
            var tree = new Tree<int>()
            {
                value = 5,
                left = new Tree<int>()
                {
                    value = 2,
                    left = new Tree<int>()
                    {
                        value = 1
                    },
                    right = new Tree<int>()
                    {
                        value = 3
                    }
                },
                right = new Tree<int>()
                {
                    value = 6,
                    left = null,
                    right = new Tree<int>()
                    {
                        value = 8,
                        left = new Tree<int>()
                        {
                            value = 7,
                            left = null,
                            right = null
                        },
                        right = null
                    }
                }
            };
            var r = p.deleteFromBST(tree, queries);
        }
    }
}
