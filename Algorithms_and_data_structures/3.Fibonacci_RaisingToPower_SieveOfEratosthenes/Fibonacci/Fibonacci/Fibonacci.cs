using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Tester;

namespace Fibonacci
{
    //Рекурсивный O(2^N) алгоритм поиска чисел Фибоначчи.
    public class Fibonacci : ITask
    {
        public string Run(string[] data)
        {
            var n = int.Parse(data[0]);
            return F(n).ToString();
        }

        public BigInteger F(BigInteger n)
        {
            if(n == 0)
                return 0;
            if (n <= 1)
                return 1;

            return F(n - 1) + F(n - 2);
        }
    }
}