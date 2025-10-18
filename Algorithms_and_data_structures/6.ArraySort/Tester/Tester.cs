using System;
using System.Diagnostics;
using System.IO;

namespace Tester
{
    public class Tester
    {
        private readonly ITask _task;
        private readonly string[] _pathes;

        public Tester(ITask task, string path)
        {
            this._task = task;
            _pathes = Directory.GetDirectories(path);
        }

        public void RunTests(string sortName)
        {
            int nr = 0;

            foreach (var path in _pathes)
            {
                Console.WriteLine(path);

                while (nr <= 5)
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();

                    string inFile = $"{path}\\test.{nr}.in";
                    string outFile = $"{path}\\test.{nr}.out";

                    if (!File.Exists(inFile) || !File.Exists(outFile))
                        break;

                    Console.WriteLine("---------" + sortName + "-------------");
                    Console.WriteLine($"Test #{nr}: " + RunTest(inFile, outFile));

                    stopWatch.Stop();
                    Console.WriteLine($"Test time: {stopWatch.ElapsedMilliseconds}");
                    nr++;
                }

                nr = 0;
            }
        }

        private bool RunTest(string inFile, string outFile)
        {
            try
            {
                string[] data = File.ReadAllLines(inFile);
                string expect = File.ReadAllText(outFile).Trim();
                string actual = _task.Run(data).Trim();

                // Console.WriteLine($"Expect - {expect}. Actual - {actual}.");
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