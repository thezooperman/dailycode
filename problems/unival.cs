using System;

namespace problems
{
    class Problem8
    {
        /*
            A unival tree (which stands for "universal value")
            is a tree where all nodes under it have the same value.
            Given the root to a binary tree, count the number of
            unival subtrees.
            For example, the following tree has 5 unival subtrees:
   0
  / \
 1   0
    / \
   1   0
  / \
 1   1
        */

        internal class Node
        {
            public uint Data { get; set; } = 0;
            public Node Left { get; set; } = null;
            public Node Right { get; set; } = null;

            public Node(uint data, Node left = null, Node right = null)
            {
                Data = data;
                Left = left;
                Right = right;
            }
        }

        private Node root;

        public void hydrateTree()
        {
            root = new Node(0);
            root.Left = new Node(1);
            root.Right = new Node(0, new Node(1), new Node(0));
            root.Right.Left.Left = new Node(1);
            root.Right.Left.Right = new Node(1);
        }

        private int helper(Node node)
        {
            if (node == null)
                return 1;

            if (node.Left != null)
            {
                if (node.Data != node.Left.Data)
                    return 0;
            }

            if (node.Right != null)
            {
                if (node.Data != node.Right.Data)
                    return 0;
            }

            if (helper(node.Left) == 1 && (helper(node.Right) == 1))
                return 1;

            return 0;
        }

        private int wrapper(Node node)
        {
            if (node == null)
                return 0;
            var left = wrapper(node.Left);
            var right = wrapper(node.Right);
            if (helper(node) == 1)
                return 1 + left + right;
            else
                return left + right;
        }
        public int problem8()
        {
            // return this.wrapper(root);
            return univalUtil(root).Item1;
        }

        private Tuple<int, bool> univalUtil(Node node)
        {
            if (node == null)
                return Tuple.Create<int, bool>(0, true);
            Tuple<int, bool> left = univalUtil(node.Left);
            Tuple<int, bool> right = univalUtil(node.Right);
            var isUnival = true;
            if (!left.Item2 || !right.Item2)
                isUnival = false;
            if (node.Left != null)
                if (node.Data != node.Left.Data)
                    isUnival = false;
            if (node.Right != null)
                if (node.Data != node.Right.Data)
                    isUnival = false;
            if (isUnival)
                return Tuple.Create<int, bool>(1 + left.Item1 + right.Item1, true);

            return Tuple.Create<int, bool>(left.Item1 + right.Item1, false);
        }
    }
}