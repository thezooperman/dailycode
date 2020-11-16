using System;
using System.Collections.Generic;

namespace problems
{
    class Problem11
    {
        /*
            Implement an autocomplete system. That is, given a query string s and a
            set of all possible query strings, return all strings in the set that have
            s as a prefix.

            For example, given the query string de and the set of strings [dog, deer, deal],
            return [deer, deal].
        */
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

        private IEnumerable<string> searchUtil(Node node)
        {
            var result = new List<string>();

            if (node == null)
                return result;

            if (!string.IsNullOrEmpty(node.IsWord))
                result.Add(node.IsWord);

            foreach (var kvp in node.Children)
            {
                result.AddRange(searchUtil(kvp.Value));
            }

            return result;
        }

        public IEnumerable<string> Search(string text)
        {
            var current = this.root;

            foreach (char letter in text)
            {
                if (current.Children.ContainsKey(letter))
                    current = current.Children[letter];
                else
                    return new List<String>();
            }
            return this.searchUtil(current);
        }
    }
}