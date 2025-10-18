using System;
using System.Diagnostics;
using System.IO;

namespace Tester
{
    public class Tester
    {
        private ITask task;
        private string path;

        public Tester(ITask task, string path)
        {
            this.task = task;
            this.path = path;
        }

        public void RunTests()
        {
            int nr = 0;

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine("================================================================================");
            Console.WriteLine(task.GetType());

            while (true)
            {
                stopWatch.Restart();
                string inFile = Path.Combine(path, "test." + nr + ".in"); //${path}test.{nr}.in";
                string outFile = Path.Combine(path, "test." + nr + ".out"); //$"{path}test.{nr}.out";

                if (!File.Exists(inFile) || !File.Exists(outFile))
                    break;

                Console.WriteLine("------------------------");
                Console.WriteLine($"Test #{nr}: " + RunTest(inFile, outFile));
                stopWatch.Stop();
                Console.WriteLine($"Test time: {stopWatch.ElapsedMilliseconds}");
                nr++;
            }
        }

        private bool RunTest(string inFile, string outFile)
        {
            try
            {
                string[] data = File.ReadAllLines(inFile);
                string expect = File.ReadAllText(outFile).Trim();
                string actual = task.Run(data).Trim();

                Console.WriteLine($"Expect - {expect}. Actual - {actual}.");
                return expect == actual;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}