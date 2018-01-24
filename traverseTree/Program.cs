using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traverseTree
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
        int[] traverseTree(Tree<int> t)
        {
            var list = new List<int>();
            var queue = new Queue<Tree<int>>();
            queue.Enqueue(t);
            while (queue.Count > 0)
            {
                Tree<int> current = queue.Dequeue();
                if (current == null) continue;
                list.Add(current.value);
                queue.Enqueue(current.left);
                queue.Enqueue(current.right);
            }
            return list.ToArray();
        }


        static void Main(string[] args)
        {
        }
    }
}
