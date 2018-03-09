using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace IsCryptSolution
{
    class Program
    {
        bool isCryptSolution(string[] crypt, char[][] solution)
        {
            var map = GetDictionary(solution);
            var uncrypt = new string[crypt.Length];
            var values = new ulong[crypt.Length];
            for (int i = 0; i < crypt.Length; i++)
                uncrypt[i] = Desencrypt(crypt[i], map);

            for (int i = 0; i < crypt.Length; i++)
            {
                string cryptValue = crypt[i];
                string uncryptValue = uncrypt[i];
                ulong currentValue = Convert.ToUInt64(uncryptValue);
                if (currentValue.ToString().Length != cryptValue.Length)
                    return false;
                values[i] = currentValue;
            }

            ulong sum = 0;
            foreach (ulong val in values.Take(values.Length - 1))
                sum += val;
            return sum == values[values.Length - 1];
        }

        private Dictionary<char, char> GetDictionary(char[][] map)
        {
            var dict = new Dictionary<char, char>();
            foreach (char[] val in map)
                dict[val[0]] = val[1];
            return dict;
        }

        private string Desencrypt(string s, Dictionary<char, char> map)
        {
            string value = string.Empty;
            foreach (char c in s)
                value += map[c];
            return value;
        }


        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.isCryptSolution(new[] { "SEND", "MORE", "MONEY" }, new[]
            {
                new []{'O','0'},
                new []{'M','1'},
                new []{'Y','2'},
                new []{'E','5'},
                new []{'N','6'},
                new []{'D','7'},
                new []{'R','8'},
                new []{'S','9'}
            }));
        }
    }
}
