using System;
using System.Collections.Generic;

namespace problems
{
    class Problem11
    {
        internal class Node
        {
            public char Value { get; set; }
            public IDictionary<char, Node> Children { get; set; } = new Dictionary<char, Node>();
            public String IsWord { get; set; } = String.Empty;

            public Node() { }
            public Node(char value)
            {
                this.Value = value;
            }
        }

        private Node root = new Node();

        public void Add(String text)
        {
            var current = this.root;
            foreach (char letter in text)
            {
                if (!current.Children.ContainsKey(letter))
                {
                    var newNode = new Node(letter);
                    current.Children.Add(letter, newNode);
                }
                current = current.Children[letter];
            }
            current.IsWord = text;
        }

        private IEnumerable<String> searchUtil(Node node)
        {
            if (!String.IsNullOrEmpty(node.IsWord))
                yield return node.IsWord;

            foreach (var elem in node.Children)
            {
                this.searchUtil(elem.Value);
            }

        }

        public IEnumerable<string> Search(string text)
        {
            var current = this.root;

            foreach (char letter in text)
            {
                if (current.Children.ContainsKey(letter))
                    current = current.Children[letter];
                else
                    yield return String.Empty;
            }

            yield return this.searchUtil(current);

        }
    }
}