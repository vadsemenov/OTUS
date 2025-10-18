using System;
using Tester;

namespace ArraySort
{
    public class BubbleSort2 : ITask
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
            bool isChaged = false;

            for (int i = 1; i < n; i++)
            {
                isChaged = false;

                for (int j = 0; j < _arr.Length - i; j++)
                {
                    if (_arr[j] > _arr[j + 1])
                    {
                        (_arr[j], _arr[j + 1]) = (_arr[j + 1], _arr[j]);
                        isChaged = true;
                    }
                }

                if (!isChaged)
                    break;
            }

            return _arr;
        }
    }
}