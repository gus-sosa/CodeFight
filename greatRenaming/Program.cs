using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greatRenaming
{
    class Program
    {
        bool[][] greatRenaming(bool[][] roadRegister)
        {
            int n = roadRegister.Length;
            var newRegister = new bool[n][];

            for (int i = 0; i < n; i++)
                if (i == 0) newRegister[0] = Shift(roadRegister[roadRegister.Length - 1]);
                else newRegister[i] = Shift(roadRegister[i - 1]);

            return newRegister;
        }

        private bool[] Shift(bool[] arr)
        {
            var newArr = new bool[arr.Length];
            Array.Copy(arr, 0, newArr, 1, arr.Length - 1);
            newArr[0] = arr[arr.Length - 1];
            return newArr;
        }

        static void Main(string[] args)
        {

        }
    }
}
