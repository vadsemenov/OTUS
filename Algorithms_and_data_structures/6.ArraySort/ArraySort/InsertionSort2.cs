using System;
using Tester;

namespace ArraySort
{
    public class InsertionSort2 : ITask
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

        private int[] Sort()
        {
            var n = _arr.Length;

            int j;
            for (int i = 1; i < n; i++)
            {
                int k = _arr[i];

                for (j = i - 1; j >= 0 && _arr[j] > k; j--)
                    _arr[j + 1] = _arr[j];

                _arr[j + 1] = k;
            }

            return _arr;
        }
    }
}