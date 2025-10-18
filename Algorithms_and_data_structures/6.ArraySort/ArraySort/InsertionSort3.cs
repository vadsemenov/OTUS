using System;
using Tester;

namespace ArraySort
{
    public class InsertionSort3 : ITask
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
                int p = BinarySearch(k, 0, i - 1);

                for (j = i - 1; j >= p; j--)
                    _arr[j + 1] = _arr[j];

                _arr[j + 1] = k;
            }

            return _arr;
        }

        private int BinarySearch(int key, int low, int high)
        {
            if (high <= low)
                if (key > _arr[low])
                    return low + 1;
                else
                    return low;

            int mid = (low + high) / 2;

            if (key == _arr[mid])
                return mid + 1;

            if (key > _arr[mid])
                return BinarySearch(key, mid + 1, high);
            else
                return BinarySearch(key, low, mid - 1);
        }
    }
}