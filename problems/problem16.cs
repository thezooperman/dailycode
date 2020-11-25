using System;
using System.Collections.Generic;
using System.Linq;

namespace problems
{
    class Problem16
    {
        /*
            You run an e-commerce website and want to record the
            last N order ids in a log. Implement a data structure
            to accomplish this, with the following API:

            record(order_id): adds the order_id to the log
            get_last(i): gets the ith last element from the log.
            i is guaranteed to be smaller than or equal to N.
            
            You should be as efficient with time and space as possible.
        */
        internal class Log
        {
            private LinkedList<int> log = new LinkedList<int>();
            private int MAX_VALUE = (int)Math.Pow(2, 1024);

            public void record(int orderId)
            {
                if (log.Count == MAX_VALUE)
                    log.RemoveFirst();
                log.AddLast(orderId);
            }

            public int getLast(int nthValue)
            {
                var lastElement = log.Last;
                while (nthValue-- > 0)
                    lastElement = lastElement.Previous;

                return lastElement.Value;
            }
        }

        public int problem16()
        {
            var log = new Log();
            Enumerable.Range(1, 100).ToList().ForEach(x => log.record(x));
            return log.getLast(5);
        }
    }
}