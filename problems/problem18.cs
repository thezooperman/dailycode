using System;
using System.Collections.Generic;
using System.Linq;

namespace problems
{
    class Problem18
    {
        /*
            Given an array of integers and a number k, where 1 <= k <= length
            of the array, compute the maximum values of each subarray of length k.

            For example, given array = [10, 5, 2, 7, 8, 7] and k = 3, we
            should get: [10, 7, 8, 8], since:

            10 = max(10, 5, 2)
            7 = max(5, 2, 7)
            8 = max(2, 7, 8)
            8 = max(7, 8, 7)

            Do this in O(n) time and O(k) space. You can modify the input array
            in-place and you do not need to store the results. You can simply
            print them out as you compute them.
        */


        // O(nk)
        public IEnumerable<int> problem18(int[] array, int k)
        {
            if (array == null || k <= 0 || array.Length == 0)
                yield return -1;

            for (int i = 0; i <= array.Length - k; i++)
                yield return array.AsSpan(i, k).ToArray().Max();
        }

        // O(n)
        public IEnumerable<int> problem18Optimized(int[] array, int k)
        {
            LinkedList<int> deque = new LinkedList<int>();
            int i = 0;

            // Find the first max in the window
            for (; i < k; i++)
            {
                while (deque.Count > 0 && array[deque.Last.Value] <= array[i])
                    deque.RemoveLast();

                deque.AddLast(i);
            }

            // iterate through the rest of the element
            for (; i < array.Length; i++)
            {
                // the first element is greatest, within the window, at this point
                yield return array[deque.First.Value];

                // Remove the elements which are out of window
                while (deque.Count > 0 && deque.First.Value <= i - k)
                    deque.RemoveFirst();

                // Remove the smaller elements
                while (deque.Count > 0 && array[deque.Last.Value] <= array[i])
                    deque.RemoveLast();

                // add the element which is greater than the current
                deque.AddLast(i);
            }

            // Return the first element, which is greatest in the window
            if (deque.Count > 0)
                yield return array[deque.First.Value];
        }
    }
}