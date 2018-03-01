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

        Dictionary<int, int> store = new Dictionary<int, int>();
        private int mod = Convert.ToInt32(Math.Pow(10, 9) + 7);
        private string _message;
        int mapDecoding(string message)
        {
            _message = message;
            return mapdDecodingRec(message.Length);
        }

        private int mapdDecodingRec(int length)
        {
            if (length <= 0)
                return 1;

            if (store.ContainsKey(length))
                return store[length];

            if (_message[_message.Length - length] == '0')
                return 0;

            int result = mapdDecodingRec(length - 1);
            if (length >= 2)
            {
                int num = Convert.ToInt32(_message[_message.Length - length] - '0') * 10 + Convert.ToInt32(_message[_message.Length - length + 1] - '0');
                if (num <= 26)
                    result += mapdDecodingRec(length - 2);
            }

            return store[length] = result % mod;
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.mapDecoding("123"));
        }
    }
}

