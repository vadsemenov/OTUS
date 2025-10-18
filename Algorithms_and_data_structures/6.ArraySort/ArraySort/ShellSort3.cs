using System;
using System.Collections.Generic;
using System.Linq;
using Tester;

namespace ArraySort
{
    public class ShellSort3 : ITask
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

            var gaps = GetKnuthGaps();

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

        private int[] GetKnuthGaps()
        {
            List<int> gaps = new List<int>();

            var limit = _arr.Length / 3;

            for (int i = 1; i < _arr.Length; i++)
            {
                var result = (int) (Math.Pow(3, i) - 1) / 2;

                if (result > limit)
                {
                    break;
                }

                gaps.Add(result);
            }

            gaps.Reverse();

            return gaps.ToArray();
        }
    }
}