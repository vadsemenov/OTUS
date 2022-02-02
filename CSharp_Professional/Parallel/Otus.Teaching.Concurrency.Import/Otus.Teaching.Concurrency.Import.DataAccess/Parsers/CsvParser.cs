using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Otus.Teaching.Concurrency.Import.Core.Parsers;
using Otus.Teaching.Concurrency.Import.Handler.Entities;

namespace Otus.Teaching.Concurrency.Import.DataAccess.Parsers
{
    public class CsvParser
        : IDataParser<List<Customer>>
    {
        private string _fileName;
        public CsvParser(string fileName)
        {
            _fileName = fileName;
        }

        public List<Customer> Parse()
        {
            var customers = new List<Customer>();

            try
            {
                using (StreamReader sr = new StreamReader(_fileName))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var lineArray = line.Split(";");
                        if (lineArray.Length == 4)
                        {
                            Customer customer = new Customer();
                            int id;
                            if (int.TryParse(lineArray[0],out id))
                            {
                                customer.Id=id;
                                customer.FullName = lineArray[1];
                                customer.Email = lineArray[2];
                                customer.Phone = lineArray[3];
                                customers.Add(customer);
                            }

                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                customers = null;
            }
            
            return customers;
        }
    }
}