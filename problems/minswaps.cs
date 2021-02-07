using System.Collections.Generic;
using System.Linq;

namespace problems
{
    class MinimumSwapsToSort
    {
        /*
           Minimum number of swaps required to sort an array.

           Given an array of n distinct elements, find the
           minimum number of swaps required to sort the array.

           Examples: 
            Input : {4, 3, 2, 1}
            Output : 2
            Explanation : Swap index 0 with 3 and 1 with 2 to 
                        form the sorted array {1, 2, 3, 4}.

            Input : {1, 5, 4, 3, 2}
            Output : 2
        */

        public int minimumSwaps(int[] array)
        {
            IList<KeyValuePair<int, int>> values = new List<KeyValuePair<int, int>>(array.Length);
            for (int i = 0; i < array.Length; i++)
                values.Add(new KeyValuePair<int, int>(i, array[i]));

            values = values.OrderBy(kvp => kvp.Value).ToList();

            int swap = 0;
            for (int j = 0; j < array.Length; j++)
            {
                var (l, r) = (array[j], values[j]);
                if (l != r.Value)
                {
                    (values[j], values[r.Key]) = (values[r.Key], values[j]);
                    swap++;
                }
            }
            return swap;
        }
    }
}