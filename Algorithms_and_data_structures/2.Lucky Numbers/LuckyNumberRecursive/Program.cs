using System;
using Tester;

namespace LuckyNumberRecursive
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            ITask luckyNumber = new LuckyNumber();
            Tester.Tester tester = new Tester.Tester(luckyNumber, @"G:\OTUS\Algorithms and data structures\2.Lucky Numbers\TestData\");
            tester.RunTests();
            Console.ReadKey();
        }
    }
}