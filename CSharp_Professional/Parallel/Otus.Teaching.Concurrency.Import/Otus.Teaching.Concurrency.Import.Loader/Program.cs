using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Otus.Teaching.Concurrency.Import.Core.Loaders;
using Otus.Teaching.Concurrency.Import.DataAccess.Parsers;
using Otus.Teaching.Concurrency.Import.DataAccess.Repositories;
using Otus.Teaching.Concurrency.Import.DataGenerator.Generators;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using Otus.Teaching.Concurrency.Import.Loader.Loaders;


namespace Otus.Teaching.Concurrency.Import.Loader
{
    class Program
    {
        private static string _dataFilePath = AppDomain.CurrentDomain.BaseDirectory;
        private static string _dataFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.csv");
        private static int _count = 100_000;
        private static bool _startByProcces = false;


        static void Main(string[] args)
        {
            if (!TryValidateAndParseArgs(args))
            {
                return;
            }

            if (_startByProcces)
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = Path.Combine(_dataFilePath, @"Otus.Teaching.Concurrency.Import.DataGenerator.App.exe");
                    process.StartInfo.Arguments = $"{args[0]} {args[1]}";
                    process.Start();
                    Console.WriteLine("Запущен процесс datаGenerator");
                    process.WaitForExit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine($"Loader started with process Id {Process.GetCurrentProcess().Id}...");

                GenerateCustomersDataFile();

            }

            var connectionString = "Server=localhost;Database=otusdb;Trusted_Connection=True";

            var loader = new SqlDataLoader<Customer>(new CsvParser(_dataFile).Parse(),new SqlRepository(connectionString),5);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            loader.LoadData();

            Console.WriteLine($"Добавление заняло:" + sw.ElapsedMilliseconds/1000);
            Console.Read();
        }

        static bool TryValidateAndParseArgs(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                _dataFile = Path.Combine(_dataFilePath, $"{args[0]}.csv");
            }
            else
            {
                return false;
            }

            if (args.Length > 1)
            {
                if (!int.TryParse(args[1], out _count))
                {
                    Console.WriteLine("Не удалось прочитать второй параметр!");
                    return false;
                }

            }

            if (args.Length > 2)
            {
                int proccesOrMethod;
                if (int.TryParse(args[2], out proccesOrMethod))
                {
                    if (proccesOrMethod == 1)
                        _startByProcces = true;
                }
            }

            return true;
        }

        static void GenerateCustomersDataFile()
        {

            var csvGenerator = new CsvGenerator(_dataFile, _count);
            csvGenerator.Generate();
        }
    }
}