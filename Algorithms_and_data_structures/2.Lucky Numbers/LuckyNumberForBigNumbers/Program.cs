using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tester;

namespace LuckyNumberForBigNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITask luckyNumber = new BigLuckyNumber();
            Tester.Tester tester = new Tester.Tester(luckyNumber,
                @"G:\OTUS\Algorithms and data structures\2.Lucky Numbers\TestData\");
            tester.RunTests();
            Console.ReadKey();
        }
    }
}