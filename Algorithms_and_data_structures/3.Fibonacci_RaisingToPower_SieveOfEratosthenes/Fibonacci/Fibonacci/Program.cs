using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester;

namespace Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tasks = new List<ITask>();
            tasks.Add(new Fibonacci());
            tasks.Add(new Fibonacci2());
            tasks.Add(new Fibonacci3());
            tasks.Add(new Fibonacci4());

            RunTests(tasks);
            Console.ReadKey();
        }
        public static void RunTests(List<ITask> tasks)
        {
            var path = @"G:\OTUS\Algorithms and data structures\3.Fibonacci_RaisingToPower_SieveOfEratosthenes\Fibonacci\TestData";
            foreach (var task in tasks)
            {
                var tester = new Tester.Tester(task, path);
                tester.RunTests();
            }
        }
    }
}
