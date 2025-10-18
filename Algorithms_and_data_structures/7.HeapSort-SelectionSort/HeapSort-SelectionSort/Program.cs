using System;
using Tester;

namespace HeapSort_SelectionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"G:\OTUS\Algorithms and data structures\7.HeapSort-SelectionSort\TestData\";

            ITask selectionSort = new SelectionSort();
            var tester = new Tester.Tester(selectionSort, path);
            tester.RunTests(nameof(SelectionSort));

            ITask heapSort = new HeapSort();
            var tester2 = new Tester.Tester(heapSort, path);
            tester2.RunTests(nameof(HeapSort));

            Console.Read();
        }
    }
}
