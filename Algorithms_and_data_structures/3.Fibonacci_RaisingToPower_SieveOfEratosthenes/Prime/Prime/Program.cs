using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester;

namespace Prime
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var tasks = new List<ITask>();
           tasks.Add(new Prime());
           tasks.Add(new Prime2());
           tasks.Add(new Prime3());
           tasks.Add(new Prime4());
           tasks.Add(new Prime5());
           tasks.Add(new Prime6());
           
           RunTests(tasks);
           Console.ReadKey();
        }

        public static void RunTests(List<ITask> tasks)
        {
            var path = @"G:\OTUS\Algorithms and data structures\3.Fibonacci_RaisingToPower_SieveOfEratosthenes\Prime\TestData";
            foreach (var task in tasks)
            {
                var tester = new Tester.Tester(task, path);
                tester.RunTests();
            }
        }
    }
}