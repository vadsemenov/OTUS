using System.Numerics;

namespace Fibonacci
{
    //Алгоритм возведения матрицы в степень через двоичное разложение показателя степени,
    public class Matrix2D
    {
        public static Matrix2D Identity = new Matrix2D(new BigInteger[] {1, 1, 1, 0});
        public static Matrix2D Base = new Matrix2D(new BigInteger[] {1, 1, 1, 0});

        public BigInteger[] Matrix { get; set; }

        public Matrix2D(BigInteger[] matrix)
        {
            Matrix = matrix;
        }

        public Matrix2D Multiply(Matrix2D matrix)
        {
            var result = new Matrix2D(new BigInteger[this.Matrix.Length]);

            result.Matrix[0] = Matrix[0] * matrix.Matrix[0] + Matrix[1] * matrix.Matrix[2];
            result.Matrix[1] = Matrix[0] * matrix.Matrix[1] + Matrix[1] * matrix.Matrix[3];
            result.Matrix[2] = Matrix[2] * matrix.Matrix[0] + Matrix[3] * matrix.Matrix[2];
            result.Matrix[3] = Matrix[2] * matrix.Matrix[1] + Matrix[3] * matrix.Matrix[3];

            return result;
        }
    }
}