using System.Collections.Generic;
using System.Linq;

namespace problems
{
    class CycleInDirectedGraph
    {
        /*
            Detect cycle in a directed thisAdd           Given a Directed Graph with V vertices
            and E edges, check whether it contains any cycle or not.
        */

        private List<List<int>> _edges;

        private int _vertices = default;

        public CycleInDirectedGraph(int vertices)
        {
            _vertices = vertices;
            Enumerable
                .Range(0, _vertices)
                .ToList()
                .ForEach(_ => (_edges ??= new List<List<int>>()).Add(new List<int>()));
        }

        protected void AddEdge(int u, int v) => _edges[u].Add(v);

        private bool hasCycle(int startNode)
        {
            Stack<int> stack = new Stack<int>();
            bool[] visited = new bool[_vertices];
            System.Array.Fill(visited, false);

            stack.Push(startNode);

            while (stack.Count > 0)
            {
                int top = stack.Pop();

                if (!visited[top])
                    visited[top] = true;

                foreach (int edge in _edges[top])
                {
                    if (!visited[edge])
                        stack.Push(edge);
                    else
                        return true;
                }

            }
            return false;
        }

        public bool detectCycle()
        {
            // this.AddEdge(0, 1);
            // this.AddEdge(0, 2);
            // this.AddEdge(1, 2);
            // this.AddEdge(2, 0);
            // this.AddEdge(2, 3);
            // this.AddEdge(3, 3);

            this.AddEdge(0, 1);
            this.AddEdge(0, 2);
            this.AddEdge(1, 2);
            this.AddEdge(2, 3);

            return this.hasCycle(1);
        }
    }
}