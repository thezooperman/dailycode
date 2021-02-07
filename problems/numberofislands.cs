using System;
using System.Collections.Generic;

namespace problems
{
    class NumberOfIslands
    {
        /*
          Find the number of islands.

          Given a grid consisting of '0's(Water) and '1's(Land).
          Find the number of islands.

          Note: An island is surrounded by water and is formed by
          connecting adjacent lands horizontally or vertically or
          diagonally i,e in all 8 directions.

          Input:
            grid = {{0,1},{1,0},{1,1},{1,0}}
            Output:
            1
            Explanation:
            The grid is-
            0 1
            1 0
            1 1
            1 0
            All lands are connected.
        
          Input:
            grid = {{0,1,1,1,0,0,0},{0,0,1,1,0,1,0}}
            Output:
            2
            Expanation:
            The grid is-
            0 1 1 1 0 0 0
            0 0 1 1 0 1 0 
            There are two islands one is colored in blue 
            and other in orange.
        */

        private IList<(int x, int y)> directions = new List<(int x, int y)>
         {
            (0, -1), (0, 1), (1, 0), (-1, 0),
            (-1, -1), (1, 1), (-1, 1), (1, -1)
        };

        private int getCell(int[,] graph, bool[,] visited, int row, int col)
        {
            var (rows, cols) = (graph.GetLength(0), graph.GetLength(1));
            if ((0 <= row) && (row < rows) && (0 <= col) && (col < cols) && !visited[row, col])
                return graph[row, col];
            return 0;
        }

        private int findIslands(int[,] graph, bool[,] visited, int row, int col)
        {
            if (visited[row, col])
                return 0;

            int count = 0;
            if (graph[row, col] == 1 && !visited[row, col])
                count = 1;
            visited[row, col] = true;

            Queue<(int row, int col)> queue = new Queue<(int row, int col)>();

            queue.Enqueue((row, col));

            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();
                foreach (var (a, b) in directions)
                {
                    var (dx, dy) = (x + a, y + b);
                    if (this.getCell(graph, visited, dx, dy) == 1)
                    {
                        visited[dx, dy] = true;
                        queue.Enqueue((dx, dy));
                        count = 1;
                    }
                }
            }
            return count;
        }

        public int numerOfIslands(int[,] graph)
        {
            int rows = graph.GetLength(0), cols = graph.GetLength(1);
            bool[,] visited = new bool[rows, cols];
            int islands = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                    islands += this.findIslands(graph, visited, row, col);
            }

            return islands;
        }
    }
}