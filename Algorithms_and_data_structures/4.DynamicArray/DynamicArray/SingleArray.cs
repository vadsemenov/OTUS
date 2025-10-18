using System;
using System.Linq;

namespace DynamicArray
{
    public class SingleArray<T> : IArray<T>
    {
        private Object[] array;

        public SingleArray()
        {
            array = new Object[0];
        }

        public int Size()
        {
            return array.Length;
        }

        public void Add(T item)
        {
            Resize();
            array[Size() - 1] = item;
        }

        public T Get(int index)
        {
            return (T) array[index];
        }

        public void Add(T item, int index)
        {
            Resize();
            Array.Copy(array, index, array, index + 1, array.Length - index - 1);
            array[index] = item;
        }

        public T Remove(int index)
        {
            T deletedItem = (T) array[index];
            Object[] newArray = new Object[Size() - 1];
            Array.Copy(array, 0, newArray, 0, index);
            Array.Copy(array, index + 1, newArray, index, newArray.Length - index);
            array = newArray;

            return deletedItem;
        }

        private void Resize()
        {
            Object[] newArray = new Object[Size() + 1];
            Array.Copy(array, 0, newArray, 0, Size());
            array = newArray;
        }

        public void PrintArray()
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}