using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstNonRepeatingCharacter
{
    class Program
    {
        char firstNotRepeatingCharacter(string s)
        {
            var map = new byte[26];

            foreach (char currentCharacter in s)
            {
                int indexInMap = currentCharacter - 'a';
                map[indexInMap]++;
            }

            int bestIndex = -1;
            for (int i = 0; i < map.Length; i++)
                if (map[i] == 1)
                {
                    char mapCharacter = Convert.ToChar('a' + i);
                    for (int j = 0; j < s.Length; j++)
                    {
                        char currentCharacter = s[j];
                        if (mapCharacter == currentCharacter)
                        {
                            if (bestIndex == -1 || j < bestIndex)
                                bestIndex = j;
                            break;
                        }
                    }
                }

            return bestIndex == -1 ? '_' : s[bestIndex];
        }


        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.firstNotRepeatingCharacter("a"));
        }
    }
}
