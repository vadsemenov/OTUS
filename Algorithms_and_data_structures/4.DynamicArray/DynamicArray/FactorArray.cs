using System;

namespace DynamicArray
{
    public class FactorArray<T> : IArray<T>
    {
        private Object[] array;
        private int factor;
        private int size;

        public FactorArray(int factor, int initLength)
        {
            this.factor = factor;
            array = new Object[initLength];
            size = 0;
        }

        public FactorArray() : this(50, 10)
        {
        }

        public int Size()
        {
            return size;
        }

        public void Add(T item)
        {
            if (Size() == array.Length)
                Resize();
            array[size] = item;
            size++;
        }

        public T Get(int index)
        {
            return (T) array[index];
        }

        public void Add(T item, int index)
        {
            if (Size() == array.Length)
                Resize();
            Array.Copy(array, index, array, index + 1, size - index);
            array[index] = item;
            size++;
        }

        public T Remove(int index)
        {
            T deletedItem = (T) array[index];
            for (int i = index; i < Size(); i++)
            {
                array[i] = array[i + 1];
            }

            size--;

            return deletedItem;
        }

        private void Resize()
        {
            Object[] newArray = new Object[array.Length + array.Length * factor / 100];
            Array.Copy(array, 0, newArray, 0, array.Length);
            array = newArray;
        }

        public void PrintArray()
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}