using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseNodesInKGroups
{
    class Program
    {
        // Definition for singly-linked list:
        class ListNode<T>
        {
            public T value { get; set; }
            public ListNode<T> next { get; set; }
        }

        ListNode<int> reverseNodesInKGroups(ListNode<int> l, int k)
        {
            var stack = new Stack<int>();
            ListNode<int> result = null, current = null;
            while (l != null)
            {
                stack.Push(l.value);
                l = l.next;

                if (stack.Count == k)
                {
                    ListNode<int> newKGroup = CreateReverseList(stack);
                    if (result == null)
                        result = current = newKGroup;
                    else
                        current.next = newKGroup;
                    while (current.next != null)
                        current = current.next;
                }
            }

            if (stack.Count > 0)
            {
                var bufferStack = new Stack<int>();

                while (stack.Count > 0)
                    bufferStack.Push(stack.Pop());

                if (result == null)
                    result = CreateReverseList(bufferStack);
                else
                    current.next = CreateReverseList(bufferStack);
            }

            return result;
        }

        ListNode<int> CreateReverseList(Stack<int> stack)
        {
            ListNode<int> list = null, current = null;
            while (stack.Count > 0)
            {
                var newNode = new ListNode<int>() { value = stack.Pop() };
                if (list == null)
                    list = current = newNode;
                else
                {
                    current.next = newNode;
                    current = current.next;
                }
            }
            return list;
        }


        static void Main(string[] args)
        {

        }
    }
}
