using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Knuth_Morris_Pratt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = "AABAABAAABA";
            string text = "AABAAABAABAABAAABA";

            var stateMachineTestsTimes = TestsSpeedWork(() =>
            {
                StateMachine machine = new StateMachine();
                var delta = machine.CreateDelta(pattern);
                var patternIndex = machine.Search(text, delta);
                // Console.WriteLine("StateMachine: Pattern find at index " + patternIndex);
            });

            var kmpWithPiSlowTestsTimes = TestsSpeedWork(() =>
            {
                int[] pi = new KMP().GetPiSlow(pattern);
                int index = new KMP().PrefixFind(text, pattern, pi);
                // Console.WriteLine("KMP: Pattern find at index " + index);
            });

            var kmpWithPiFastTestsTimes = TestsSpeedWork(() =>
            {
                int[] pi2 = new KMP().GetPiFast(pattern);
                int index2 = new KMP().PrefixFind(text, pattern, pi2);
                // Console.WriteLine("KMP: Pattern find at index " + index);
            });

            Console.WriteLine("Время работы конечного автомата:");
            Console.WriteLine(string.Join(" ", stateMachineTestsTimes));

            Console.WriteLine("Время работы КМП, медленный вариант Pi:");
            Console.WriteLine(string.Join(" ", kmpWithPiSlowTestsTimes));

            Console.WriteLine("Время работы КМП, быстрый вариант Pi:");
            Console.WriteLine(string.Join(" ", kmpWithPiFastTestsTimes));

            Console.Read();
        }

        private static int[] TestsSpeedWork(Action testCode)
        {
            var times = new List<int>();

            for (int i = 1000; i <= 1000000; i *= 10)
            {
                times.Add(TestSpeedWork(testCode, i));
            }

            return times.ToArray();
        }

        private static int TestSpeedWork(Action testCode, int count)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < count; i++)
            {
                testCode.Invoke();
            }

            stopWatch.Stop();

            return (int)stopWatch.ElapsedMilliseconds;
        }
    }
}

