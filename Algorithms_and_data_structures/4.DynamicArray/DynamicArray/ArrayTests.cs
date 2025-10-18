using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DynamicArray
{
    public class ArrayTests
    {
        public static int[] TestsArrayAddRemove(IArray<int> array, bool isAdd)
        {
            var times = new List<int>();

            var maxLimit = 100_000;


            if (isAdd)
            {
                for (int i = 1000; i <= maxLimit; i *= 10)
                {
                    times.Add(TestArrayAdd(i, array));
                }
            }
            else
            {
                for (int i = 1000; i <= maxLimit; i *= 10)
                {
                    times.Add(TestArrayRemove(i, array));
                }
            }

            return times.ToArray();
        }

        public static int TestArrayAdd(int count, IArray<int> array)
        {
            var rnd = new Random(1234);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < count; i++)
            { 
                array.Add(rnd.Next());
            }

            stopWatch.Stop();

            return (int)stopWatch.ElapsedMilliseconds;
        }

        public static int TestArrayRemove(int count, IArray<int> array)
        {

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < count; i++)
            { 
                array.Remove(0);
            }

            stopWatch.Stop();

            return (int)stopWatch.ElapsedMilliseconds;
        }
    }
}