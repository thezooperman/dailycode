namespace problems
{
    class LowestCommonAncestorBST
    {
        /*
            Given values of two values n1 and n2 in a Binary Search Tree, find
            the Lowest Common Ancestor (LCA). You may assume that both the values
            exist in the tree.

            Nodes:         20
                         /    \                 
                        8      22
                     /     \
                    4       12
                          /    \
                        10      14
            Input: LCA of 10 and 14
            Output:  12
            Explanation: 12 is the closest node to both 10 and 14 
            which is a ancestor of both the nodes.

            Input: LCA of 8 and 14
            Output:  8
            Explanation: 8 is the closest node to both 8 and 14 
            which is a ancestor of both the nodes.

            Input: LCA of 10 and 22
            Output:  20
            Explanation: 20 is the closest node to both 10 and 22 
            which is a ancestor of both the nodes.

            Runtime: O(h), h is the height of the tree
            Space: O(1)
        */

        internal class Node
        {
            public int Data { get; set; }
            public Node Left { get; set; } = null;
            public Node Right { get; set; } = null;
        }

        private Node root;

        private Node lcaUtil(Node crawler, int left, int right)
        {
            if (crawler == null)
                return null;

            if (crawler.Data > left && crawler.Data > right)
                return this.lcaUtil(crawler.Left, left, right);

            if (crawler.Data < left && crawler.Data < right)
                return this.lcaUtil(crawler.Right, left, right);

            return crawler;
        }

        public int lca()
        {
            root = new Node() { Data = 20 };
            root.Left = new Node() { Data = 8 };
            root.Left.Left = new Node() { Data = 4 };
            root.Left.Right = new Node() { Data = 12 };
            root.Left.Right.Left = new Node() { Data = 10 };
            root.Left.Right.Right = new Node() { Data = 14 };
            root.Right = new Node() { Data = 22 };

            var returnVal = this.lcaUtil(root, 10, 14);

            return returnVal?.Data ?? -1;
        }
    }
}