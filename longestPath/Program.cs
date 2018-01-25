using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace longestPath
{
    class Program
    {
        class Tree<T>
        {
            public T Value { get; set; }
            public List<Tree<T>> Children { get; }

            public Tree()
            {
                Children = new List<Tree<T>>();
            }

            public void AddChild(Tree<T> tree)
            {
                Children.Add(tree);
            }
        }

        private static Dictionary<int, Tree<string>> dict = new Dictionary<int, Tree<string>>();
        int longestPath(string fileSystem)
        {
            fileSystem = fileSystem.Replace("\f", "\\f").Replace("\t", "\\t");
            Tree<string> tree = BuildTree(fileSystem);
            return longestPath1(tree, tree.Value);
        }

        private Tree<string> BuildTree(string fileSystem)
        {
            var tokens = GetTokens(fileSystem);
            var tree = new Tree<string>() { Value = string.Empty };
            dict[-1] = tree;
            for (int i = 0; i < tokens.Count; i++)
            {
                string currentToken = tokens[i], cad;
                int level = GetLevel(currentToken, out cad);
                Tree<string> rightMost = GetRightMostInLevel(level - 1);
                var newNode = new Tree<string>() { Value = cad };
                rightMost.AddChild(newNode);
                UpdateDict(newNode, level);
            }
            return tree;
        }

        private Tree<string> GetRightMostInLevel(int level) { return dict[level]; }

        private void UpdateDict(Tree<string> tree, int level) { dict[level] = tree; }

        private List<string> GetTokens(string fileSystem)
        {
            var indexOfRootFolder = fileSystem.IndexOf('\\');
            var tokens = new List<string> { indexOfRootFolder != -1 ? fileSystem.Substring(0, indexOfRootFolder) : fileSystem };
            var regex = new Regex("(\\\\f(\\\\t)*)([^\\\\]+)");
            var otherTokens = regex.Matches(fileSystem);
            foreach (Match token in otherTokens)
                tokens.Add(token.Groups[0].Value);
            return tokens;
        }

        private int GetLevel(string currentToken, out string cad)
        {
            if (!currentToken.StartsWith("\\f"))
            {
                cad = currentToken;
                return 0;
            }

            currentToken = currentToken.Remove(0, 2);
            int level = 0;
            while (currentToken[0] == '\\')
            {
                currentToken = currentToken.Remove(0, 2);
                level++;
            }
            cad = currentToken;
            return level;
        }

        private int longestPath1(Tree<string> tree, string path)
        {
            if (tree == null) return 0;
            int length = tree.Value.Contains(".") ? path.Length : 0;
            foreach (Tree<string> treeChild in tree.Children)
                length = Math.Max(length, longestPath1(treeChild, path == string.Empty ? treeChild.Value : string.Format("{0}/{1}", path, treeChild.Value)));
            return length;
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.longestPath("user\f\tpictures\f\tdocuments\f\t\tnotes.txt"));
        }
    }
}
