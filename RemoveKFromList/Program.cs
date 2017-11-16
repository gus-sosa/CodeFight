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
            PrintList(p.removeKFromList(CreateList(new int[] { 3, 1, 2, 3, 4, 5 }), 3));
        }

        private static void PrintList(ListNode<int> listNode)
        {
            throw new NotImplementedException();
        }

        private static ListNode<int> CreateList(int[] nums)
        {
            var list=new ListNode<int>();
            var current = list;
            foreach (int num in nums)
            {
                current.value = num;
                
            }
        }
    }
}
