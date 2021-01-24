using System.Collections.Generic;

namespace problems
{
    class LRU
    {
        internal class LRUNode
        {
            public int key;
            public int value;
        }
        /*
            LRU Cache
            Get: O(1)
            Put: O(1)

            First node contains recently added item
            Last node contains least recently added item
        */
        LinkedList<LRUNode> deque;
        readonly int CACHE_SIZE;
        IDictionary<int, LinkedListNode<LRUNode>> cache;

        public LRU(int capactiy)
        {
            CACHE_SIZE = capactiy;
            deque = new LinkedList<LRUNode>();
            cache = new Dictionary<int, LinkedListNode<LRUNode>>();
        }

        public int get(int key)
        {
            if (cache.ContainsKey(key))
            {
                var node = this.cache[key];
                this.deque.Remove(node);
                node = this.deque.AddFirst(node.Value);
                this.cache[key] = node;
                return node.Value.value;
            }
            return -1;
        }

        public void put(int key, int value)
        {
            LinkedListNode<LRUNode> node;
            if (this.cache.ContainsKey(key))
            {
                node = this.cache[key];
                this.deque.Remove(node);
                node.Value.value = value;
                node = this.deque.AddFirst(node.Value);
                this.cache[key] = node;
            }
            else
            {
                if (this.deque.Count >= this.CACHE_SIZE)
                {
                    // remove the last node
                    var lastNode = this.deque.Last;
                    this.cache.Remove(lastNode.Value.key);
                    this.deque.RemoveLast();
                }
                node = this.deque.AddFirst(new LRUNode() { key = key, value = value });
                this.cache.Add(key, node);
            }
        }

        public int getCacheSize() => this.deque.Count;
    }
}