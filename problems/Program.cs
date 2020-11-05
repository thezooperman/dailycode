using System;
using System.Diagnostics;
using System.Linq;

namespace problems
{
    class Program
    {
        static void Main(string[] args)
        {
            // Problem 1
            int[] arr = new int[4] { 10, 15, 3, 7 };
            int k = 17;
            var result = new Problem1().problem1(arr, k);
            System.Console.WriteLine("Problem 1: " + result);
            // Expected output 10,7 or 7, 10
            Debug.Assert(Tuple.Equals(result, Tuple.Create(10, 7)) || Tuple.Equals(result, Tuple.Create(7, 10)));

            // Problem 2
            arr = new int[3] { 3, 2, 1 };
            System.Console.Write("Problem 2: ");
            int[] res = new Problem2().problem2(arr);
            res.ToList().ForEach(x => System.Console.Write((x) + " "));
            Debug.Assert(res.SequenceEqual(new int[] { 2, 3, 6 }));
            System.Console.Write("\nProblem 2_1: ");
            res = new Problem2().problem2_1(arr);
            res.ToList().ForEach(x => System.Console.Write((x) + " "));
            // Expected output == [2, 3, 6]
            Debug.Assert(res.SequenceEqual(new int[] { 2, 3, 6 }));

            // Problem 3
            var root = new Problem3().populateNode();
            var nodes = new Problem3().serialize(root);
            System.Console.Write("\nProblem 3: ");
            System.Console.WriteLine(nodes);
            // Expected output == left.left
            Debug.Assert(new Problem3().deserialize(nodes).Left.Left.Val == "left.left");

            // Problem 4
            arr = new int[] { 3, 4, -1, 1 };
            System.Console.Write("Problem 4: ");
            int res4 = new Problem4().problem4(arr);
            System.Console.WriteLine(res4);
            // Expected output == 2
            Debug.Assert(res4 == 2);

            // Problem 6
            var prob6 = new Problem6().problem6();
            System.Console.WriteLine($"Problem 6: {prob6}");
            Debug.Assert(prob6 == 2);

            // Problem 7
            var prob7 = new Problem7().problem7("111");
            System.Console.WriteLine($"Problem 7: {prob7}");

            // Problem simple ecryption
            var encr = new SimpleEncryptedString().encrypt("This is a test!", 1);
            System.Console.WriteLine($"Problem encrypted string: {encr}");
            Debug.Assert(encr == "hsi  etTi sats!");

            var decrypt = new SimpleEncryptedString().decrypt(encr, 1);
            System.Console.WriteLine($"Problem decrypted string: {decrypt}");
            Debug.Assert(decrypt == "This is a test!");

            encr = new SimpleEncryptedString().encrypt("This is a test!", 2);
            System.Console.WriteLine($"Problem encrypted string: {encr}");
            Debug.Assert(encr == "s eT ashi tist!");

            decrypt = new SimpleEncryptedString().decrypt(encr, 2);
            System.Console.WriteLine($"Problem decrypted string: {decrypt}");
            Debug.Assert(decrypt == "This is a test!");

        }
    }
}
