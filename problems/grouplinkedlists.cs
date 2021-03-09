using System;
using System.Collections.Generic;
using System.Linq;

namespace problems
{
    class GroupLinkedListsByIntersectionPoint
    {
        /*
           There’s an array of heads of linked lists that may or may not intersect
           with each other. The goal is to group the array entries such that if two
           linked lists intersect with each other then they belong to the same group.

           Example:

           0,  1,  2,  3,      4, 5,   6,  7
           |   |   |   |       | /     |   |
           a  /d   e   h       i  _____k   NULL
           |/      |   |       | /
           b       f   NULL    j
           |       |           |
           c <-----g           NULL
           |
           NULL

           Result:
           Group 1-> 0, 1, 2
           Group 2-> 3
           Group 3-> 4, 5, 6
           Group 4 -> 7
        */


        internal class Node
        {
            public String Value { get; set; } = string.Empty;
            public Node Next { get; set; } = null;

            public Node(string val) => Value = val;
        }
        public ICollection<List<string>> getLinkedListsByGroup()
        {
            #region Populate LinkedList
            Node one = new Node("0");
            one.Next = new Node("a");
            var b = new Node("b");
            one.Next.Next = b;
            var c = new Node("c");
            b.Next = c;

            Node two = new Node("1");
            two.Next = new Node("d");
            two.Next.Next = b;

            Node three = new Node("2");
            three.Next = new Node("e");
            three.Next.Next = new Node("f");
            three.Next.Next.Next = new Node("g");
            three.Next.Next.Next.Next = c;

            Node four = new Node("3");
            four.Next = new Node("h");

            Node five = new Node("4");
            var i = new Node("i");
            five.Next = i;
            Node j = new Node("j");
            five.Next.Next = j;

            Node six = new Node("5");
            six.Next = i;

            Node seven = new Node("6");
            var k = new Node("k");
            seven.Next = k;
            k.Next = j;

            Node eight = new Node("7");
            #endregion

            Node[] nodeArrays = { one, two, three, four, five, six, seven, eight };

            Node getLastValidNode(Node start)
            {
                while (start.Next != null)
                    start = start.Next;
                return start;
            }

            IDictionary<Node, List<string>> map = new Dictionary<Node, List<string>>();

            foreach (Node elem in nodeArrays)
            {
                var lastNode = getLastValidNode(elem);
                if (map.ContainsKey(lastNode))
                    map[lastNode].Add(elem.Value);
                else
                    map.Add(lastNode, new List<string>(new string[] { elem.Value }));
            }

            return map.Values;
        }
    }
}