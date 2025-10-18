using System;
using System.Linq;
using Tester;

namespace Prime
{
    //Решето Эратосфена с оптимизацией памяти, используя битовую матрицу, сохраняя по 32 значения в одном int, хранить биты только для нечётных чисел.
    public class Prime4 : ITask
    {
        private static uint[] _matrix;
        private static int _length;
        private static int _index;

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

            IsPrime(n);

            return Popcnt();
        }

        public static int Popcnt()
        {
            var cnt = 0;

            for (var i = 0; i < _matrix.Length; i++)
                while (_matrix[i] > 0)
                {
                    if ((_matrix[i] & 1) == 1)
                        cnt++;
                    _matrix[i] >>= 1;
                }

            return cnt;
        }

        public static bool IsPrime(int n)
        {
            if (n <= 1)
                return false;

            if (n == 2)
                return true;

            FillBitMatrix(n);

            if (n % 2 == 0)
                return false;

            return GetBit(n);
        }

        private static void FillBitMatrix(int n)
        {
            _length = n / 2 % 32 == 0 ? n / 2 / 32 : n / 2 / 32 + 1;
            _index = n;
            _matrix = new uint[_length];

            _matrix = _matrix.Select(x => x = uint.MaxValue).ToArray(); // Set all integers as 1111 1111.....

            Eratosphene(n);
        }

        private static void Eratosphene(int n)
        {
            for (var p = 3; p * p <= n; p++)
                if (GetBit(p))
                    for (var i = p * p; i <= _index; i += p)
                        if (i % 2 != 0)
                            Set0Bit(i);

            SetEmptyBits(n);
        }

        private static void SetEmptyBits(int n)
        {
            if (_matrix.Length <= 0)
                return;

            //set end bits empty
            var lastPosition = _matrix.Length * 32 * 2;

            for (var i = n; i < lastPosition; i++)
            {
                Set0Bit(i);
            }
        }

        private static bool GetBit(int position)
        {
            var numberOfInteger = position / 2 / 32;
            var bitPosition = position / 2 % 32;

            var bit = (_matrix[numberOfInteger] >> bitPosition) % 2 != 0;

            return bit;
        }

        private static void Set0Bit(int position)
        {
            var numberOfInteger = position / 2 / 32;
            var bitPosition = position / 2 % 32;

            var bitMask = 1u << bitPosition;

            if ((_matrix[numberOfInteger] >> bitPosition) % 2 != 0)
                _matrix[numberOfInteger] ^= bitMask;
        }
    }
}