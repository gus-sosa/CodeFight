using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minSubstringWithAllChars
{
    class Program
    {
        string minSubstringWithAllChars(string s, string t)
        {
            if (string.IsNullOrEmpty(t))
                return string.Empty;

            var hash = new HashSet<char>(t);
            var comparerHash = new HashSet<char>();
            int iStartBest = -1, iEndBest = 0;
            for (int i = 0; i < s.Length; i++)
                for (int j = i; j < s.Length; j++)
                {
                    comparerHash.Clear();
                    for (int k = i; k <= j; k++)
                        comparerHash.Add(s[k]);
                    if (comparerHash.IsSupersetOf(hash) && (iStartBest == -1 || j - i < iEndBest - iStartBest))
                    {
                        iStartBest = i;
                        iEndBest = j;
                    }
                }

            return iStartBest == -1 ? string.Empty : s.Substring(iStartBest, iEndBest - iStartBest + 1);
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.minSubstringWithAllChars("abz", ""));
        }
    }
}
