using System;
using System.Collections.Generic;

namespace problems
{
    class Boggle
    {
        /*
            Given an m x n board of characters and a list of strings words, return all words on the board.

            Each word must be constructed from letters of sequentially adjacent cells, where adjacent cells
            are horizontally or vertically neighboring. The same letter cell may not be used more than once
            in a word.

            Example 1:

            Input: board = [["o","a","a","n"],["e","t","a","e"],["i","h","k","r"],["i","f","l","v"]],
            words = ["oath","pea","eat","rain"]
            Output: ["eat","oath"]
        */


        private bool isSafe(char[][] board, int row, int col)
        {
            return (0 <= row) && (0 < board.Length) && (0 <= col) && (col < board[0].Length)
            && (!visited.Contains(Tuple.Create<int, int>(row, col)));
        }

        private String searchUtil(char[][] board, HashSet<string> words, int row, int col, string tmpStr)
        {
            if (words.Contains(tmpStr))
            {
                words.Remove(tmpStr);
                return tmpStr;
            }

            var current = Tuple.Create<int, int>(row, col);
            if (this.isSafe(board, row, col))
                visited.Add(current);

            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(current);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                foreach (var direction in directions)
                {
                    int newR = row + direction.Item1, newC = col + direction.Item2;
                    if (isSafe(board, newR, newC) && words.Contains(tmpStr + board[newR][newC]))
                    {
                        var newCord = Tuple.Create(newR, newC);
                        queue.Enqueue(newCord);
                    }
                }
            }
            return string.Empty;
        }

        private HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();
        private IList<Tuple<int, int>> directions = new List<Tuple<int, int>>{
            Tuple.Create<int, int>(0, 1),
            Tuple.Create<int, int>(0, -1),
            Tuple.Create<int, int>(-1, 0),
            Tuple.Create<int, int>(1, 0),
        };

        public IEnumerable<string> boggle(char[][] board, string[] words)
        {
            int rows = board.Length, cols = board[0].Length;
            HashSet<string> lookUp = new HashSet<string>(words);

            string tmpStr = string.Empty;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (lookUp.Contains(board[row][col].ToString()))
                    {
                        tmpStr += board[row][col];
                    }
                }
            }
            return new List<String>();
        }
    }
}