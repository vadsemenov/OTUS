using System.Collections.Generic;
using System;

namespace DynamicArray
{
    public class PriorityQueue<T>
    {
        int _size;

        List<List<T>> _storage;

        public PriorityQueue()
        {
            _size = 0;
            _storage = new List<List<T>>();
        }

        public int Size() => _size;

        public void Enqueue(int priority, T item)
        {
            if (_storage.Count - 1 < priority)
            {
                var numberOfListsToAdd = priority - _storage.Count + 1;

                for (int i = 0; i < numberOfListsToAdd; i++)
                {
                    _storage.Add(new List<T>());
                }
            }

            _storage[priority].Add(item);

            _size++;
        }

        public T Dequeue()
        {
            if (_size == 0)
            {
                throw new Exception("Queue is empty");
            }

            _size--;

            foreach (var list in _storage)
            {
                if (list.Count > 0)
                {
                    var indexOfLastElement = list.Count - 1;
                    var element = list[indexOfLastElement];

                    list.RemoveAt(indexOfLastElement);

                    return element;
                }
            }

            throw new Exception("Queue error");
        }
    }
}