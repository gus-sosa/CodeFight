using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainsDuplicates
{
    class Program
    {
        bool containsDuplicates(int[] a)
        {
            var l = new Dictionary<int, bool>();
            for (int i = 0; i < a.Length; i++)
            {
                if (l.ContainsKey(a[i]))
                    return true;
                l[a[i]] = true;
            }
            return false;
        }


        static void Main(string[] args)
        {
        }
    }
}
