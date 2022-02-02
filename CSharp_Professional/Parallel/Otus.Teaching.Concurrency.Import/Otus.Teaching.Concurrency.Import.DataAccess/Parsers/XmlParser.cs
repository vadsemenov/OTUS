using System.Collections.Generic;
using System.IO;
using Otus.Teaching.Concurrency.Import.Core.Parsers;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using Otus.Teaching.Concurrency.Import.DataGenerator.Dto;
using System.Xml.Serialization;

namespace Otus.Teaching.Concurrency.Import.DataAccess.Parsers
{
    public class XmlParser
        : IDataParser<List<Customer>>
    {
        private string _fileName;

        public XmlParser(string fileName)
        {
            _fileName = fileName;
        }

        public List<Customer> Parse()
        {
            CustomersList customers;
            using (var fs = new FileStream(_fileName,FileMode.Open))
            {
                customers = (CustomersList) new XmlSerializer(typeof(CustomersList)).Deserialize(fs);
            }
            return customers.Customers;
        }
    }
}