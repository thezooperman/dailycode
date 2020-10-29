using System;
using System.Collections.Generic;
using System.Linq;

namespace problems
{
    class Problem2
    {
        /*
            Given an array of integers, return a new array such that
            each element at index i of the new array is the product
            of all the numbers in the original array except the one
            at i.

            For example, if our input was [1, 2, 3, 4, 5], the expected
            output would be [120, 60, 40, 30, 24]. If our input was
            [3, 2, 1], the expected output would be [2, 3, 6].

            Follow-up: what if you can't use division?
        */

        public int[] problem2(int[] arr)
        {
            int totalProduct = arr.Aggregate(1, (a, b) => a * b);

            var result = new List<int>(arr.Length);

            foreach (int num in arr)
                result.Add(totalProduct / num);

            return result.ToArray<int>();
        }

        public int[] problem2_1(int[] arr)
        {
            var result = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                result[i] = 1;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (j != i)
                        result[i] *= arr[j];
                }
            }
            return result;
        }
    }
}