using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace problems
{
    class Problem13
    {
        /*
        Given an integer k and a string s, find the length of the longest substring that
        contains at most k distinct characters.

        For example, given s = "abcba" and k = 2, the longest substring with k distinct
        characters is "bcb".
        */

        public string problem13(string text, int k)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text) || k < 0)
                return string.Empty;

            IDictionary<char, int> counter = new Dictionary<char, int>();
            int index = 0;
            string result = string.Empty;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                var current = text[i];
                if (counter.ContainsKey(current))
                    counter[current] += 1;
                else
                    counter.Add(current, 1);
                sb.Append(current);

                if (counter.Count > k)
                {
                    // Process the result to extract the last added char
                    // and remove the text[last index] from counter
                    // and hack to reset the SB to include text[1:] + current 
                    var keys = sb.ToString();
                    keys = keys.Remove(keys.Length - 1);
                    result = result.Length > keys.Length ? result : keys;
                    counter.Remove(text[index]);
                    sb.Clear();
                    sb.Append(string.Join("", keys.Skip(1).ToList()) + current);
                    index++;
                }
            }

            if (counter.Count < k)
                return string.Empty;
            // if counter did not match k, probably entire string matches
            return result == string.Empty ? text : result;
        }

        public string problem13Another(string text, int k)
        {
            int unique = 0, start = 0, maxWindow = 1, winStart = 0;
            int[] counter = new int[26];
            Array.Fill(counter, 0);

            for (int i = 0; i < text.Length; i++)
            {
                if (counter[text[i] - 'a'] == 0)
                    unique++;
                counter[text[i] - 'a']++;
            }

            if (unique < k)
                return string.Empty;

            Array.Fill(counter, 0);
            counter[text[0] - 'a']++;

            for (int i = 1; i < text.Length; i++)
            {
                counter[text[i] - 'a']++;

                while (counter.Where(x => x > 0).Count() > k)
                {
                    counter[text[start] - 'a']--;
                    start++;
                }
                if (i - start + 1 > maxWindow)
                {
                    maxWindow = i - start + 1;
                    winStart = start;
                }
            }
            return text.Substring(winStart, winStart + maxWindow);
        }
    }
}