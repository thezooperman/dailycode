using System.Collections.Generic;
using System.Linq;

namespace problems
{
    class TopologySort
    {
        /*
            Topological sorting for Directed Acyclic Graph (DAG) is a linear ordering
            of vertices such that for every directed edge u v, vertex u comes before v
            in the ordering. Topological Sorting for a graph is not possible if the
            graph is not a DAG, using DFS.

            Graph:
                5 --> 2
                5 --> 0

                2 --> 3

                3 --> 1

                4 --> 0
                4 --> 1

            Possible output: 5 4 2 3 1 0
        */
        internal class Graph
        {
            private int V;
            private List<List<int>> edges;

            public Graph(int vertices)
            {
                V = vertices;
                // edges = new List<List<int>>();
                Enumerable.Range(0, V)
                          .ToList()
                          .ForEach(_ => (edges ??= new List<List<int>>()).Add(new List<int>()));
            }

            public void AddEdge(int v, int w) => this.edges[v].Add(w);

            void sortUtil(int v, bool[] visited, Stack<int> stack)
            {
                // mark current node as visited
                visited[v] = true;

                // for each adjacent nodes(edges), traverse
                foreach (int edge in this.edges[v])
                    // only the edges which are not traversed
                    if (!visited[edge])
                        this.sortUtil(edge, visited, stack);

                // a vertex is added, only after all the edges are visited
                stack.Push(v);
            }

            public IEnumerable<int> Sort()
            {
                Stack<int> stack = new Stack<int>();
                var visited = new bool[V];

                Enumerable.Range(0, V)
                          .ToList()
                          .ForEach(i =>
                            {
                                if (!visited[i])
                                    this.sortUtil(i, visited, stack);
                            }
                          );
                return stack;
            }
        }

        public IEnumerable<int> topologySort()
        {
            Graph graph = new Graph(6);
            graph.AddEdge(5, 2);
            graph.AddEdge(5, 0);
            graph.AddEdge(4, 0);
            graph.AddEdge(4, 1);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 1);

            return graph.Sort();
        }
    }
}