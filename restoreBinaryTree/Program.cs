using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restoreBinaryTree
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

        Tree<int> restoreBinaryTree(int[] inorder, int[] preorder)
        {
            if (inorder.Length == 0)
                return null;

            int parent = preorder[0];
            int[] inorder_left, inorder_right, preorder_left, preorder_right;
            GetInOrderChildren(inorder, parent, out inorder_left, out inorder_right);
            GetPreorderChildren(preorder, inorder_left, inorder_right, out preorder_left, out preorder_right);

            return new Tree<int>()
            {
                value = parent,
                left = restoreBinaryTree(inorder_left, preorder_left),
                right = restoreBinaryTree(inorder_right, preorder_right)
            };
        }

        private void GetPreorderChildren(int[] preorder, int[] inorderLeft, int[] inorderRight, out int[] preorderLeft, out int[] preorderRight)
        {
            var leftChildren = new List<int>();
            var rightChildren = new List<int>();

            var leftSet = new HashSet<int>();
            foreach (int i in inorderLeft)
                leftSet.Add(i);

            var righSet = new HashSet<int>();
            foreach (int i in inorderRight)
                righSet.Add(i);

            foreach (int i in preorder)
                if (leftSet.Contains(i)) leftChildren.Add(i);
                else if (righSet.Contains(i)) rightChildren.Add(i);

            preorderLeft = leftChildren.ToArray();
            preorderRight = rightChildren.ToArray();
        }

        private void GetInOrderChildren(int[] inorder, int parent, out int[] inorderLeft, out int[] inorderRight)
        {
            var leftChildren = new List<int>();
            var rightChildren = new List<int>();

            int pos = 0;
            while (inorder[pos] != parent)
                leftChildren.Add(inorder[pos++]);

            while (++pos < inorder.Length)
                rightChildren.Add(inorder[pos]);

            inorderLeft = leftChildren.ToArray();
            inorderRight = rightChildren.ToArray();
        }
        static void Main(string[] args)
        {
        }
    }
}
