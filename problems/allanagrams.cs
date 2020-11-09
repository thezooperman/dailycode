using System;
using System.Collections.Generic;
using System.Linq;

namespace problems
{
    class AllAnagramsInString
    {
        /*
        Find All Anagrams in a String
        Given a string s and a non-empty string p, find all the start
        indices of p's anagrams in s.

        Strings consists of lowercase English letters only and the length
        of both strings s and p will not be larger than 20,100.

        The order of output does not matter.

        Example 1:
        Input:
        s: "cbaebabacd" p: "abc"

        Output:
        [0, 6]

        Explanation:
        The substring with start index = 0 is "cba", which is an anagram of "abc".
        The substring with start index = 6 is "bac", which is an anagram of "abc".

        Example 2:
        Input:
        s: "abab" p: "ab"

        Output:
        [0, 1, 2]

        Explanation:
        The substring with start index = 0 is "ab", which is an anagram of "ab".
        The substring with start index = 1 is "ba", which is an anagram of "ab".
        The substring with start index = 2 is "ab", which is an anagram of "ab".
        */


        private IDictionary<char, int> getCount(String s, int start, int end)
        {
            var tmpDict = new Dictionary<char, int>(end - start);
            for (int i = start; i < end; i++)
            {
                if (tmpDict.ContainsKey(s[i]))
                    tmpDict[s[i]]++;
                else
                    tmpDict.Add(s[i], 1);
            }
            return tmpDict;
        }
        public IList<int> FindAnagrams(string s, string p)
        {
            int pLen = p.Length;
            int sLen = s.Length;
            IList<int> returnList = new List<int>();

            // IDictionary<char, int> map = new Dictionary<char, int>(p.Length);
            // for (int i = 0; i < p.Length; i++)
            // {
            //     if (map.ContainsKey(p[i]))
            //         map[p[i]]++;
            //     else
            //         map.Add(p[i], 1);
            // }

            // for (int i = 0; i < sLen - pLen + 1; i++)
            // {
            //     var currentSpan = this.getCount(s, i, i + pLen);
            //     try
            //     {
            //         if (map.All(kv => currentSpan[kv.Key] == kv.Value))
            //             returnList.Add(i);
            //     }
            //     catch (System.Exception)
            //     {
            //         ;
            //     }
            // }

            int[] map = new int[26];
            int[] smap = new int[26];
            int indexPointer = 0;


            foreach (var elem in p)
                map[elem - 'a']++;

            for (int i = 0; i < sLen; i++)
            {
                char current = s[i];
                if (i < pLen - 1)
                    smap[current - 'a']++;
                else
                {
                    smap[current - 'a']++;
                    if (map.SequenceEqual(smap))
                        returnList.Add(indexPointer);
                    smap[s[indexPointer] - 'a']--;
                    indexPointer++;
                }
            }

            return returnList;
        }
    }
}