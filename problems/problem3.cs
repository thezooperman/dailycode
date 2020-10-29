using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace problems
{
    class Problem3
    {
        /*
            Given the root to a binary tree, implement serialize(root), which
            serializes the tree into a string, and deserialize(s), which deserializes
            the string back into the tree.

            For example, given the following Node class

            class Node: def init(self, val, left=None, right=None): 
            self.val = val self.left = left self.right = right The following test should pass:

            node = Node('root', Node('left', Node('left.left')), Node('right')) 
            assert deserialize(serialize(node)).left.left.val == 'left.left'
        */

        internal class Node
        {
            public String Val { get; set; }
            public Node Left { get; set; } = null;
            public Node Right { get; set; } = null;
            public Node(String val, Node left = null, Node right = null)
            {
                this.Val = val;
                this.Left = left;
                this.Right = right;
            }
        }

        public Node populateNode()
        {
            return new Node("root", new Node("left", new Node("left.left")), new Node("right"));
        }

        String EmptyMarker = "1";

        public String serialize(Node node)
        {
            if (node == null)
                return EmptyMarker + '|';

            var sb = new StringBuilder();
            sb.Append($"{node.Val}|");

            sb.Append(serialize(node.Left));
            sb.Append(serialize(node.Right));

            return sb.ToString();
        }

        public Node deserialize(String tree)
        {
            Node node;
            var nodes = tree
            .Split('|', StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

            var queue = new Queue<string>(nodes);
            node = this.deserializeUtil(queue);
            return node;
        }

        private Node deserializeUtil(Queue<String> nodes)
        {
            if (nodes.Peek() != null)
            {
                var next = nodes.Dequeue();

                if (next == EmptyMarker)
                    return null;

                var node = new Node(next, deserializeUtil(nodes), deserializeUtil(nodes));

                return node;
            }
            return null;
        }
    }
}