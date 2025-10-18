using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // var priorityQueue = new PriorityQueue<int>();
            //
            // priorityQueue.Enqueue(3,123);
            // priorityQueue.Enqueue(5,345);
            // priorityQueue.Enqueue(6,234);
            //
            // Console.WriteLine(priorityQueue.Dequeue());
            // Console.WriteLine(priorityQueue.Dequeue());
            // Console.WriteLine(priorityQueue.Dequeue());

            IArray<int> array1 = new SingleArray<int>();
            Console.WriteLine(string.Join(" ", ArrayTests.TestsArrayAddRemove(array1, true)));
            Console.WriteLine("===================================");

            IArray<int> array2 = new VectorArray<int>();
            Console.WriteLine(string.Join(" ", ArrayTests.TestsArrayAddRemove(array2, true)));
            Console.WriteLine("===================================");

            IArray<int> array3 = new FactorArray<int>();
            Console.WriteLine(string.Join(" ", ArrayTests.TestsArrayAddRemove(array3, true)));
            Console.WriteLine("===================================");

            IArray<int> array4 = new MatrixArray<int>();
            Console.WriteLine(string.Join(" ", ArrayTests.TestsArrayAddRemove(array4, true)));
            Console.WriteLine("===================================");

            IArray<int> array5 = new WrapedArrayList<int>();
            Console.WriteLine(string.Join(" ", ArrayTests.TestsArrayAddRemove(array5, true)));
            Console.WriteLine("===================================");

            Console.Read();
        }
    }
}