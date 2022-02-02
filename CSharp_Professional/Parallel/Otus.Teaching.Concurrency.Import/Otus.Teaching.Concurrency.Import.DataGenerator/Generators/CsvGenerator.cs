using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Otus.Teaching.Concurrency.Import.DataGenerator.Dto;
using Otus.Teaching.Concurrency.Import.Handler.Data;
using Otus.Teaching.Concurrency.Import.Handler.Entities;

namespace Otus.Teaching.Concurrency.Import.DataGenerator.Generators
{
    public class CsvGenerator : IDataGenerator
    {
        private readonly string _fileName;
        private readonly int _dataCount;
        private static readonly string SEMICOLON = ";";

        public CsvGenerator(string fileName, int dataCount)
        {
            _fileName = fileName;
            _dataCount = dataCount;
        }

        public void Generate()
        {
            var customers = RandomCustomerGenerator.Generate(_dataCount);

            using (StreamWriter sw = new StreamWriter(_fileName))
            {
                foreach (var customer in customers)
                {
                    sw.WriteLine(customer.Id + SEMICOLON + customer.FullName
                                 + SEMICOLON + customer.Email + SEMICOLON + customer.Phone);
                }
            }
        }
    }
}