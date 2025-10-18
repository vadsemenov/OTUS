using System;
using Tester;

namespace ArraySort
{
    public class ShellSort1 : ITask
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

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    for (int j = i; j >= gap && _arr[j - gap] > _arr[j]; j -= gap)
                    {
                        (_arr[j], _arr[j - gap]) = (_arr[j - gap], _arr[j]);
                    }
                }
            }

            return _arr;
        }
    }
}