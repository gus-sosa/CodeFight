using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sumOfTwo
{
    class Program
    {
        bool sumOfTwo(int[] a, int[] b, int v)
        {
            var dic = new Hashtable();
            foreach (var i in a)
            {
                var term = v - i;
                if (!dic.ContainsKey(term))
                    dic.Add(term, 1);
            }

            foreach (var i in b)
            {
                if (dic.ContainsKey(i))
                    return true;
            }

            return false;
        }


        static void Main(string[] args)
        {
        }
    }
}
