using System;

namespace DynamicArray
{
    public class MatrixArray<T> : IArray<T>
    {
        private int size;
        private int vector;
        private IArray<T[]> array;

        public MatrixArray(int vector)
        {
            this.vector = vector;
            array = new VectorArray<T[]>(1);
            size = 0;
        }

        public MatrixArray() : this(10)
        {
        }

        public int Size()
        {
            return size;
        }

        public void Add(T item)
        {
            if (size == array.Size() * vector)
                array.Add(new T[vector]);

            array.Get(size / vector)[size % vector] = item;

            size++;
        }

        public T Get(int index)
        {
            return array.Get(index / vector)[index % vector];
        }

        public void Add(T item, int index)
        {
            if (index > size - 1)
                return;

            var newArray = new VectorArray<T[]>();
            var newSize = 0;
            var isAdded = false;

            var outerIndex = index / vector;
            var innerIndex = index % vector;

            var matrixRowCount = size % vector == 0 ? size / vector : (size / vector) + 1;

            for (int i = 0; i < matrixRowCount; i++)
            {
                for (int j = 0; j < vector; j++)
                {
                    if (newSize == newArray.Size() * vector)
                    {
                        newArray.Add(new T[vector]);
                    }

                    if (i == outerIndex && j == innerIndex)
                    {
                        newArray.Get(i)[j] = item;
                        isAdded = true;
                        newSize++;
                    }

                    if (isAdded)
                    {
                        if (array.Get(i)[j].Equals(default(T)))
                        {
                            continue;
                        }

                        if (j + 1 <= vector - 1)
                        {
                            newArray.Get(i)[j + 1] = array.Get(i)[j];
                        }
                        else
                        {
                            if (newSize == newArray.Size() * vector)
                            {
                                newArray.Add(new T[vector]);
                            }

                            newArray.Get(i + 1)[0] = array.Get(i)[j];
                        }
                    }
                    else
                    {
                        newArray.Get(i)[j] = array.Get(i)[j];
                    }

                    newSize++;
                }
            }

            array = newArray;
            size = newSize;
        }

        public T Remove(int index)
        {
            if (index > size - 1)
            {
                throw new IndexOutOfRangeException();
            }

            var newArray = new VectorArray<T[]>(1);
            var newSize = 0;
            var isRemoved = false;

            var outerIndex = index / vector;
            var innerIndex = index % vector;
            var removedItem = array.Get(outerIndex)[innerIndex];

            var matrixRowCount = size % vector == 0 ? size / vector : (size / vector) + 1;

            for (var i = 0; i < matrixRowCount; i++)
            {
                for (var j = 0; j < vector; j++)
                {
                    if (newSize == newArray.Size() * vector)
                    {
                        newArray.Add(new T[vector]);
                    }

                    if (i == outerIndex && j == innerIndex)
                    {
                        isRemoved = true;
                        break;
                    }

                    newArray.Get(i)[j] = array.Get(i)[j];

                    newSize++;
                }

                if (isRemoved)
                {
                    break;
                }
            }

            if (newSize < size - 1)
            {
                var continueRowIndex = (newSize + 1) / vector;
                var continueCellIndex = (newSize + 1) % vector;
                for (var i = continueRowIndex; i < matrixRowCount; i++)
                {
                    for (var j = continueCellIndex; j < vector; j++)
                    {
                        if (newSize == newArray.Size() * vector)
                        {
                            newArray.Add(new T[vector]);
                        }

                        if (j - 1 > -1 && j < vector)
                        {
                            newArray.Get(i)[j - 1] = array.Get(i)[j];
                        }
                        else if (j == 0)
                        {
                            newArray.Get(i - 1)[vector - 1] = array.Get(i)[j];
                        }

                        newSize++;
                    }

                    continueCellIndex = 0;
                }
            }

            if (newSize % vector == 0)
            {
                newArray.Remove(newSize / vector);
            }

            size = newSize;
            array = newArray;
            return removedItem;
        }

        public void PrintArray()
        {
            for (int i = 0; i < array.Size(); i++)
            {
                for (int j = 0; j < vector; j++)
                {
                    Console.Write(array.Get(i)[j] + " ");
                }

                Console.Write("\r\n");
            }
        }
    }
}