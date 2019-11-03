using System;

namespace Algorithms_Manager.HashTables
{
    class HashTable
    {
        class Node
        {
            public int Key { get; set; }
            public Node Next { get; set; }

            public Node(int key, Node next = null)
            {
                Key = key;
                Next = next;
            }
        }

        private Node[] table;

        public HashTable(int size)
        {
            table = new Node[size];
            Clear();
        }

        public int GetLength => table.Length;

        private int GetHashValue(int key)
        {
            return key % GetLength;
        }

        public bool Insert(int key)
        {
            int hash = GetHashValue(key);

            if (table[hash] == null)
            {
                table[hash] = new Node(key, table[hash]);
            }
            else
            {
                if (table[hash].Key == key)
                    return false;

                Node temp = table[hash];
                while (temp.Next != null && temp.Next.Key != key)
                    temp = temp.Next;

                if (temp.Next != null && temp.Next.Key == key)
                    return false;

                temp.Next = new Node(key);
            }

            return true;
        }

        public bool Contains(int key)
        {
            int hash = GetHashValue(key);

            Node temp = table[hash];

            while (temp != null && temp.Key != key) temp = temp.Next;

            return temp != null ? true : false;

        }

        public bool Delete(int key)
        {
            int hash = GetHashValue(key);

            if (table[hash] != null)
            {
                if (table[hash].Key == key)
                    table[hash] = table[hash].Next;
                else
                {
                    Node temp = table[hash];
                    while (temp.Next != null && temp.Next.Key != key)
                        temp = temp.Next;

                    if (temp.Next != null)
                        temp.Next = temp.Next.Next;

                }
            }

            return true;
        }

        public void Clear()
        {
            for (int i = 0; i < GetLength; i++)
                table[i] = null;
        }

        public void Print()
        {
            for (int i = 0; i < GetLength; i++)
            {
                Node temp = table[i];
                Console.Write($"[{i + 1}]: ");
                while (temp != null)
                {
                    Console.Write(temp.Key + " -> ");
                    temp = temp.Next;
                }
                Console.Write("NULL");
                Console.WriteLine();
            }
        }
    }
}
