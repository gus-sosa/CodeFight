using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace mapDecoding
{
    class Program
    {
        int mapDecoding(string message)
        {
            var counter = new ulong[message.Length + 1];
            counter[counter.Length - 1] = 1;
            ulong modulo = (ulong)Math.Pow(10, 12);

            for (int i = message.Length - 1; i >= 0; i--)
                if (message[i] != '0')
                {
                    if (i + 1 < message.Length)
                    {
                        counter[i] += counter[i + 1];
                        int num = Decode(message[i]) * 10 + Decode(message[i + 1]);
                        if (num < 27)
                        {
                            if (i + 2 < message.Length) counter[i] += counter[i + 2];
                            else counter[i] += 1;
                        }
                    }
                    else counter[i] += 1;

                    counter[i] %= modulo;
                }

            return (int)(counter[0] % ((ulong)Math.Pow(10, 9) + 7));
        }

        private int Decode(char c) { return c - '0'; }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.mapDecoding("1221112111122221211221221212212212111221222212122221222112122212121212221212122221211112212212211211"));
        }
    }
}
