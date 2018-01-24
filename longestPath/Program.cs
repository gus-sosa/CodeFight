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
            var tokens = GetTokens(fileSystem);
            var tree = new Tree<string>() { Value = tokens[0] };
            dict[0] = tree;
            for (int i = 1; i < tokens.Count; i++)
            {
                string currentToken = tokens[i], cad;
                int level = GetLevel(currentToken, out cad);
                Tree<string> rightMost = GetRightMostInLevel(level - 1);
                var newNode = new Tree<string>() { Value = cad };
                rightMost.AddChild(newNode);
                UpdateDict(newNode, level);
            }
            return longestPath1(tree, tree.Value);
        }

        private Tree<string> GetRightMostInLevel(int level) { return dict[level]; }

        private void UpdateDict(Tree<string> tree, int level) { dict[level] = tree; }

        private List<string> GetTokens(string fileSystem)
        {
            var indexOfRootFolder = fileSystem.IndexOf('\\');
            var tokens = new List<string> { fileSystem.Substring(0, indexOfRootFolder) };
            var regex = new Regex("(\\\\f(\\\\t)+)([^\\\\]+)");
            var otherTokens = regex.Matches(fileSystem);
            foreach (Match token in otherTokens)
                tokens.Add(token.Groups[0].Value);
            return tokens;
        }

        private int GetLevel(string currentToken, out string cad)
        {
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
            int length = path.Length;
            foreach (Tree<string> treeChild in tree.Children)
                length = Math.Max(length, longestPath1(treeChild, string.Format("{0}/{1}", path, treeChild.Value)));
            return length;
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.longestPath("user\\f\\tpictures\\f\\t\\tphoto.png\\f\\t\\tcamera\\f\\tdocuments\\f\\t\\tlectures\\f\\t\\t\\tnotes.txt"));
        }
    }
}
