using System;
using System.Linq;
using Tester;

namespace LuckyNumberForBigNumbers
{
    public class BigLuckyNumber : ITask
    {
        public string Run(string[] data)
        {
            var n = Convert.ToInt32(data[0]);

            return GetBigLuckyNumber(n).ToString();
        }

        public long GetBigLuckyNumber(int n)
        {
            if (n < 1)
                return 0;

            if (n == 1)
                return 10;

            int matrixRow = 10;

            long[] sums = new long[2 * 9 + 1];
            long[] previousSums = new long[10];
            for (int i = 0; i < previousSums.Length; i++)
            {
                previousSums[i] = 1;
            }

            long[,] matrix;
            
            //Цикл вычисления конечных сумм столбцов matrix
            for (int i = 2; i <= n; i++)
            {
                //Создаем матрицу-массив на каждой итерации увеличивая размерность
                matrix = new long[matrixRow, i * 9 + 1];
                sums = new long[i * 9 + 1];

                //Заполняем матрицу
                for (int j = 0; j < matrixRow; j++)
                {
                    for (int k = 0; k < previousSums.Length; k++)
                    {
                        matrix[j, j + k] = previousSums[k];
                    }
                }

                //Считаем суммы по столбцам матрицы
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix.GetLength(0); k++)
                    {
                        sums[j] += matrix[k, j];
                    }
                }

                previousSums = sums;
            }

            long[] squares = new long [sums.Length];

            //Вычисление квадратов сумм
            for (int i = 0; i < sums.Length; i++)
            {
                squares[i] = sums[i] * sums[i];
            }

            //Вычисляем сумму счастливых билетов
            return squares.Sum();
        }
    }
}