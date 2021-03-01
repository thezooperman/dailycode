using System.Collections.Generic;
using System.Linq;

namespace problems
{
    class RemoveMinSum
    {
        /*
           Remove all occurrences of any element for maximum array sum.
           Given an array of positive integers, remove all the occurrences
           of element to get the maximum sum of the remaining array

           Examples:

           Input : arr = {1, 1, 3}
           Output : 3
           On removing 1 from array we get {3} total value is 3

           Input : arr = {1, 1, 3, 3, 2, 2, 1, 1, 1}
           Output : 11
           On removing 2 from array we get {1, 1, 3, 3, 1, 1, 1} total value is 11
        */

        public int removeMinSum(int[] array)
        {
            int sum = 0;
            IDictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < array.Length; i++)
            {
                int val = array[i];
                sum += val;

                if (map.ContainsKey(val))
                    map[val]++;
                else
                    map.Add(val, 1);
            }

            int minVal = default(int);
            minVal = map.Min(x => x.Key * x.Value);

            return sum - minVal;
        }
    }
}