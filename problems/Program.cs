using System;
using System.Collections.Generic;
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

            // Sort odd in-place
            var arrVal = new int[6] { 5, 3, 2, 8, 1, 4 };
            var output = new Kata().SortArray(arrVal);
            System.Console.Write("Sort Odd Values in Array: ");
            output.ToList().ForEach(x => System.Console.Write((x) + " "));
            Debug.Assert(output.SequenceEqual(new int[] { 1, 3, 2, 8, 5, 4 }));

            // Unival tree
            var prob8 = new Problem8();
            prob8.hydrateTree();
            int unival = prob8.problem8();
            System.Console.WriteLine($"\nProblem 8: {unival}");
            Debug.Assert(unival == 5, "Unival count should be 5");

            // Find all anagrams in a string
            var anagram = new AllAnagramsInString();
            IList<int> expectedOutput = anagram.FindAnagrams("cbaebabacd", "abc");
            System.Console.Write("Problem: All anagrams index in String: ");
            expectedOutput.ToList().ForEach(x => System.Console.Write((x) + " "));
            Debug.Assert(expectedOutput.SequenceEqual(new int[2] { 0, 6 }));

            expectedOutput = anagram.FindAnagrams("abab", "ab");
            System.Console.Write("\nProblem: All anagrams index in String: ");
            expectedOutput.ToList().ForEach(x => System.Console.Write((x) + " "));
            Debug.Assert(expectedOutput.SequenceEqual(new int[3] { 0, 1, 2 }));

            // Problem 9
            int prob9 = new Problem9().problem9(new int[5] { 2, 4, 6, 2, 5 });
            System.Console.WriteLine($"\nProblem 9: {prob9}");
            Debug.Assert(prob9 == 13);

            prob9 = new Problem9().problem9(new int[4] { 5, 1, 1, 5 });
            System.Console.WriteLine($"Problem 9: {prob9}");
            Debug.Assert(prob9 == 10);

            // Problem 11
            var problem11 = new Problem11();
            problem11.Add("dog");
            problem11.Add("deer");
            problem11.Add("deal");

            var results = problem11.Search("de");
            System.Console.Write("Problem 11: ");
            results.ToList().ForEach(x => System.Console.Write(x + " "));
            Debug.Assert(results.SequenceEqual(new string[] { "deer", "deal" }));

            System.Console.Write($"\nProblem 11 - Delete key `deal`: {problem11.deleteNode("deal")}");
            System.Console.Write("\nProblem 11- Search deleted key(`deal`): ");
            problem11.Search("deal").ToList().ForEach(_ => System.Console.Write(_));

            // Problem 12
            var problem12 = new Problem12();
            var output12 = problem12.problem12(5, new int[] { 1, 3, 5 });
            System.Console.Write($"\nProblem 12: {output12}");
            Debug.Assert(output12 == 5);

            // Problem 13
            var prob13 = new Problem13();
            string output13 = prob13.problem13(text: "abcba", k: 2);
            System.Console.WriteLine($"\nProblem 13: {output13}");
            Debug.Assert(output13 == "bcb");
            output13 = prob13.problem13("aabbcc", 2);
            System.Console.Write($"Problem 13: {output13}");
            Debug.Assert(output13 == "aabb" || output13 == "bbcc");
            output13 = prob13.problem13Another("aabbcc", 3);
            System.Console.Write($"\nProblem 13: {output13}");
            Debug.Assert(output13 == "aabbcc");
            output13 = prob13.problem13("aabbcc", 4);
            System.Console.Write($"\nProblem 13: {output13}");
            Debug.Assert(output13 == String.Empty);

            // Problem Delete Multiple Items
            var delItem = new DeleteMultipleItems();
            int[] actual = delItem.DeleteNth(new int[] { 1, 1, 3, 3, 7, 2, 2, 2, 2 }, 3);
            var expected = new int[] { 1, 1, 3, 3, 7, 2, 2, 2 };

            Debug.Assert(expected.SequenceEqual(actual));

            // Problem 15
            var prob15 = new Problem15();
            IEnumerable<int> prob15Output = prob15.problem15(10);
            System.Console.Write("\nProblem 15: ");
            prob15Output.ToList().ForEach(_ => System.Console.Write(_ + " "));

            // Problem 16
            // input = 100
            var prob16 = new Problem16();
            var prob16Expected = prob16.problem16();
            System.Console.WriteLine($"\nProblem 16: {prob16Expected}");
            Debug.Assert(prob16Expected == 95);

            // Problem 17
            var prob17 = new Problem17();
            int prob17Output = prob17.problem17("dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext");
            System.Console.WriteLine($"Problem 17: {prob17Output}");
            Debug.Assert(prob17Output == 20);
            prob17Output = prob17.problem17("dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext");
            System.Console.WriteLine($"Problem 17: {prob17Output}");
            Debug.Assert(prob17Output == 32);

            // Problem 18
            var prob18 = new Problem18();
            IEnumerable<int> prob18Output = prob18.problem18(array: new int[] { 10, 5, 2, 7, 8, 7 }, k: 3);
            System.Console.Write("Problem 18: ");
            prob18Output.ToList().ForEach(_ => System.Console.Write(_ + " "));
            prob18Output = prob18.problem18Optimized(array: new int[] { 11, 12, 13, 12, 14, 11, 10, 9 }, k: 3);
            System.Console.Write("\nProblem 18: ");
            prob18Output.ToList().ForEach(_ => System.Console.Write(_ + " "));

            // Problem 22
            var prob22 = new Problem22();
            var text = "thequickbrownfox";
            var dic = new string[] { "quick", "brown", "the", "fox" };
            var prob22Output = prob22.problem22(text, dic);
            System.Console.Write("\nProblem 22: ");
            prob22Output.ToList().ForEach(_ => System.Console.Write(_ + " "));
            Debug.Assert(prob22Output.SequenceEqual(new string[] { "the", "quick", "brown", "fox" }));

            var prob22Other = prob22.prob22Another("bedbathandbeyond", new string[] {"bed", "bath", "bedbath", "and",
            "beyond"});
            System.Console.Write("\nProblem 22: ");
            prob22Other.ToList().ForEach(_ => System.Console.Write(_ + " "));

            // Problem 26
            var prob26 = new Problem26();
            var prob26Output = prob26.problem26(2);
            System.Console.WriteLine($"\nProblem 26: {prob26Output}");

            // Problem min window
            var minWindow = new MinWindowProblem();
            IEnumerable<String> minOutput = minWindow.minWindowOther("this is a test string", "tist");
            System.Console.Write("Min Window: ");
            minOutput.ToList().ForEach(_ => System.Console.WriteLine(_));
            // Debug.Assert(minOutput == "t stri");
            minOutput = minWindow.minWindowOther("a", "b");
            System.Console.Write("\nMin Window: ");
            minOutput.ToList().ForEach(_ => System.Console.WriteLine(_));
            // Debug.Assert(minOutput == "");

            // Remove duplicates recursively
            var remDups = new RemoveDuplicates();
            string dupOutput = remDups.removeDuplicates("careermonk");
            System.Console.WriteLine($"\nRemove duplicates: {dupOutput}");
            Debug.Assert(dupOutput == "camonk");
            dupOutput = remDups.removeDuplicates("geeksforgeeg");
            System.Console.WriteLine($"Remove duplicates: {dupOutput}");
            Debug.Assert(dupOutput == "gksfor");

            // word boggle
            char[,] matrix = {
                                { 'o', 'a', 'a', 'n' },
                                { 'e', 't', 'a', 'e' },
                                { 'i', 'h', 'k', 'r' },
                                {'i', 'f', 'l', 'v'}
                            };
            string[] words = { "oath", "pea", "eat", "rain" };
            System.Console.Write("Word boggle: ");
            var boggle = new Boggle().boggle(matrix, words);
            System.Console.WriteLine(string.Join(", ", boggle));
            Debug.Assert(boggle.OrderBy(x => x).ToList().SequenceEqual(new string[] { "eat", "oath" }));

            // Candy problem
            var candy = new Candy().candy(new int[] { 1, 0, 2 });
            var candyOutput = 5;
            System.Console.WriteLine($"Minimum Candies: {candy}");
            Debug.Assert(candy == candyOutput);
            candy = new Candy().candy(new int[] { 1, 2, 2 });
            candyOutput = 4;
            System.Console.WriteLine($"Minimum Candies: {candy}");
            Debug.Assert(candy == candyOutput);

            // Lowest Common Ancestor - BST
            var lcaBst = new LowestCommonAncestorBST();
            var lcabstOutput = lcaBst.lca();
            System.Console.WriteLine($"LCA BST: {lcabstOutput}");
            Debug.Assert(lcabstOutput == 12);

            // Lowest Common Ancestor - BT
            var lcaBt = new LowestCommonAncestorBT();
            var lcabtOutput = lcaBt.lca();
            System.Console.WriteLine($"LCA BT: {lcabtOutput}");
            Debug.Assert(lcabtOutput == 2);

            // Topology Sort
            var topo = new TopologySort();
            var topoOutput = topo.topologySort();
            System.Console.WriteLine($"Topology sort: {string.Join(',', topoOutput.ToList())}");
            Debug.Assert(topoOutput.SequenceEqual(new int[] { 5, 4, 2, 3, 1, 0 }));

            // LRU
            var lru = new LRU(4);
            lru.put(1, 1);
            lru.put(10, 15);
            lru.put(15, 10);
            lru.put(10, 16);
            System.Console.WriteLine($"LRU cache size: {lru.getCacheSize()}"); // 3
            System.Console.WriteLine($"Get LRU key-10: {lru.get(10)}"); // 16

            lru.put(12, 15);
            lru.put(18, 10);
            System.Console.WriteLine($"LRU cache size: {lru.getCacheSize()}"); // 4
            lru.put(13, 16);
            System.Console.WriteLine($"LRU cache size: {lru.getCacheSize()}"); // 4
            System.Console.WriteLine($"Get LRU key-1: {lru.get(1)}"); // -1
            System.Console.WriteLine($"Get LRU key-15: {lru.get(15)}"); // -1
            System.Console.WriteLine($"Get LRU key-18: {lru.get(18)}"); // 10
            System.Console.WriteLine($"Get LRU key-13: {lru.get(13)}"); // 16

            // Number Of Islands
            int[,] islands = {
                {0,1},
                {1,0},
                {1,1},
                {1,0}
            };
            int connected = new NumberOfIslands().numerOfIslands(islands);
            System.Console.WriteLine($"Number of Connected islands is: {connected}");
            Debug.Assert(connected == 1);
            islands = new int[,]{
                   {0,1,1,1,0,0,0},
                   {0,0,1,1,0,1,0}
            };
            connected = new NumberOfIslands().numerOfIslands(islands);
            System.Console.WriteLine($"Number of Connected islands is: {connected}");
            Debug.Assert(connected == 2);

            // Minimum number of swaps
            int[] array = { 4, 3, 2, 1 };
            int minswaps = new MinimumSwapsToSort().minimumSwaps(array);
            System.Console.WriteLine($"Minimum swap for array -> {string.Join(",", array)} : {minswaps}");
            Debug.Assert(minswaps == 2);

            array = new int[] { 1, 5, 4, 3, 2 };
            minswaps = new MinimumSwapsToSort().minimumSwaps(array);
            System.Console.WriteLine($"Minimum swap for array -> {string.Join(",", array)} : {minswaps}");
            Debug.Assert(minswaps == 2);

            // Snakes and Ladder
            // int[] positions = {3, 22, 5, 8, 11, 26, 20, 29,
            //     17, 4, 19, 7, 27, 1, 21, 9};
            (int rows, int cols) = (5, 6);
            int steps = rows * cols;

            int[] moves = new int[steps];
            Enumerable.Range(0, steps).ToList().ForEach(x =>
            {
                moves[x] = -1;
            });

            // Ladders 
            moves[2] = 21;
            moves[4] = 7;
            moves[10] = 25;
            moves[19] = 28;

            // Snakes  
            moves[26] = 0;
            moves[20] = 8;
            moves[16] = 3;
            moves[18] = 6;

            int minDistance = new SnakesNLadders().snakesnLadder(moves, steps);
            System.Console.WriteLine($"Snakes n Ladder: Minimum dice roll needed: {minDistance}");
            Debug.Assert(minDistance == 3);
        }
    }
}
