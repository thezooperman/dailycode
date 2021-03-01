using System.Collections.Generic;

namespace problems
{
    class Problem28
    {
        /*
           Write an algorithm to justify text. Given a sequence of words and an integer line length k,
           return a list of strings which represents each line, fully justified.

           More specifically, you should have as many words as possible in each line. There should be at
           least one space between each word. Pad extra spaces when necessary so that each line has
           exactly length k. Spaces should be distributed as equally as possible, with the extra spaces,
           if any, distributed starting from the left.

           If you can only fit one word on a line, then you should pad the right-hand side with spaces.

           Each word is guaranteed not to be longer than k.

           For example, given the list of words ["the", "quick", "brown", "fox", "jumps", "over", "the",
           "lazy", "dog"] and k = 16, you should return the following:

           ["the  quick brown", # 1 extra space on the left
           "fox  jumps  over", # 2 extra spaces distributed evenly
           "the   lazy   dog"] # 4 extra spaces distributed evenly
        */

        private void justify(IList<string> result, IList<string> current, int k, int cumulativeLength)
        {
            // case 1: 1 word takes up most space
            if (current.Count == 1)
                result.Add(current[0].PadRight(k, ' '));
            else
            {
                // case 2: equal distribution
                int numSpaces = k - cumulativeLength;
                int spaceBetweenWords = numSpaces / (current.Count - 1);
                int extraSpace = numSpaces % (current.Count - 1);

                // add extra space to all the elements
                for (int i = 0; i < extraSpace; i++)
                    current[i] += ' ';

                result.Add(string.Join(" ".PadRight(spaceBetweenWords), current));
            }
        }

        public IEnumerable<string> problem28(string[] array, int k)
        {
            IList<string> result = new List<string>();
            IList<string> current = new List<string>();
            int cumulativeLength = 0;

            foreach (string word in array)
            {
                if (word.Length + cumulativeLength + current.Count > k)
                {
                    this.justify(result, current, k, cumulativeLength);
                    cumulativeLength = 0;
                    current.Clear();
                }
                current.Add(word);
                cumulativeLength += word.Length;
            }

            // case 3: if spaces aren't equal add to
            if (current.Count > 0)
                this.justify(result, current, k, cumulativeLength);

            return result;
        }
    }
}