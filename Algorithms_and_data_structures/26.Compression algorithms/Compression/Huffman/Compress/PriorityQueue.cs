using System;
using System.Collections.Generic;

namespace Compression
{
    public class PriorityQueue<T>
    {
        int size;

        SortedDictionary<int, Queue<T>> storage;

        public PriorityQueue()
        {
            size = 0;
            storage = new SortedDictionary<int, Queue<T>>();
        }

        public int Size() => size;

        public void Enquueue(int priority, T item)
        {
            if (!storage.ContainsKey(priority))
            {
                storage.Add(priority, new Queue<T>());
            }

            storage[priority].Enqueue(item);

            size++;
        }

        public T Dequeue()
        {
            if (size == 0)
            {
                throw new Exception("Queue is empty");
            }

            size--;

            foreach (var queue in storage.Values)
            {
                if (queue.Count > 0)
                {
                    return queue.Dequeue();
                }
            }

            throw new Exception("Queue error");
        }
    }
}