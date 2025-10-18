using System;
using System.Collections;
using Tester;

namespace Prime
{

    //Решето Эратосфена, используя битовую матрицу (BitArray класс). Не входит в домашнее задание.
    public class Prime6 :ITask
    {
        private static BitArray _data;
        private static int _length;

        public string Run(string[] data)
        {
            var n = int.Parse(data[0]);
            return CountPrimes(n).ToString();
        }

        public int CountPrimes(int n)
        {
            if (n <= 1)
                return 0;
            if (n == 2)
                return 1;
            if (n == 3)
                return 2;
            if (n == 5)
                return 3;

            FillBitsMask(n + 1);

            var count = 0;
            for (int i = 2; i < n; i++)
            {
                if (_data[i])
                    count++;
            }

            return count;
        }

        private static void FillBitsMask(int n)
        {
            _data = new BitArray(n);
            _length = _data.Length;

            _data.SetAll(true);

            for (int p = 2; p * p < n; p++)
            {
                if (_data[p])
                {
                    for (int i = p * p; i < _length; i += p)
                    {
                        _data[i] = false;
                    }
                }
            }
        }

        public static bool IsPrime(int n)
        {
            FillBitsMask(n+1);
            return _data[n];
        }
    }
}