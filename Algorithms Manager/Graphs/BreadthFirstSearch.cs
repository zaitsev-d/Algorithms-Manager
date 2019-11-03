using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms_Manager.Graphs
{
    class Graph
    {
        int vertex;

        List<int>[] neighbours;

        public Graph(int size)
        {
            vertex = size;
            neighbours = new List<int>[size];

            for (int i = 0; i < size; i++) neighbours[i] = new List<int>();
        }

        public void AddEdge(int v, int w) => neighbours[v].Add(w);

        public void BFS(int start)
        {
            bool[] visited = new bool[vertex].Select(element => element = false).ToArray();
            int[] road = new int[vertex];
            int[] pop = new int[vertex];

            var queue = new List<int>();
            visited[start] = true;
            road[start] = 0;
            queue.Add(start);

            while (queue.Count != 0)
            {
                int start2 = queue.Last();
                queue.RemoveAt(queue.Count - 1);

                foreach (int next in neighbours[start2])
                {
                    if (!visited[next])
                    {
                        visited[next] = true;
                        pop[next] = start2;
                        road[next] = road[start2] + 1;
                        queue.Add(next);
                    }
                }
            }

            for (int i = 0; i < vertex; i++)
            {
                Console.WriteLine(start + " -> " + i + " = " + road[i] + " | Pop ----> {0}", pop[i]);
            }

            Console.WriteLine("\n");
        }
    }
}
