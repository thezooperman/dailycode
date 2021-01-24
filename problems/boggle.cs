using System;
using System.Linq;
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

            Runtime: O(4^(N^2)) , 4 directions, and N^2 loop
            Space: O(N^2) --> m * n or n * n matrix
        */


        private bool isSafe(char[,] board, bool[,] visited, int row, int col)
        {
            return (0 <= row) && (row < board.GetLength(0)) && (0 <= col) && (col < board.GetLength(1))
            && (!visited[row, col]);
        }

        private void searchUtil(char[,] board, bool[,] visited, HashSet<string> words, int row, int col, string tmpStr, ISet<String> results, int maxLen)
        {
            if (visited[row, col] || tmpStr.Length >= maxLen)
                return;

            visited[row, col] = true;
            tmpStr += board[row, col];

            if (words.Contains(tmpStr))
            {
                words.Remove(tmpStr);
                results.Add(tmpStr);
            }

            foreach (var direction in directions)
            {
                int newRow = row + direction.x, newCol = col + direction.y;
                if ((isSafe(board, visited, newRow, newCol)) && (!visited[newRow, newCol]))
                    this.searchUtil(board, visited, words, newRow, newCol, tmpStr, results, maxLen);
            }

            visited[row, col] = false;
            tmpStr = "" + tmpStr[tmpStr.Length - 1];
        }

        private IList<(int x, int y)> directions = new List<(int x, int y)>
        {
            (0, 1),
            (0, -1),
            (-1, 0),
            (1, 0),
        };

        public ISet<string> boggle(char[,] board, string[] words)
        {
            int rows = board.GetLength(0), cols = board.GetLength(1);
            HashSet<string> lookUp = new HashSet<string>(words);
            bool[,] visited = new bool[rows, cols];

            ISet<string> results = new HashSet<String>();

            int maxLen = lookUp.Max(_ => _.Length);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                    this.searchUtil(board, visited, lookUp, row, col, "", results, maxLen);

            }
            return results;
        }
    }
}