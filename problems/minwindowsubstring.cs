using System;
using System.Collections.Generic;

namespace problems
{
    class MinWindowProblem
    {
        /*
        Given two strings string1 and string2, the task is to find the smallest
        substring in string1 containing all characters of string2 efficiently.

        Examples:

            Input: string = “this is a test string”, pattern = “tist”
            Output: Minimum window is “t stri”
            Explanation: “t stri” contains all the characters of pattern.

            Input: string = “geeksforgeeks”, pattern = “ork”
            Output: Minimum window is “ksfor”
        */

        private const int no_of_chars = 256;
        public int minWindow(string str, string pat)
        {
            int len1 = str.Length;
            int len2 = pat.Length;

            // check if string's length is less than pattern's 
            // length. If yes then no such window can exist 
            if (len1 < len2)
            {
                Console.WriteLine("No such window exists");
                return -1;
            }

            int[] hash_pat = new int[no_of_chars];
            int[] hash_str = new int[no_of_chars];

            // store occurrence ofs characters of pattern 
            for (int i = 0; i < len2; i++)
                hash_pat[pat[i]]++;

            int start = 0, start_index = -1, min_len = int.MaxValue;

            // start traversing the string 
            int count = 0; // count of characters 
            for (int j = 0; j < len1; j++)
            {
                // count occurrence of characters of string 
                hash_str[str[j]]++;

                // If string's char matches with pattern's char 
                // then increment count 
                if (hash_pat[str[j]] != 0 &&
                    hash_str[str[j]] <= hash_pat[str[j]])
                    count++;

                // if all the characters are matched 
                if (count == len2)
                {
                    // Try to minimize the window i.e., check if 
                    // any character is occurring more no. of times 
                    // than its occurrence in pattern, if yes 
                    // then remove it from starting and also remove 
                    // the useless characters. 
                    while (hash_str[str[start]] > hash_pat[str[start]]
                        || hash_pat[str[start]] == 0)
                    {

                        if (hash_str[str[start]] > hash_pat[str[start]])
                            hash_str[str[start]]--;
                        start++;
                    }

                    // update window size 
                    int len_window = j - start + 1;
                    if (min_len > len_window)
                    {
                        min_len = len_window;
                        start_index = start;
                    }
                }
            }

            // If no window found 
            if (start_index == -1)
            {
                Console.WriteLine("No such window exists");
                return -1;
            }

            // Return substring starting from start_index 
            // and length min_len 
            System.Console.WriteLine(str.Substring(start_index, min_len));
            return start_index;
        }

        /// O(n) solution - This is a HARD problem
        public string minWindowOther(string s, string t)
        {
            if (t.Length > s.Length)
                return String.Empty;

            if (String.IsNullOrEmpty(t))
                return s;

            if (String.IsNullOrEmpty(s))
                return String.Empty;

            IDictionary<char, int> map = new Dictionary<char, int>();
            IDictionary<char, int> charsMap = new Dictionary<char, int>();

            for (int i = 0; i < t.Length; i++)
            {
                if (map.ContainsKey(t[i]))
                    map[t[i]]++;
                else
                    map.Add(t[i], 1);
            }

            int startIndex = 0, count = 0, start = 0, minWindow = Int32.MaxValue;

            for (int i = 0; i < s.Length; i++)
            {
                var currentChar = s[i];

                if (charsMap.ContainsKey(currentChar))
                    charsMap[currentChar]++;
                else
                    charsMap.Add(currentChar, 1);

                int _ = 0;
                if (map.TryGetValue(currentChar, out _))
                    if (charsMap[currentChar] <= map[currentChar] && map[currentChar] != 0)
                        count++;

                if (count == t.Length)
                {
                    while (true)
                    {
                        _ = 0;
                        if (map.TryGetValue(s[start], out _))
                        {
                            if (charsMap[s[start]] <= map[s[start]])
                                break;
                            charsMap[s[start]]--;
                        }
                        start++;
                    }

                    if (minWindow > i - start + 1)
                    {
                        minWindow = i - start + 1;
                        // count = 0;
                        startIndex = start;
                    }
                }
            }

            return s.Substring(startIndex, minWindow == Int32.MaxValue ? 0 : minWindow);
        }
    }
}