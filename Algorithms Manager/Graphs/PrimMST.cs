using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Manager.Graphs
{
    class MST
    {
        int vertex;
        public MST(int size) => vertex = size;

        //function to find the vertex with the minimum key value in MST
        public int minKey(int[] key, bool[] mstSet)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < vertex; i++)
            {
                if (mstSet[i] == false && key[i] < min)
                {
                    min = key[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public void printMST(int[] parent, int n, int[,] graph)
        {
            int sum = default(int);
            Console.WriteLine("Edge \tWeight");
            for (int i = 1; i < vertex; i++) { Console.WriteLine(parent[i] + " - " + i + "\t" + graph[i, parent[i]]); sum += graph[i, parent[i]]; }

            Console.WriteLine("\nSum: {0}", sum);

        }

        public void primMST(int[,] graph)
        {
            int[] parent = new int[vertex]; //Array to store constructed MST
            int[] key = new int[vertex]; //Key values used to pick min weight edge in cut
            bool[] mstSet = new bool[vertex]; //To represent vertices not yet included in MST

            for (int i = 0; i < vertex; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            key[0] = 0; // Make key 0 for the source vertex
            parent[0] = -1; //First node is always root of MST

            for (int count = 0; count < vertex - 1; count++)
            {
                int u = minKey(key, mstSet);

                mstSet[u] = true;

                for (int v = 0; v < vertex; v++)
                    if (graph[u, v] != 0 && mstSet[v] == false && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
            }

            printMST(parent, vertex, graph);
        }
    }
}
