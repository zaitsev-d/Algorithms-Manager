using System;
using Algorithms_Manager.Graphs;
using Algorithms_Manager.HashTables;

namespace Algorithms_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("= = = Algorithms Manager MENU = = =");
                Console.WriteLine("------Hash-Tables------");
                Console.WriteLine("A. Chained Hash-Table.");
                Console.WriteLine("B. Linear Hash-Table.\n");
                Console.WriteLine("------Graphs------");
                Console.WriteLine("C. Breadth First Search.");
                Console.WriteLine("D. Prim Minimum Spanning Tree.\n");
                Console.WriteLine("------------------------------");
                Console.WriteLine("E. Quit.\n");

                Console.Write("What are you choose? ---> ");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch(key.Key)
                {
                    case ConsoleKey.A: ChainedHashTable(); break;
                    case ConsoleKey.B: LinearHashTable(); break;
                    case ConsoleKey.C: BFS(); break;
                    case ConsoleKey.D: PrimMST(); break;
                    case ConsoleKey.E: Environment.Exit(0); break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void ChainedHashTable()
        {
            int size = default, numbers = default;
            Console.Write("Write hash - table size: ");
            size = int.Parse(Console.ReadLine());

            Console.Write("How many needs to numbers in hash - table: ");
            numbers = int.Parse(Console.ReadLine());

            HashTable hashTable = new HashTable(size);
            Random rand = new Random();

            for(int i = 0; i < numbers; i++)
            {
                int n = rand.Next(0, 1000);
                hashTable.Insert(n);
            }

            Console.WriteLine("Hash Table: ");
            hashTable.Print();

            Console.WriteLine("\n");
        }

        public static void LinearHashTable()
        {
            int size = default, numbers = default;
            Console.Write("Write hash - table size: ");
            size = int.Parse(Console.ReadLine());

            Console.Write("How many needs to numbers in hash - table: ");
            numbers = int.Parse(Console.ReadLine());

            LinearHashTable linearHashTable = new LinearHashTable(size);
            Random rand = new Random();

            for (int i = 0; i < numbers; i++)
            {
                int n = rand.Next(0, 1000);
                linearHashTable.Insert(n);
            }

            Console.WriteLine("Hash Table: ");
            linearHashTable.Show();

            linearHashTable.Dispose();
            Console.WriteLine("\n");
        }

        public static void BFS()
        {
            // Create a graph given in the below diagram
            Graph g = new Graph(4);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            g.BFS(2);
            Console.WriteLine("\n");
        }

        public static void PrimMST()
        {
            MST graphPrim = new MST(5);
            int[,] graph = new int[,] {{0, 2, 0, 6, 0},
                                       {2, 0, 3, 8, 5},
                                       {0, 3, 0, 0, 7},
                                       {6, 8, 0, 0, 9},
                                       {0, 5, 7, 9, 0}};

            graphPrim.primMST(graph);
            Console.WriteLine("\n");
        }
    }
}
