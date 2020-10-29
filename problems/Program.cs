﻿using System;
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
            System.Console.WriteLine("Problem 1: " + new Problem1().problem1(arr, k));

            // Problem 2
            arr = new int[3] { 3, 2, 1 };
            System.Console.Write("Problem 2: ");
            new Problem2().problem2(arr).ToList().ForEach(x => System.Console.Write((x) + " "));
            System.Console.Write("\nProblem 2_1: ");
            new Problem2().problem2_1(arr).ToList().ForEach(x => System.Console.Write((x) + " "));
            // Expected output == [2, 3, 6]

            // Problem 3
            var root = new Problem3().populateNode();
            var nodes = new Problem3().serialize(root);
            System.Console.Write("\nProblem 3: ");
            System.Console.WriteLine(nodes);
            Debug.Assert(new Problem3().deserialize(nodes).Left.Left.Val == "left.left");

            // Problem 4
        }
    }
}
