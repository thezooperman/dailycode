
using System.Collections.Generic;

namespace problems
{
    class Problem6
    {
        /*
        An XOR linked list is a more memory efficient doubly linked list.
        Instead of each node holding next and prev fields, it holds a
        field named both, which is an XOR of the next node and the previous
        node. Implement an XOR linked list; it has an add(element) which adds
        the element to the end, and a get(index) which returns the node at index.
        */

        class Node<T>
        {
            public T Value { get; set; }
            public int Both { get; set; }
            public int Address { get; set; }
        }

        class XorLL<T>
        {
            private Node<T> Root;
            private int StartingAddress = 1;
            private Dictionary<int, Node<T>> memory = new Dictionary<int, Node<T>>();

            public void Add(T element)
            {
                // no head
                if (Root == null)
                {
                    this.Root = new Node<T>
                    {
                        Value = element,
                        Address = StartingAddress,
                        Both = 0 ^ 0
                    };

                    this.memory.Add(this.Root.Address, this.Root);
                }
                else
                {
                    var current = this.Root;
                    var previous = (Node<T>)null;

                    while (true)
                    {
                        var currentAddress = (current.Both ^ (previous == null ? 0 : previous.Address));
                        if (currentAddress == 0)
                            break;
                        previous = current;
                        current = this.memory[currentAddress];
                    }

                    var node = new Node<T>
                    {
                        Value = element,
                        Address = StartingAddress,
                        Both = 0 ^ current.Address
                    };

                    current.Both = (node.Address ^ (previous == null ? 0 : previous.Address));
                    this.memory.Add(node.Address, node);
                }
                StartingAddress++;
            }

            public T Get(int index)
            {
                var current = this.Root;
                var previous = (Node<T>)null;

                for (int i = 0; i < index; i++)
                {
                    var nextAddress = (current.Both ^ (previous == null ? 0 : previous.Address));
                    previous = current;

                    if (!this.memory.ContainsKey(nextAddress))
                        return default(T);

                    current = this.memory[nextAddress];
                }

                return current.Value;
            }
        }

        public int problem6()
        {
            var list = new XorLL<int>();

            for (int i = 0; i < 4; i++)
            {
                list.Add(i);
            }
            return list.Get(2);
        }
    }
}