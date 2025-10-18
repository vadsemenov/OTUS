using System.Drawing.Drawing2D;
using System.Numerics;
using Tester;

namespace Fibonacci
{
    //Алгоритм поиска чисел Фибоначчи O(LogN) через умножение матриц
    public class Fibonacci4 : ITask
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
            var res = Matrix2D.Identity;
            var baseMatrix = Matrix2D.Base;
            while (n > 1)
            {
                if ((n & 1) == 1)
                    res = res.Multiply(baseMatrix);

                baseMatrix = baseMatrix.Multiply(baseMatrix);
                n >>= 1;
            }

            res = res.Multiply(baseMatrix);
            return res.Matrix[3];
        }
    }
}