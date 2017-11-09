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
            int bestDuplicate = -1;
            int bestDuplicateIndex = -1;
            for (int i = 0; i < a.Length; i++)
            {
                int currentValue = a[i];
                if (currentValue == i + 1)
                    continue;

                //swapping elements
                a[i] = -1;
                int currentIndex = i;
                int nextIndex = currentValue - 1;
                while (a[nextIndex] != -1)
                    if (a[nextIndex] == currentValue)
                    {
                        int maxIndex = Math.Max(nextIndex, currentIndex);
                        if (bestDuplicateIndex == -1 || maxIndex < bestDuplicateIndex)
                        {
                            bestDuplicateIndex = maxIndex;
                            bestDuplicate = currentValue;
                        }
                        a[i] = currentValue;
                        break;
                    }
                    else
                    {
                        int tmp = a[nextIndex];
                        a[nextIndex] = currentValue;
                        a[currentIndex] = -1;
                        currentIndex = nextIndex;
                        currentValue = tmp;
                        nextIndex = currentValue - 1;
                    }
            }

            return bestDuplicateIndex == -1 ? -1 : bestDuplicate;
        }


        static void Main(string[] args)
        {
            Console.WriteLine(firstDuplicate(new int[] { 2, 4, 3, 5, 1 }));
        }
    }
}
