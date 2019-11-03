using System;
using System.Collections.Generic;

namespace Algorithms_Manager.HashTables
{
    public enum AnonymousEnum
    {
        Deleted = -2,
        NotFound = -1
    }

    public class LinearHashTable : IDisposable
    {
        private List<int> hash_table = new List<int>();
        private int capacity;

        private int findIndexOfElement(int hashValue, int key)
        {
            for (int i = 0; i < capacity; i++)
            {
                _count++;
                if (hash_table[hashValue] == 0 || hash_table[hashValue] == key) break;
                hashValue = (hashValue + 1) % capacity;
            }
            return hashValue;
        }

        public int _count;

        public LinearHashTable(int capacity = 129)
        {
            this.capacity = capacity;
            for (int i = 0; i < capacity; i++)
            {
                hash_table.Add(0);
            }
            // 0 means the field is empty
        }

        public void Dispose()
        {
            hash_table.Clear();
        }

        public int getSize()
        {
            return capacity;
        }

        public int getHashValue(int key)
        {
            return key % getSize();
        }

        public bool Insert(int key)
        {
            int hashValue = getHashValue(key);

            // find the place for insertion
            for (int i = 0; i < capacity; i++)
            {
                if (hash_table[hashValue] == 0 || hash_table[hashValue] == key || hash_table[hashValue] == (int)AnonymousEnum.Deleted) break;
                hashValue = (hashValue + 1) % capacity;
            }

            // if the place is empty then we insert in there
            if (hash_table[hashValue] == 0 || hash_table[hashValue] == (int)AnonymousEnum.Deleted)
            {
                hash_table[hashValue] = key;
                return true;
            }

            return false;
        }

        public int Find(int key)
        {
            int hashValue = getHashValue(key);

            // find the element
            hashValue = findIndexOfElement(hashValue, key);

            // if we found the element then return it
            if (hash_table[hashValue] == key)
            {
                return hash_table[hashValue];
            }

            return (int)AnonymousEnum.NotFound;
        }

        public int Delete(int key)
        {
            int hashValue = getHashValue(key);

            hashValue = findIndexOfElement(hashValue, key);

            if (hash_table[hashValue] == key)
            {
                hash_table[hashValue] = (int)AnonymousEnum.Deleted;
                return key;
            }

            return 0;
        }

        public void Show()
        {
            for (int i = 0; i < capacity; i++)
            {
                if((i + 1) % 10 == 0) Console.WriteLine($"[ {i} ]: 0");
                else Console.WriteLine($"[ {i} ]: {hash_table[i]}");
            }
        }
    }
}
