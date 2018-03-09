using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;

namespace findProfessor
{
    class Program
    {
        string findProfession(int level, int pos)
        {
            bool isEngineer = true;
            int leftPos = 1;
            int rightPos = (int)Math.Pow(2, level);
            while (leftPos < rightPos)
            {
                int mid = (rightPos + leftPos) / 2;
                if (pos > mid)
                {
                    leftPos = mid + 1;
                    isEngineer = ProfessionRight(isEngineer);
                }
                else
                {
                    rightPos = mid;
                    isEngineer = ProfessionLeft(isEngineer);
                }
            }
            return isEngineer ? "Engineer" : "Doctor";
        }

        private bool ProfessionLeft(bool isEngineer) { return isEngineer; }

        private bool ProfessionRight(bool isEngineer) { return !isEngineer; }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.findProfession(4, 2));
        }
    }
}
