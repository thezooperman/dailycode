using System;
using System.Collections.Generic;

namespace problems
{
    class StringPermutation
    {
        public IEnumerable<string> permute(string text, string toPrint)
        {
            if (String.IsNullOrEmpty(text))
                yield return toPrint;

            for (int i = 0; i < text.Length; i++)
            {
                char current = text[i];
                string leftRight = text.Substring(0, i) + text.Substring(i + 1);
                foreach (var s in this.permute(leftRight, toPrint + current))
                    yield return s;
            }
        }
    }
}