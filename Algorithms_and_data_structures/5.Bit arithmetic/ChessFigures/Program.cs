using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester;

// https://gekomad.github.io/Cinnamon/BitboardCalculator/
namespace ChessFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path;

            path = @"G:\OTUS\Algorithms and data structures\5.Bit arithmetic\BitArithmetic\TestData\1.Bitboard-King";
            RunTests(path, new King());

            path = @"G:\OTUS\Algorithms and data structures\5.Bit arithmetic\BitArithmetic\TestData\2.Bitboard-Knight";
            RunTests(path, new Knight());

            path = @"G:\OTUS\Algorithms and data structures\5.Bit arithmetic\BitArithmetic\TestData\3.Bitboard-Rook";
            RunTests(path, new Rook());

            path = @"G:\OTUS\Algorithms and data structures\5.Bit arithmetic\BitArithmetic\TestData\4.Bitboard-Bishop";
            RunTests(path, new Bishop());

            path = @"G:\OTUS\Algorithms and data structures\5.Bit arithmetic\BitArithmetic\TestData\5.Bitboard-Queen";
            RunTests(path, new Queen());

            Console.Read();
        }

        public static void RunTests(string path, ITask task)
        {
            var tester = new Tester.Tester(task, path);
            tester.RunTests();
        }


    }
}