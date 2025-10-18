using Tester;

namespace Prime
{
    //Алгоритм поиска количества простых чисел через перебор делителей, O(N^2)
    public class Prime : ITask
    {
        public string Run(string[] data)
        {
            var n = int.Parse(data[0]);
            return CountPrimes(n).ToString();
        }

        public int CountPrimes(int n)
        {
            var count = 0;

            if (n <= 1)
                return count;

            for (int i = 2; i <= n; i++)
            {
                if (IsPrime(i))
                    count++;
            }

            return count;
        }

        public static bool IsPrime(int n)
        {
            int count = 0;

            for (int i = 1; i <= n; i++)
            {
                if (count > 2)
                    return false;

                if (n % i == 0) count++;
            }

            return count == 2;
        }
    }
}