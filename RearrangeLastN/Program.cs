using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RearrangeLastN
{
    class Program
    {
        // Definition for singly-linked list:
        class ListNode<T>
        {
            public T value { get; set; }
            public ListNode<T> next { get; set; }
        }

        ListNode<int> rearrangeLastN(ListNode<int> l, int n)
        {
            int length = GetLength(l);
            if (l == null || n == 0 || n == length)
                return l;

            ListNode<int> start = l, end = l, nodeBeforeStart = null;
            int lengthSubarray = 1;
            while (lengthSubarray++ < n)
                end = end.next;

            while (end.next != null)
            {
                nodeBeforeStart = start;
                start = start.next;
                end = end.next;
            }

            nodeBeforeStart.next = null;
            end.next = l;

            return start;
        }

        int GetLength(ListNode<int> list)
        {
            int count = 0;
            while (list != null)
            {
                list = list.next;
                count++;
            }
            return count;
        }


        static void Main(string[] args)
        {
        }
    }
}
