using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveKFromList
{
    class Program
    {
        // Definition for singly-linked list:
        class ListNode<T>
        {
            public T value { get; set; }
            public ListNode<T> next { get; set; }
        }

        ListNode<int> removeKFromList(ListNode<int> l, int k)
        {
            while (l != null && l.value == k)
                l = l.next;

            var current = l;
            ListNode<int> previous = null;

            while (current != null)
                if (current.value == k)
                {
                    if (previous != null)
                        previous.next = current.next;
                    current = current.next;
                }
                else
                {
                    previous = current;
                    current = current.next;
                }

            return l;
        }

        static void Main(string[] args)
        {
            var p = new Program();
            PrintList(p.removeKFromList(CreateList(new int[] { 3, 1, 2, 3, 4, 3, 3, 3, 3, 5, 3 }), 3));
        }

        private static void PrintList(ListNode<int> listNode)
        {
            var current = listNode;
            while (current != null)
            {
                Console.Write($"{current.value} ");
                current = current.next;
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static ListNode<int> CreateList(int[] nums)
        {
            var list = nums.Select(i => new ListNode<int>() { value = i }).ToArray();
            for (int i = 0; i < list.Length - 1; i++)
                list[i].next = list[i + 1];
            return list[0];
        }
    }
}
