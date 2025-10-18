using System;
using Tester;

namespace ArraySort
{
    public class BubbleSort1 : ITask
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

            for (int i = 1; i < n; i++)
            for (int j = 0; j < _arr.Length - i; j++)
                if (_arr[j] > _arr[j + 1])
                    Swap(j, j + 1);
            return _arr;
        }

        private void Swap(int a, int b)
        {
            var temp = _arr[a];
            _arr[a] = _arr[b];
            _arr[b] = temp;
        }
    }
}