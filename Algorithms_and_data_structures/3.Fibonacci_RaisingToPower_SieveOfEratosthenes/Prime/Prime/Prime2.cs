using System;
using Tester;

namespace Prime
{
    //Алгоритм поиска простых чисел с оптимизациями поиска и делением только на простые числа, O(N * Sqrt(N) / Ln (N))
    public class Prime2 : ITask
    {
        public string Run(string[] data)
        {
            var n = int.Parse(data[0]);
            return CountPrimes(n).ToString();
        }

        private static long[] primes;
        private long count;

        public long CountPrimes(long N)
        {
            if (N <= 1)
                return 0;
            if (N == 2)
                return 1;

            int count = 0;
            primes = new long[(N / 2)+1];

            primes[count++] = 2;
            for (int p = 3; p <= N; p++)
                if (IsPrime(p))
                    primes[count++] = p;
            return count;
        }

        public static bool IsPrime(int n)
        {
            long s = (long) Math.Sqrt(n);
            for (int i = 0; primes[i] <= s; i++)
            {
                if (n % primes[i] == 0)
                    return false;
            }

            return true;
        }

        public long CountPrimes2(long N)
        {
            int q = 1;
            for (int p = 2; p <= N; p++)
            {
                if (IsPrime2(p))
                    q++;
            }

            return q;
        }

        public bool IsPrime2(int n)
        {
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            long s = (long) Math.Sqrt(n);
            for (int i = 3; i <= s; i += 2)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }
    }
}