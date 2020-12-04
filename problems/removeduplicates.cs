using System.Linq;

namespace problems
{
    class RemoveDuplicates
    {
        /*
            Recursively remove all adjacent duplicates
            Given a string, recursively remove adjacent duplicate characters
            from the string. The output string should not have any adjacent
            duplicates. See following examples.
            
            Examples: 

            Input: azxxzy 
            Output: ay 
            First “azxxzy” is reduced to “azzy”. 
            The string “azzy” contains duplicates, 
            so it is further reduced to “ay”.
            
            Input: geeksforgeeg 
            Output: gksfor 
            First “geeksforgeeg” is reduced to 
            “gksforgg”. The string “gksforgg” 
            contains duplicates, so it is further 
            reduced to “gksfor”.
            
            Input: caaabbbaacdddd 
            Output: Empty String
            Input: acaaabbbacdddd 
            Output: acac 
        */

        // O(n) solution
        // Iterate through left
        // If stack is empty or TopOfStack does not match text[i], add element to stack
        // else, skip the duplicate elements until TopOfStack != text[i]
        public string removeDuplicates(string text)
        {
            int stackPointer = -1;
            int i = 0;

            char[] chrArray = text.ToCharArray();

            while (i < text.Length)
            {
                if (stackPointer == -1 || chrArray[stackPointer] != chrArray[i])
                {
                    stackPointer++;
                    chrArray[stackPointer] = chrArray[i];
                    i++;
                }
                else
                {
                    while (i < chrArray.Length && chrArray[stackPointer] == chrArray[i])
                    {
                        i++;
                        stackPointer--;
                    }
                }
            }
            return string.Join("", chrArray.Take(stackPointer + 1));
        }
    }
}