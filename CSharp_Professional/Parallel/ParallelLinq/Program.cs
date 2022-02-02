using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelLinq
{
    class Program
    {
        private static int[] array;
        private static List<int> list;

        static void  Main(string[] args)
        {
          WriteTime(100_000);
          WriteTime(1_000_000);
          WriteTime(10_000_000);

        }

        private static void WriteTime(int numberOfInt)
        {
            Stopwatch sw = new Stopwatch();

            array = InitializeArray(numberOfInt);
            list = InitializeList(numberOfInt);
            Console.WriteLine($"----Number of elements:{numberOfInt}-----");


            //--------- Array without Concurrent--------
            sw.Start();
            ArraySum(array);
            // ListSum(list);
            Console.WriteLine("Array without Concurrent: " + sw.ElapsedMilliseconds); 
            sw.Stop();

            //---------- List with Threads--------------

            sw.Start();
            TreadSum(4);
            Console.WriteLine("Concurrent Thread: " + sw.ElapsedMilliseconds);
            sw.Stop();


            //---------- Parallel Linq 
            sw.Reset();
            sw.Start();

            ParallelLinq(list);
            Console.WriteLine("Parallel Linq: " + sw.ElapsedMilliseconds);
            sw.Stop();

            Console.WriteLine("------------");
        }


        static int[] InitializeArray(int intMax)
        {
            int[] array = new int[intMax];

            
            for (int i = 0; i < intMax; i++)
            {
                array[i]= 5;
            }

            return array;
        }


        private static List<int> InitializeList(int intMax)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < intMax; i++)
            {
                list.Add(5);
            }

            return list;
        }

        static int ArraySum(int[] array)
        {
            int sum = 0;

            foreach (var var in array)
            {
                sum += var;
            }

            return sum;
        }


        static IEnumerable<IEnumerable<int>> GetChunks(int nChunks)
        {
            var totalLength = array.Count();
            var chunkLength = (int) Math.Ceiling(totalLength / (double) nChunks);
            var parts = Enumerable.Range(0, nChunks)
                .Select(i => array.Skip(i * chunkLength).Take(chunkLength));
            return parts;
        }

        static int TreadSum(int nChunks)
        {
            var chanks = GetChunks(nChunks);
            var tasks = new Task<int>[nChunks];

            int i = 0;
            foreach (var chank in chanks)
            {
                tasks[i] = Task.Run(() => chank.Sum());
                i++;
            }

            Task.WaitAll(tasks);
            return tasks.Sum(t=>t.Result);
        }


        static int ParallelLinq(List<int> list)
        {
           return list.AsParallel().Sum();
        }

    }
}
