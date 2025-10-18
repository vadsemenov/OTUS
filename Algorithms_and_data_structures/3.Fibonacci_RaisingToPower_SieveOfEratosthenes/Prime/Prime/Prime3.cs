using System;
using Tester;

namespace Prime
{
    //Алгоритм "Решето Эратосфена" для быстрого поиска простых чисел O(N Log Log N)
    public class Prime3 : ITask
    {
        public string Run(string[] data)
        {
            var n = int.Parse(data[0]);
            return CountPrimes(n).ToString();
        }

        public int CountPrimes(int N)
        {
            bool[] divs = new bool[N + 1];
            int count = 0;
            int sqrt = (int) Math.Sqrt(N);

            for (int i = 2; i <= N; i++)
                if (!divs[i])
                {
                    count++;
                    if (i <= sqrt)
                        for (int j = i * i; j <= N; j += i)
                            divs[j] = true;
                }

            return count;
        }
    }
}