using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreFollowingPatterns
{
    class Program
    {
        bool areFollowingPatterns(string[] strings, string[] patterns)
        {
            return areFollowingPatterns1(strings, patterns, true);
        }

        bool areFollowingPatterns1(string[] strings, string[] patterns, bool reverse)
        {
            var dict = new Dictionary<string, List<int>>();
            for (int i = 0; i < strings.Length; i++)
            {
                string s = strings[i];
                if (!dict.ContainsKey(s))
                {
                    dict[s] = new List<int>() { i };
                }
                else
                {
                    List<int> patternIndexes = dict[s];
                    foreach (int patternIndex in patternIndexes)
                        if (patterns[i] != patterns[patternIndex])
                            return false;
                }
            }

            return !reverse || areFollowingPatterns1(patterns, strings, false);
        }


        static void Main(string[] args)
        {
        }
    }
}
