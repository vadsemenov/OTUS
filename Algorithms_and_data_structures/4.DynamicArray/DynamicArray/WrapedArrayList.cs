using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicArray
{
    public class WrapedArrayList<T> : IArray<T>
    {
        private ArrayList _storage = new ArrayList();

        public int Size() => _storage.Count;

        public void Add(T item)
        {
            _storage.Add(item);
        }

        public T Get(int index)
        {
            if (_storage.Count + 1 >= index)
            {
                return (T) _storage[index];
            }

            throw new IndexOutOfRangeException();
        }

        public void Add(T item, int index)
        {
            if (_storage.Count - 1 < index)
            {
                var numberOfListsToAdd = index - _storage.Count + 1;

                for (int i = 0; i < numberOfListsToAdd; i++)
                {
                    _storage.Add(default);
                }
            }

            _storage[index] = item;
        }

        public T Remove(int index)
        {
            if (_storage.Count + 1 >= index)
            {
                var element = (T) _storage[index];

                _storage.RemoveAt(index);

                return element;
            }

            throw new IndexOutOfRangeException();
        }

        public void PrintArray()
        {
            foreach (var value in _storage)
            {
                Console.Write(" " + (T) value);
            }
        }

        public void Remove()
        {
            if (_storage.Count > 0)
            {
                _storage.Remove(_storage.Count - 1);
            }
        }
    }
}