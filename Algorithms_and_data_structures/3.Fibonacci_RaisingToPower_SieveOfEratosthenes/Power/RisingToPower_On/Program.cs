using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Tester;

namespace RisingToPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tasks = new List<ITask>();
            tasks.Add(new Power());
            tasks.Add(new Power2());
            tasks.Add(new Power3());

            RunTests(tasks);
            Console.ReadKey();
        }

        public static void RunTests(List<ITask> tasks)
        {
            var path = @"G:\OTUS\Algorithms and data structures\3.Fibonacci_RaisingToPower_SieveOfEratosthenes\Power\TestData\";
            foreach (var task in tasks)
            {
                var tester = new Tester.Tester(task, path);
                tester.RunTests();
            }
        }
    }
}