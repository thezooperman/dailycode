using System.Linq;

namespace problems
{
    class Problem12
    {
        /*
            There exists a staircase with N steps, and you can climb up either 1 or 2 steps at a time.
            Given N, write a function that returns the number of unique ways you can climb the staircase.
            The order of the steps matters.

            For example, if N is 4, then there are 5 unique ways:

            1, 1, 1, 1
            2, 1, 1
            1, 2, 1
            1, 1, 2
            2, 2

            What if, instead of being able to climb 1 or 2 steps at a time, you could climb any number from
            a set of positive integers X? For example, if X = {1, 3, 5}, you could climb 1, 3, or 5 steps at
            a time.
        */

        /// This is very slow O(2^n)
        private int stepHelper(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            return this.stepHelper(n - 1) + this.stepHelper(n - 2);
        }

        private int stepHelperOptimized(int n, int[] steps)
        {
            /// This follows a a pattern
            /// f(1) = [1]
            /// f(2) = [1,1] or [2]
            /// f(3) = [1,1,1] or [1,2] or [2, 1]
            /// f(4) = [1,1,1,1] or [2, 2] or [1, 1, 2] or [2, 1, 1] or [1, 2, 1]
            /// f(3) is a combination of f(1) and f(2), so is f(4) = f(3) + f(2)

            int[] cache = new int[n + 1];
            //setup first step
            cache[0] = 1;

            for (int i = 1; i <= n; i++)
            {
                // cache[i] can be computed from previous steps
                foreach (int step in steps)
                {
                    if (i - step >= 0)
                        cache[i] += cache[i - step];
                }
            }
            return cache[^1];
            // return cache.Last();
        }

        public int problem12(int n, int[] steps)
        {
            // return this.stepHelper(n);
            return this.stepHelperOptimized(n, steps);
        }
    }
}