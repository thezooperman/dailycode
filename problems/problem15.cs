using System;

namespace problems
{
    class Problem15
    {
        /*
            Given a stream of elements too large to store in memory,
            pick a random element from the stream with uniform probability.
        */

        private Random random = new Random();

        public System.Collections.Generic.IEnumerable<int> problem15(int stream)
        {
            int returnValue = Int32.MinValue;
            if (stream <= 0)
                yield return returnValue;

            // simulate stream starting from 1....int32.MaxValue
            for (int i = 1; i < stream; i++)
            {
                if (i == 1)
                {
                    yield return i;
                    continue;
                }
                // pick a number
                int prob = random.Next(i);
                if (prob == i - 1)
                    yield return stream;
                else
                    yield return prob;
            }
        }
    }
}