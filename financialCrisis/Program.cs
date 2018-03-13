using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace financialCrisis
{
    class Program
    {
        bool[][][] financialCrisis(bool[][] roadRegister)
        {
            bool[][][] results = new bool[roadRegister.Length][][];

            int newLength = roadRegister.Length - 1;
            for (int i = 0; i < roadRegister.Length; i++)
            {
                var newRoads = new bool[newLength][];
                for (int j = 0; j < newLength; j++)
                    newRoads[j] = new bool[newLength];

                RemoveCity(newRoads, roadRegister, i);

                results[i] = newRoads;
            }

            return results;
        }

        private void RemoveCity(bool[][] newRoads, bool[][] roadRegister, int city)
        {
            int row = 0, col = 0;
            for (int i = 0; i < roadRegister.Length; i++)
                if (i != city)
                    for (int j = 0; j < roadRegister.Length; j++)
                        if (j != city)
                        {
                            newRoads[row][col++] = roadRegister[i][j];
                            if (col == roadRegister.Length - 1)
                            {
                                col = 0;
                                row++;
                            }
                        }
        }

        static void Main(string[] args)
        {
            var p = new Program();
            p.financialCrisis(new[]
            {
                new[] {false, true, true, false},
                new[] {true, false, true, false},
                new[] {true, true, false, true},
                new[] {false, false, true, false}
            });
        }
    }
}
