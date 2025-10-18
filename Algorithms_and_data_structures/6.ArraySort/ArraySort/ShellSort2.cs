using System;
using Tester;

namespace ArraySort
{
    public class ShellSort2 : ITask
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

            var gaps = new[] {701, 301, 132, 57, 23, 10, 4, 1}; // Ciura gap sequence

            foreach (var gap in gaps)
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