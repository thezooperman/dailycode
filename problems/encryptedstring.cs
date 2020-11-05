using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace problems
{
    /*
    For building the encrypted string:
    Take every 2nd char from the string, then the other chars,
    that are not every 2nd char, and concat them as new String.
    Do this n times!

    Examples:

    "This is a test!", 1 -> "hsi  etTi sats!"
    "This is a test!", 2 -> "hsi  etTi sats!" -> "s eT ashi tist!"

    Write two methods:

    string Encrypt(string text, int n)
    string Decrypt(string encryptedText, int n)
    */
    class SimpleEncryptedString
    {
        public string encrypt(String text, int n)
        {
            if (String.IsNullOrEmpty(text) || String.IsNullOrWhiteSpace(text))
                return text;

            if (n <= 0)
                return text;

            ICollection<Char> even = new Collection<Char>();
            ICollection<Char> odd = new Collection<Char>();

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (i % 2 == 0)
                        even.Add(text[i]);
                    else
                        odd.Add(text[i]);
                }

                StringBuilder sb = new StringBuilder();
                foreach (var character in odd)
                    sb.Append(character);

                foreach (var character in even)
                    sb.Append(character);

                text = sb.ToString();
                sb.Clear();
                even.Clear();
                odd.Clear();
            }
            return text;
        }

        public string decrypt(String encryptedText, int n)
        {
            if (String.IsNullOrEmpty(encryptedText) || String.IsNullOrWhiteSpace(encryptedText))
                return encryptedText;

            if (n <= 0)
                return encryptedText;

            for (int i = 0; i < n; i++)
            {
                int evenLen = encryptedText.Length / 2;
                int oddLen = encryptedText.Length - evenLen;

                int x, y;
                x = 0;
                y = evenLen;

                StringBuilder sb = new StringBuilder(encryptedText.Length);

                while (x < evenLen && y < encryptedText.Length)
                {
                    sb.Append(encryptedText[y++]);
                    sb.Append(encryptedText[x++]);
                }

                while (y < encryptedText.Length)
                    sb.Append(encryptedText[y++]);

                encryptedText = sb.ToString();
                sb.Clear();
            }


            return encryptedText;
        }
    }
}