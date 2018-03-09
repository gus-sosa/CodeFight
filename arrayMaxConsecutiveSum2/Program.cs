using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrayMaxConsecutiveSum2
{
    class Program
    {
        int arrayMaxConsecutiveSum2(int[] inputArray)
        {
            int sumMax = inputArray[0];
            int localMax = inputArray[0];
            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] + localMax > inputArray[i])
                    localMax = inputArray[i] + localMax;
                else
                    localMax = inputArray[i];

                if (localMax > sumMax)
                    sumMax = localMax;
            }
            return sumMax;
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.arrayMaxConsecutiveSum2(new int[] { -3, -2, -1, -4 }));
        }
    }
}
