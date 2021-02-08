using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace problems
{
    class SnakesNLadders
    {
        /*
            Snake and Ladder Problem

            Given a 5x6 snakes and ladders board, find the minimum number
            of dice throws required to reach the destination or last cell
            (30th cell) from the source (1st cell). You are given N ie -
            the total number of snakes and ladders and an array arr of 2*N
            size where 2*i and (2*i+1)th moves denotes the starting and
            ending point respecitvely of ith snake or ladder.

            Board Image: https://contribute.geeksforgeeks.org/wp-content/uploads/snake-and-ladders.jpg

            Example 1:

            Input:
            N = 8
            arr = {3, 22, 5, 8, 11, 26, 20, 29, 
                17, 4, 19, 7, 27, 1, 21, 9}
            Output:
            3
            Explaination:
            The given board is the board shown in the figure. For the above
            board output will be 3. For 1st throw get a 2. For 2nd throw get
            a 6. For 3rd throw get a 2.

            Expected Runtime: O(N)
        */

        internal class Node
        {
            public int vertex;
            public int distance;
        }

        public int snakesnLadder(int[] array, int steps)
        {
            Queue<Node> queue = new Queue<Node>();
            Node node = new Node() { distance = 0, vertex = 0 };

            queue.Enqueue(node);

            bool[] visited = new bool[steps];
            visited[node.vertex] = true;

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                if (node.vertex == steps - 1)
                    break;

                int vertex = node.vertex;

                for (int i = vertex + 1; i < steps && i <= (vertex + 6); ++i)
                {
                    if (!visited[i])
                    {
                        Node n = new Node();
                        n.distance = node.distance + 1;
                        visited[i] = true;

                        if (array[i] != -1)
                            n.vertex = array[i];
                        else
                            n.vertex = i;
                        queue.Enqueue(n);
                    }
                }
            }
            return node.distance;
        }
    }
}