using System;
using Tester;

namespace ArraySort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"G:\OTUS\Algorithms and data structures\6.ArraySort\TestData\";

            ITask bubble1 = new BubbleSort1();
            var tester = new Tester.Tester(bubble1, path);
            tester.RunTests(nameof(BubbleSort1));

            ITask bubble2 = new BubbleSort2();
            var tester2 = new Tester.Tester(bubble2, path);
            tester2.RunTests(nameof(BubbleSort2));

            ITask insertion1 = new InsertionSort1();
            var tester3 = new Tester.Tester(insertion1, path);
            tester3.RunTests(nameof(InsertionSort1));

            ITask insertion2 = new InsertionSort2();
            var tester4 = new Tester.Tester(insertion2, path);
            tester4.RunTests(nameof(InsertionSort2));

            ITask insertion3 = new InsertionSort3();
            var tester5 = new Tester.Tester(insertion3, path);
            tester5.RunTests(nameof(InsertionSort3));

            ITask shell1 = new ShellSort1();
            var tester6 = new Tester.Tester(shell1, path);
            tester6.RunTests(nameof(ShellSort1));

            ITask shell2 = new ShellSort2();
            var tester7 = new Tester.Tester(shell2, path);
            tester7.RunTests(nameof(ShellSort2));

            ITask shell3 = new ShellSort3();
            var tester8 = new Tester.Tester(shell3, path);
            tester8.RunTests(nameof(ShellSort3));

            Console.Read();
        }
    }
}