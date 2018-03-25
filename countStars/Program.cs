using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace countStars
{
    class Program
    {
        int countStars(bool[][] adj)
        {
            int length = adj.Length, numStars = 0;
            var marks = new bool[length];
            var comp = new int[length];
            for (int i = 0; i < length; i++)
                if (!marks[i])
                {
                    numStars++;
                    markConexComponent(i, adj, numStars, marks, comp);
                }

            for (int i = 1; true; i++)
            {
                var nodes = comp.Select((value, index) => value == i ? index : -1).Where(v => v >= 0);
                if (!nodes.Any())
                    break;

                if (nodes.Count() < 2 || nodes.Any(n => adj[n][n]))
                {
                    numStars--;
                    continue;
                }

                int degree1 = nodes.Count(n => adj[n].Count(nadj => nadj) == 1);
                int degreGraterThan1 = nodes.Count(n => adj[n].Count(nadj => nadj) > 1);

                if (!(nodes.Count() - degree1 <= 1 && degreGraterThan1 <= 1))
                    numStars--;
            }

            return numStars;
        }

        private void markConexComponent(int currentNode, bool[][] adj, int compNum, bool[] marks, int[] comp)
        {
            marks[currentNode] = true;
            comp[currentNode] = compNum;
            for (int i = 0; i < adj.Length; i++)
                if (adj[currentNode][i] && !marks[i])
                    markConexComponent(i, adj, compNum, marks, comp);
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.countStars(new[]{new[]{false,false,false,false,false,true,false,true,false},
                new[]{false,false,false,false,false,false,false,false,true},
                new[]{false,false,false,true,false,false,true,false,false},
                new[]{false,false,true,false,false,false,false,false,false},
                new[]{false,false,false,false,false,false,false,false,true},
                new[]{true,false,false,false,false,false,false,false,false},
                new[]{false,false,true,false,false,false,false,false,false},
                new[]{true,false,false,false,false,false,false,false,false},
                new[]{false,true,false,false,true,false,false,false,true}}));
        }
    }
}
