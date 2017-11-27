using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoHugeNumbers
{
    class Program
    {
        class ListNode<T>
        {
            public T value { get; set; }
            public ListNode<T> next { get; set; }
        }

        ListNode<int> addTwoHugeNumbers(ListNode<int> a, ListNode<int> b)
        {
            return reverse(addTwoHugeNumbers1(reverse(a), reverse(b), 0));
        }

        ListNode<int> reverse(ListNode<int> list)
        {
            var stack = new Stack<int>();
            while (list != null)
            {
                stack.Push(list.value);
                list = list.next;
            }

            if (stack.Count == 0)
                return null;
            var result = new ListNode<int>() { value = stack.Pop() };
            var current = result;

            while (stack.Count > 0)
            {
                current.next = new ListNode<int>() { value = stack.Pop() };
                current = current.next;
            }

            return result;
        }

        ListNode<int> addTwoHugeNumbers1(ListNode<int> a, ListNode<int> b, int rest)
        {
            if (a == null || b == null)
            {
                var noNullFactor = a ?? b;
                ListNode<int> result = null;
                ListNode<int> current = null;
                while (noNullFactor != null || rest > 0)
                {
                    int currentSum = (noNullFactor?.value ?? 0) + rest;
                    int currentValue = currentSum % 10000;
                    int nextValue = currentSum / 10000;

                    var currentNode = new ListNode<int>() { value = currentValue };
                    if (result == null)
                    {
                        result = current = currentNode;
                    }
                    else
                    {
                        current.next = currentNode;
                        current = current.next;
                    }

                    rest = nextValue;
                    noNullFactor = noNullFactor?.next;
                }

                return result;
            }

            int CurrentSum = a.value + b.value + rest;
            int CurrentValue = CurrentSum % 10000;
            int nextRest = CurrentSum / 10000;
            return new ListNode<int>()
            {
                value = CurrentValue,
                next = addTwoHugeNumbers1(a.next, b.next, nextRest)
            };
        }

        static void Main(string[] args)
        {
            var p = new Program();
            var a = new ListNode<int>()
            {
                value = 9876,
                next = new ListNode<int>()
                {
                    value = 5432,
                    next = new ListNode<int>()
                    {
                        value = 1999
                    }
                }
            };
            var b = new ListNode<int>()
            {
                value = 1,
                next = new ListNode<int>()
                {
                    value = 8001
                }
            };
            var result = p.addTwoHugeNumbers(a, b);
            PrintResult(result);
        }

        private static void PrintResult(ListNode<int> result)
        {
            while (result != null)
            {
                Console.WriteLine(result.value);
                result = result.next;
            }
        }
    }
}
