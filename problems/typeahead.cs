using System;
using System.Collections.Generic;
using System.Linq;

namespace problems
{
    class Typeahead
    {
        /*
            Optimized Trie to fetch typeahead query in O(l)
            where l = length of typed character.
            Use pre-processing to store most searched words by rank
            at each node, which has children
        */

        private readonly Node root;

        public Typeahead() => root = new Node();

        internal class QuickNode
        {
            public string Word { get; set; }
            public int Rank { get; set; }

            public override string ToString() => $"{this.Word} - {this.Rank}";

            public override int GetHashCode() => base.GetHashCode() + this.Rank;
        }

        internal class Node
        {
            public char Data { get; set; }
            public int Rank { get; set; } = 0;
            public string IsWord { get; set; } = string.Empty;
            public HashSet<QuickNode> NodeWords { get; set; } = new HashSet<QuickNode>();
            public LinkedList<Node> Children { get; set; } = new LinkedList<Node>();

            public Node GetChild(char val)
            {
                foreach (var child in Children)
                    if (child.Data == val)
                        return child;
                return null;
            }

            public Node CreateChild(char c)
            {
                var newChild = new Node() { Data = c };
                Children.AddLast(newChild);

                return newChild;
            }
        }

        public void AddNode(string word, int rank)
        {
            var current = this.root;

            for (int i = 0; i < word.Length; i++)
                current = current.GetChild(word[i]) ?? current.CreateChild(word[i]);

            current.IsWord = word;
            current.Rank = rank;
        }

        public IEnumerable<char> Search(string word)
        {
            var current = this.root;
            current = current.GetChild(word[0]);

            if (current == null)
                yield break;


            int i = 1;

            do
            {
                yield return current.Data;
                current = current.GetChild(word[i++]);

            } while (current.IsWord != word);

            yield return current.Data;
        }

        public IEnumerable<string> SearchAllChildren(string word)
        {
            var current = this.root;
            current = current.GetChild(word[0]);

            if (current == null)
                return Enumerable.Empty<string>();

            return getAllChildHelper(current.Children);
        }

        private IEnumerable<string> getAllChildHelper(LinkedList<Node> children)
        {
            var list = new List<string>();

            if (children == null)
                return list;

            foreach (var child in children)
            {
                if (!String.IsNullOrEmpty(child.IsWord))
                    list.Add(child.IsWord);
                list.AddRange(getAllChildHelper(child.Children));
            }
            return list;
        }

        private IList<QuickNode> buildUtil(Node current, int wordLimit)
        {
            var list = new List<QuickNode>();
            if (current == null)
                return list;

            foreach (var child in current.Children)
            {
                if (!String.IsNullOrEmpty(child.IsWord))
                    list.Add(new QuickNode { Word = child.IsWord, Rank = child.Rank });

                list.AddRange(buildUtil(child, wordLimit));
            }

            // Store n words with max rank only at each node
            if (current.Children.Count > 0)
                foreach (QuickNode node in list.OrderByDescending(x => x.Rank).Take(wordLimit))
                    current.NodeWords.Add(node);

            return list;
        }

        public void BuildMostSearchWords(int wordLimit)
        {
            var current = this.root;

            buildUtil(current, wordLimit);
        }

        public IEnumerable<QuickNode> GetMostSearchedWordsByRank()
        {
            var current = this.root;
            foreach (QuickNode word in current.NodeWords)
                yield return word;
        }

        public IEnumerable<QuickNode> PrefixSearch(string prefix)
        {
            var current = this.root;

            foreach (char letter in prefix)
            {
                current = current.GetChild(letter);
                if (current == null)
                    yield break;
            }
            foreach (QuickNode node in current.NodeWords)
                yield return node;
        }
    }
}