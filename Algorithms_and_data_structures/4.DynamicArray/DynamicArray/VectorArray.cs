using System;

namespace DynamicArray
{
    public class VectorArray<T> : IArray<T>
    {
        private Object[] array;
        private int vector;
        private int size;

        public VectorArray(int vector)
        {
            this.vector = vector;
            array = new Object[0];
            size = 0;
        }

        public VectorArray() : this(10)
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
            if (index >= size)
                return;

            if (Size() == array.Length)
                Resize();

            Array.Copy(array, index, array, index + 1, size - index);
            array[index] = item;
            size++;
        }

        public T Remove(int index)
        {
            if (index >= size)
                return default(T);

            T deletedItem = (T) array[index];
            for (int i = index; i < Size() - 1; i++)
            {
                array[i] = array[i + 1];
            }

            size--;

            return deletedItem;
        }

        private void Resize()
        {
            Object[] newArray = new Object[array.Length + vector];
            Array.Copy(array, 0, newArray, 0, array.Length);
            array = newArray;
        }

        public void PrintArray()
        {
            for (int i = 0; i < Size(); i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.Write("\r\n");
            // Console.WriteLine(string.Join(" ", array));
        }
    }
}