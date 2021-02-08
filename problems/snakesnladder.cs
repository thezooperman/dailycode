using System.Linq;

namespace problems
{
    class SnakesNLadders
    {
        /*
            Snake and Ladder Problem

            Given a 5x6 snakes and ladders board, find the minimum number
            of dice throws required to reach the destination or last cell
            (30th cell) from the source (1st cell). You are given N ie -
            the total number of snakes and ladders and an array arr of 2*N
            size where 2*i and (2*i+1)th values denotes the starting and
            ending point respecitvely of ith snake or ladder.

            Board Image: https://contribute.geeksforgeeks.org/wp-content/uploads/snake-and-ladders.jpg

            Example 1:

            Input:
            N = 8
            arr = {3, 22, 5, 8, 11, 26, 20, 29, 
                17, 4, 19, 7, 27, 1, 21, 9}
            Output:
            3
            Explaination:
            The given board is the board shown in the figure. For the above
            board output will be 3. For 1st throw get a 2. For 2nd throw get
            a 6. For 3rd throw get a 2.

            Expected Runtime: O(N)
        */

        public int snakesnLadder(int[] array)
        {
            (int rows, int cols) = (5, 6);
            int steps = rows * cols;

            int[] positions = {3, 22, 5, 8, 11, 26, 20, 29,
                17, 4, 19, 7, 27, 1, 21, 9};

            int currentStep = 0;
            int diceRoll = 0;

            int[] values = new int[steps];
            Enumerable.Range(0, steps - 1).ToList().ForEach(x =>
            {
                values[x] = -1;
            });

            // 
            values[3] = 22;
            return 0;

        }
    }
}