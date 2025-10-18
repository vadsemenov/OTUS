using System.Numerics;
using Tester;

namespace Fibonacci
{
    // Итеративный O(N) алгоритм поиска чисел Фибоначчи.
    public class Fibonacci2 : ITask
    {
        public string Run(string[] data)
        {
            var n = int.Parse(data[0]);
            return F(n).ToString();
        }

        public BigInteger F(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            if (n == 2)
                return 1;

            BigInteger f_1 = 1;
            BigInteger f_2 = 1;
            BigInteger result = 0;

            for (int i = 3; i <= n; i++)
            {
                result = f_1 + f_2;
                f_2 = f_1;
                f_1 = result;
            }

            return result;
        }
    }
}