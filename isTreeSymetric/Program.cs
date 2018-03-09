using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isTreeSymetric
{
    class Program
    {
        // Definition for binary tree:
        class Tree<T>
        {
            public T value { get; set; }
            public Tree<T> left { get; set; }
            public Tree<T> right { get; set; }
        }

        bool isTreeSymmetric(Tree<int> t)
        {
            if (t == null)
                return true;

            var queue = new Queue<Tree<int>>();
            var queueMirror = new Queue<Tree<int>>();

            AddTreeToQueue(t.left, queue);
            AddTreeToQueue(t.right, queueMirror);

            while (queue.Count > 0 && queueMirror.Count > 0)
            {
                var tree = queue.Dequeue();
                var treeMirror = queueMirror.Dequeue();

                if (tree.value != treeMirror.value ||
                    AddTreeToQueue(tree.left, queue) != AddTreeToQueue(treeMirror.right, queueMirror) ||
                    AddTreeToQueue(tree.right, queue) != AddTreeToQueue(treeMirror.left, queueMirror))
                    return false;
            }

            return queue.Count == 0 && queueMirror.Count == 0;
        }

        private bool AddTreeToQueue(Tree<int> tree, Queue<Tree<int>> queue)
        {
            if (tree == null) return false;
            queue.Enqueue(tree);
            return true;
        }

        static void Main(string[] args)
        {
        }
    }
}
