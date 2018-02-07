using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapDecoding
{
    class Program
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        private int modulo = (int)Math.Pow(10, 9);
        int mapDecoding(string message) { return message.Contains('0') ? 0 : mapDecoding1(message, 0) % (int)(Math.Pow(10, 7) + 7); }

        private int mapDecoding1(string message, int pos)
        {
            if (pos == message.Length)
                return 1;

            if (dict.ContainsKey(pos))
                return dict[pos];

            int num = mapDecoding1(message, pos + 1);
            if (pos < message.Length - 1)
            {
                int decode = 10 * Decode(message[pos]) + Decode(message[pos + 1]);
                if (decode < 27)
                    num += mapDecoding1(message, pos + 2);
            }
            return dict[pos] = num % modulo;
        }

        private int Decode(char c) { return c - 'A' + 1; }

        static void Main(string[] args)
        {
        }
    }
}
