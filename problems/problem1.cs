using System;
using System.Collections.Generic;

namespace problems
{
    class Problem1
    {
        /*
        Given a list of numbers and a number k, return whether any 
        two numbers from the list add up to k.
        For example, given [10, 15, 3, 7] and k of 17, return true
        since 10 + 7 is 17.

        Bonus: Can you do this in one pass?
        */

		public Tuple<int, int> problem1(int[] arr, int k){
			Tuple<int, int> result = Tuple.Create<int, int>(-1, -1);
            HashSet<int> set = new HashSet<int>();
			foreach (var number in arr)
			{
				var complement = k - number;
				if (set.Contains(complement))
						return Tuple.Create<int, int>(complement, number);
				else
					set.Add(number);
			}

            return result;
		}
    }
}
