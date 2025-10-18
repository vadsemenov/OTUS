using System;
using System.IO;

namespace Tester
{
    public class Tester
    {
        private ITask task;
        private string path;

        public Tester(ITask task, string path )
        {
            this.task = task;
            this.path = path;
        }

        public void RunTests()
        {
            int nr = 0;

            while (true)
            {
                string inFile = $"{path}test.{nr}.in";
                string outFile = $"{path}test.{nr}.out";

                if(!File.Exists(inFile)||!File.Exists(outFile))
                    break;

                Console.WriteLine($"Test #{nr}: " + RunTest(inFile, outFile));
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