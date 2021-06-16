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
            List<(int key, int value)> vector = new List<(int, int)>(array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                vector.Add((array[i], i));
            }

            vector.Sort();

            int swaps = default(int);

            for (int i = 0; i < array.Length; i++)
            {
                if (i == vector[i].value)
                    continue;
                (vector[i], vector[vector[i].value]) = (vector[vector[i].value], vector[i]);

                if (i != vector[i].value)
                    --i;
                swaps++;
            }
            return swaps;
        }
    }
}