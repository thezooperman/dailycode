using System.Collections.Generic;
using System.Linq;

namespace problems
{
    class LowestCommonAncestorBT
    {
        /*
            Given a binary tree (not a binary search tree) and two values say n1
            and n2, write a program to find the least common ancestor.

            Nodes:          1
                         /     \                 
                        2       3
                      /   \    /  \
                     4     5  6    7

            LCA(4,5) = 2
            LCA(4,6) = 1
            LCA(3,4) = 1
            LCA(2,4) = 2

            Runtime: O(n), n is the number of nodes traversed
        */
        internal class Node
        {
            public int Data;
            public Node Left, Right;

            public Node(int data)
            {
                Data = data;
                Left = Right = null;
            }
        }

        private Node root;

        private bool lcaUtil(Node crawler, int value, LinkedList<int> path)
        {
            if (crawler == null)
                return false;

            path.AddLast(crawler.Data);

            if (crawler.Data == value)
                return true;

            // iterate on left
            if (crawler.Left != null &&
                    this.lcaUtil(crawler.Left, value, path))
                return true;

            // iterate on right
            if (crawler.Right != null &&
                this.lcaUtil(crawler.Right, value, path))
                return true;

            path.RemoveLast();

            // no match
            return false;
        }

        public int lca()
        {
            root = new Node(1);
            root.Left = new Node(2);
            root.Left.Left = new Node(4);
            root.Left.Right = new Node(5);
            root.Right = new Node(3);
            root.Right.Left = new Node(6);
            root.Right.Right = new Node(7);

            LinkedList<int> left = new LinkedList<int>(), right = new LinkedList<int>();

            if (!this.lcaUtil(root, 4, left))
            {
                System.Console.WriteLine("Left node - 4, does not exist");
                return -1;
            }

            if (!this.lcaUtil(root, 5, right))
            {
                System.Console.WriteLine("Right node - 5, does not exist");
                return -1;
            }

            int index = -1, prev = -1;
            foreach (var (l, r) in Enumerable.Zip(left, right))
            {
                prev = index;
                index = l;
                if (l != r)
                    break;
            }

            return prev;
        }
    }
}