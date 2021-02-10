using System;
using System.Linq;

namespace problems
{
    internal class ReverseArrays
    {
        /*
            Reverse array in groups 

            Given an array arr[] of positive integers of size N.
            Reverse every sub-array group of size K.

            Example 1:

            Input:
            N = 5, K = 3
            arr[] = {1,2,3,4,5}
            Output: 3 2 1 5 4
            Explanation: First group consists of elements
            1, 2, 3. Second group consists of 4,5.
            
            Example 2:

            Input:
            N = 4, K = 3
            arr[] = {5,6,8,9}
            Output: 8 6 5 9

            Expected Time Complexity: O(N)
        */
        internal void reverArrays(int[] revArray, int k)
        {
            if (revArray.Length < k)
                revArray.OrderByDescending(_ => _);

            int len = revArray.Length;

            for (int i = 0; i < len; i = i + k)
            {
                // mark left pointer
                int left = i;

                // mark right pointer
                // if rem items are less than k
                // pick n-1, else pick i + k - 1
                int right = Math.Min(i + k - 1, len - 1);

                // till left < right, swap elements
                while (left < right)
                {
                    (revArray[right], revArray[left]) = (revArray[left], revArray[right]);
                    right--;
                    left++;
                }
            }
        }
    }
}