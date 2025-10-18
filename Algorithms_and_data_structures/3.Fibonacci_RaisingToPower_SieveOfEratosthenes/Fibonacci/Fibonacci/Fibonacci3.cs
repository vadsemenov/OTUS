using System;
using Tester;

namespace Fibonacci
{
    // Алгоритм поиска чисел Фибоначчи по формуле золотого сечения.
    public class Fibonacci3 :ITask
    {
        public string Run(string[] data)
        {
            var n = int.Parse(data[0]);
            return F(n).ToString();
        }

        public double F(int n)
        {
            var fi = (Math.Sqrt(5) + 1) / 2;

            var result = Math.Floor((Math.Pow(fi, n) / Math.Sqrt(5)) + 0.5);

            return result;
        }
    }
}