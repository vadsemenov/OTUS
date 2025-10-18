using System;
using System.Globalization;
using Tester;

namespace HeapSort_SelectionSort
{
    public class SelectionSort :ITask
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
            var n = _arr.Length;

            int maxNumberIndex = FindMax(_arr.Length);

            for (int i = _arr.Length-1; i > 0; i--)
            {
                (_arr[i], _arr[maxNumberIndex]) = (_arr[maxNumberIndex], _arr[i]);

                maxNumberIndex = FindMax(i);
            }

            return _arr;
        }

        private int FindMax(int index)
        {
            int maxNumberIndex = 0;

            for (int i = 1; i < index; i++)
            {
                if (_arr[i] > _arr[maxNumberIndex])
                    maxNumberIndex = i;
            }

            return maxNumberIndex;
        }
    }
}