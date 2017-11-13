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
            int firstIndex = -1;
            char firstNonRepeatingCharacter = '_';
            bool[] map = new bool[26];

            for (int i = 0; i < s.Length; i++)
            {
                char currentCharacter = s[i];
                int indexInMap = currentCharacter - 'a';
                if (map[indexInMap])
                {
                    
                }
                else
                {
                        
                }
            }

            return firstNonRepeatingCharacter;
        }


        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.firstNotRepeatingCharacter("a"));
        }
    }
}
