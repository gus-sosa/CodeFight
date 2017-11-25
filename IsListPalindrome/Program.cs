using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsListPalindrome
{
    class Program
    {
        class ListNode<T>
        {
            public T value { get; set; }
            public ListNode<T> next { get; set; }
        }

        bool isListPalindrome(ListNode<int> l)
        {
            int length = GetLength(l);
            int halfLength = length / 2;

            if (length == 1)
                return true;
            if (length == 2)
                return l.value == l.next.value;

            var current = l;
            var reversePointer = current;

            for (int i = 0; i < halfLength; i++)
            {
                if (i == 0)
                {
                    reversePointer = current;
                    current = current.next;
                    reversePointer.next = null;
                    continue;
                }

                var tmp = current;
                current = current.next;
                tmp.next = reversePointer;
                reversePointer = tmp;
            }

            if (length % 2 == 1)
                current = current.next;

            while (current != null)
            {
                if (current.value != reversePointer.value)
                    return false;
                current = current.next;
                reversePointer = reversePointer.next;
            }

            return true;
        }

        int GetLength(ListNode<int> l)
        {
            int length = 0;
            while (l != null)
            {
                l = l.next;
                length++;
            }
            return length;
        }

        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(p.isListPalindrome(new ListNode<int>()
            {
                value = 1,
                next = new ListNode<int>()
                {
                    value = 2,
                    next = new ListNode<int>()
                    {
                        value = 2,
                        next = new ListNode<int>()
                        {
                            value = 4,
                        }
                    }
                }
            }));
        }
    }
}
