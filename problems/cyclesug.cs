using System.Collections.Generic;
using System.Linq;

namespace problems
{
    class CyclesInUndirectedGraph
    {
        private List<List<int>> _edges;

        private int _vertices = default;

        public CyclesInUndirectedGraph(int vertices)
        {
            _vertices = vertices;
            Enumerable
                .Range(0, _vertices)
                .ToList()
                .ForEach(_ => (_edges ??= new List<List<int>>()).Add(new List<int>()));
        }

        private void AddEdge(int u, int v)
        {
            _edges[u].Add(v);
            _edges[v].Add(u);
        }


        // Visited adjacent node must be
        // parent of current to not form a back edge 
        private bool hasCycle(int vertex, bool[] visited, int parent)
        {
            visited[vertex] = true;

            foreach (int edge in _edges[vertex])
            {
                if (!visited[edge])
                    if (hasCycle(edge, visited, vertex))
                        return true;
                    else if (edge != parent)
                        return true;
            }
            return false;
        }

        public bool DetectCycle()
        {
            this.AddEdge(1, 0);
            this.AddEdge(0, 2);
            this.AddEdge(2, 1);
            this.AddEdge(0, 3);
            this.AddEdge(3, 4);

            bool[] visited = new bool[_vertices];
            System.Array.Fill(visited, false);

            var result = false;

            for (int i = 0; i < _vertices; i++)
            {
                if (!visited[i])
                    result = this.hasCycle(i, visited, -1);
            }

            return result;
        }
    }
}