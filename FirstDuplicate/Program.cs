using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDuplicate
{
    class Program
    {
        static int firstDuplicate(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int currentNum = Math.Abs(a[i]);
                int currentIndex = currentNum - 1;
                if (a[currentIndex] < 0)
                {
                    return currentNum;
                }
                else
                    a[currentIndex] *= -1;
            }

            return -1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(firstDuplicate(new int[] { 8, 4, 6, 2, 6, 4, 7, 9, 5, 8 }));
        }
    }
}
