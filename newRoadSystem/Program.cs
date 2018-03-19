using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newRoadSystem
{
    class Program
    {
        bool newRoadSystem(bool[][] roadRegister)
        {
            int length = roadRegister.Length;
            var incoming = new int[length];
            var outgoing = new int[length];

            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    if (roadRegister[i][j])
                    {
                        outgoing[i]++;
                        incoming[j]++;
                    }

            bool flag = true;
            for (int i = 0; flag && i < length; i++)
                flag = incoming[i] == outgoing[i];

            return flag;
        }

        static void Main(string[] args)
        {
        }
    }
}
