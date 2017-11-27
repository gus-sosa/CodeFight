using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoHugeNumbers
{
    class Program
    {
        const int MOD = 10000;
        const int LEN = MOD - 1;

        class ListNode<T>
        {
            public T value { get; set; }
            public ListNode<T> next { get; set; }
        }

        ListNode<int> addTwoHugeNumbers(ListNode<int> a, ListNode<int> b)
        {
            return addTwoHugeNumbers(a, b, 0);
        }

        private ListNode<int> addTwoHugeNumbers(ListNode<int> a, ListNode<int> b, int rest)
        {
            if (a == null && b == null)
            {
                ListNode<int> result = null;
                ListNode<int> current = null;
                while (rest > 0)
                {
                    var newNode = new ListNode<int>() { value = rest % MOD };
                    if (result == null)
                    {
                        result = current = newNode;
                    }
                    else
                    {
                        current.next = newNode;
                        current = current.next;
                    }
                    rest = rest / MOD;
                }

                return result;
            }

            if (a == null || b == null)
            {
                var noNullFactor = a ?? b;
                ListNode<int> result = null;
                ListNode<int> current = null;
                while (noNullFactor != null || rest > 0)
                {
                    int currentSum = (b == null ? 0 : b.value) + rest;
                    int currentValue = currentSum % MOD;
                    int nextValue = currentSum / MOD;

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
                }

                return result;
            }

            int CurrentSum = a.value + b.value + rest;
            int CurrentValue = CurrentSum % MOD;
            int nextRest = CurrentSum / MOD;
            return new ListNode<int>()
            {
                value = CurrentValue,
                next = addTwoHugeNumbers(a.next, b.next, nextRest)
            };
        }

        static void Main(string[] args)
        {
        }
    }
}
