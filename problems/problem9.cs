using System;

namespace problems
{
    class Problem9
    {
        /*
        Given a list of integers, write a function that returns the largest sum
        of non-adjacent numbers. Numbers can be 0 or negative.

        For example, [2, 4, 6, 2, 5] should return 13, since we pick 2, 6, and 5.
        [5, 1, 1, 5] should return 10, since we pick 5 and 5.

        Follow-up: Can you do this in O(N) time and constant space?
        */
        public int problem9(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return 0;

            if (arr.Length == 1)
                return arr[0];

            int[] maxSum = new int[arr.Length];

            // Seed first two values with the largest
            // of them
            maxSum[0] = Math.Max(0, arr[0]);
            maxSum[1] = Math.Max(maxSum[0], arr[1]);

            // precompute and store previous results
            for (int i = 2; i < arr.Length; i++)
            {
                maxSum[i] = Math.Max(maxSum[i - 1], maxSum[i - 2] + arr[i]);
            }
            return maxSum[arr.Length - 1];
        }
    }
}