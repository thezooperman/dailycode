using System;

namespace problems
{
    class Candy
    {
        /*
          There are N children standing in a line. Each child is assigned a rating value.

          You are giving candies to these children subjected to the following requirements:

          Each child must have at least one candy.
          Children with a higher rating get more candies than their neighbors.
          What is the minimum candies you must give?

          Example 1:

          Input: [1,0,2]
          Output: 5
          Explanation: You can allocate to the first, second and third child with 2, 1, 2 candies respectively.
          Example 2:

          Input: [1,2,2]
          Output: 4
          Explanation: You can allocate to the first, second and third child with 1, 2, 1 candies respectively.
              The third child gets 1 candy because it satisfies the above two conditions.
        */
        public int candy(int[] ratings)
        {
            int[] candies = new int[ratings.Length];

            // Pre-fill the array with 1
            // every child gets at least 1 candy
            Array.Fill(candies, 1);

            // start with the left to right
            // if the previous value is greater than current, 
            for (int i = 1; i < ratings.Length; i++)
            {
                if (ratings[i] > ratings[i - 1])
                    candies[i] = candies[i - 1] + 1;
            }

            // start from right to left

            return 0;
        }
    }
}