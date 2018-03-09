using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTwoLinkedLists
{
    class Program
    {
        // Definition for singly-linked list:
        class ListNode<T>
        {
            public T value { get; set; }
            public ListNode<T> next { get; set; }
        }

        ListNode<int> mergeTwoLinkedLists(ListNode<int> l1, ListNode<int> l2)
        {
            ListNode<int> result = null;
            ListNode<int> current = null;

            while (l1 != null && l2 != null)
            {
                var newNode = new ListNode<int>() { value = Math.Min(l1.value, l2.value) };
                if (result == null)
                    result = current = newNode;
                else
                    current.next = newNode;

                if (l1.value <= l2.value)
                    l1 = l1.next;
                else
                    l2 = l2.next;

                if (current.next != null)
                    current = current.next;
            }

            var nonEmptyList = l1 == null ? l2 : l1;
            while (nonEmptyList != null)
            {
                var newNode = new ListNode<int>() { value = nonEmptyList.value };
                if (result == null)
                    result = current = newNode;
                else
                    current.next = newNode;
                if (current.next != null)
                    current = current.next;
                nonEmptyList = nonEmptyList.next;
            }

            return result;
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Print(p.mergeTwoLinkedLists(/*new ListNode<int>()
            {
                value = 1,
                next = new ListNode<int>()
                {
                    value = 1,
                    next = new ListNode<int>()
                    {
                        value = 2,
                        next = new ListNode<int>()
                        {
                            value = 4
                        }
                    }
                }
            }*/null, new ListNode<int>()
               {
                   value = 0,
                   next = new ListNode<int>()
                   {
                       value = 3,
                       next = new ListNode<int>() { value = 5 }
                   }
               }));
        }

        private static void Print(ListNode<int> listNode)
        {
            while (listNode != null)
            {
                Console.WriteLine(listNode.value);
                listNode = listNode.next;
            }
        }
    }
}
