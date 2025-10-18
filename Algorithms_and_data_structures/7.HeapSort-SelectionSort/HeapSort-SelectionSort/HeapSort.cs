using System;
using Tester;

namespace HeapSort_SelectionSort
{
    public class HeapSort : ITask
    {
        private int[] _arr;

        public string Run(string[] data)
        {
            var arrLength = Convert.ToInt32(data[0]);

            var strArray = data[1].Split(' ');

            _arr = new int[arrLength];
            for (int i = 0; i < arrLength; i++)
            {
                _arr[i] = Convert.ToInt32(strArray[i]);
            }

            return string.Join(" ", Sort());
        }

        public int[] Sort()
        {
            int size = _arr.Length;

            for (int i = size / 2 - 1; i >= 0; i--)
            {
                SiftElement(_arr, size, i);
            }

            for (int i = size - 1; i >= 1; i--)
            {
                int temp = _arr[0];
                _arr[0] = _arr[i];
                _arr[i] = temp;

                SiftElement(_arr, i, 0);
            }

            return _arr;
        }

        private void SiftElement(int[] array, int size, int index)
        {
            while (index * 2 + 1 < size)
            {
                int maxChildIndex;

                int leftChildIndex = index * 2 + 1;
                int rightChildIndex = index * 2 + 2;

                if (leftChildIndex == size - 1)
                {
                    maxChildIndex = leftChildIndex;
                }
                else if (array[leftChildIndex] > array[rightChildIndex])
                {
                    maxChildIndex = leftChildIndex;
                }
                else
                {
                    maxChildIndex = rightChildIndex;
                }

                if (array[index] >= array[maxChildIndex])
                {
                    return;
                }

                int temp = array[index];
                array[index] = array[maxChildIndex];
                array[maxChildIndex] = temp;

                index = maxChildIndex;
            }
        }
    }
}