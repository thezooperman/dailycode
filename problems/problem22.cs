using System;
using System.Collections.Generic;
using System.Text;

namespace problems
{
    class Problem22
    {
        /*
            Given a dictionary of words and a string made up of those
            words (no spaces), return the original sentence in a list.
            If there is more than one possible reconstruction, return
            any of them. If there is no possible reconstruction, then
            return null.

            For example, given the set of words 'quick', 'brown', 'the',
            'fox', and the string "thequickbrownfox", you should return
            ['the', 'quick', 'brown', 'fox'].

            Given the set of words 'bed', 'bath', 'bedbath', 'and', 
            'beyond', and the string "bedbathandbeyond", return either
            ['bed', 'bath', 'and', 'beyond] or ['bedbath', 'and', 'beyond'].
        */

        public IEnumerable<string> problem22(string text, string[] words)
        {
            IList<string> result = new List<string>();
            HashSet<string> set = new HashSet<string>(words);

            StringBuilder sb = new StringBuilder();

            foreach (var character in text)
            {
                sb.Append(character);

                if (set.Contains(sb.ToString()))
                {
                    result.Add(sb.ToString());
                    sb.Clear();
                }
            }

            return result;
        }

        private ICollection<string> utilFn(string text, HashSet<String> words, int wordEnd)
        {
            // if (cache.ContainsKey(wordEnd))
            //     return cache[wordEnd];

            HashSet<string> results = new HashSet<string>();

            if (wordEnd <= 0)
                return new List<String>();

            for (int start = 0; start < wordEnd; start++)
            {
                var newText = text.Substring(start, wordEnd - start);

                if (words.Contains(newText))
                {
                    var newList = this.utilFn(text, words, start);
                    if (newList.Count == 0)
                        results.Add(newText);
                    else
                        foreach (var item in newList)
                            results.Add(item + " " + newText);
                }
            }

            // if (!cache.ContainsKey(wordEnd))
            //     cache.Add(results.GetHashCode(), results);

            return results;
        }

        // private IDictionary<int, HashSet<string>> cache = new Dictionary<int, HashSet<String>>();
        public IEnumerable<string> problem22_AllOptions(string text, string[] words)
        {
            return this.utilFn(text, new HashSet<string>(words), text.Length);
        }


        IDictionary<string, List<String>> map = new Dictionary<String, List<String>>();
        private IList<String> anotherUtil(String text, HashSet<String> words)
        {
            if (map.ContainsKey(text))
                return map[text];

            List<string> result = new List<string>();
            if (words.Contains(text))
                result.Add(text);

            for (int i = 1; i < text.Length; i++)
            {
                var left = text.Substring(0, i);
                if (words.Contains(left))
                {
                    foreach (String item in this.anotherUtil(text.Substring(i), words))
                        result.Add(left + " " + item);
                }
            }

            map.Add(text, result);
            return result;
        }

        public IEnumerable<String> prob22Another(string text, string[] words)
        {
            return this.anotherUtil(text, new HashSet<string>(words));
        }
    }
}