using System.Collections.Generic;
using System.Linq;

namespace problems
{
    class Problem20
    {
        /*
            Given two singly linked lists that intersect at some point,
            find the intersecting node. The lists are non-cyclical.

            For example, given A = 3 -> 7 -> 8 -> 10 and B = 99 -> 1 -> 8 -> 10,
            return the node with value 8.

            In this example, assume nodes with the same value are the
            exact same node objects.

            Do this in O(M + N) time (where M and N are the lengths of
            the lists) and constant space.
        */

        public int problem20(int[] array_1, int[] array_2)
        {
            LinkedList<int> left = new LinkedList<int>(array_1);
            LinkedList<int> right = new LinkedList<int>(array_2);

            // return left.Zip(right).Where(x => x.First.Equals(x.Second)).FirstOrDefault().First;
            return Enumerable.Zip(left, right).Where(x => x.First.Equals(x.Second)).FirstOrDefault().First;
        }
    }
}