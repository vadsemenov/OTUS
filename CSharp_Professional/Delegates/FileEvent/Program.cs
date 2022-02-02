using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileEvent
{
    class Program
    {
        private static readonly CancellationTokenSource cts = new CancellationTokenSource();

        static async Task Main(string[] args)
        {
            Console.WriteLine("Files search.");
            Console.WriteLine("Press the ENTER key to cancel...\n");

            Task cancelTask = Task.Run(() =>
            {
                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    Console.WriteLine("Enter for Exit...");
                }

                Console.WriteLine("\nEnter key pressed. Program stopped.\n");
                cts.Cancel();
                cts.Dispose();
            });

            Task filesTask = Task.Run(() =>
            {
                new WalkFilesTree(new DirectoryInfo(Directory.GetCurrentDirectory()), cts.Token);
            });


            await Task.WhenAny(new[] { cancelTask, filesTask });

            Console.WriteLine("Application ending.");

            Console.ReadKey();
        }

    }
}
