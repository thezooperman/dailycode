using System;
using System.Collections.Generic;
using System.Linq;

namespace problems
{
    class Problem26
    {
        /*
            Given a singly linked list and an integer k,
            remove the kth last element from the list.
            k is guaranteed to be smaller than the length
            of the list.

            The list is very long, so making more than one
            pass is prohibitively expensive.

            Do this in constant space and in one pass.
        */

        private LinkedList<int> list = new LinkedList<int>();
        public int problem26(int kthNode)
        {
            Enumerable.Range(1, 5).ToList().ForEach(x => list.AddLast(x));
            var current = list.Last;
            var prev = (LinkedListNode<int>)null;

            while (--kthNode > 0)
            {
                prev = current;
                current = current.Previous;
            }
            list.Remove(current);

            return current.Value;
        }
    }
}