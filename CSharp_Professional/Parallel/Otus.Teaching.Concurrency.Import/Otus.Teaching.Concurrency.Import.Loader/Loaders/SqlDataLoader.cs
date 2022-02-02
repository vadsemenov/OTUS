using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Otus.Teaching.Concurrency.Import.Core.Loaders;
using Otus.Teaching.Concurrency.Import.DataAccess.Repositories;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using Otus.Teaching.Concurrency.Import.Handler.Repositories;

namespace Otus.Teaching.Concurrency.Import.Loader.Loaders
{
    class SqlDataLoader<T> :IDataLoader
    {
        private IEnumerable<T> _list;
        private ICustomerRepository _repo;
        private int _threads;

        public SqlDataLoader(IEnumerable<T> list, ICustomerRepository repo, int threads)
        {
            _list = list;
            _repo = repo;
            _threads = threads;
        }

        public void LoadData()
        {
            _repo.DeleteAllRecords();
            var areEvent = new List<AutoResetEvent>();
            var count = _list.Count() / _threads;
            ThreadPool.SetMaxThreads(_threads, _threads);

            for (int i = 0; i < _threads; i++)
            {
                var subList = _list.ToList().GetRange(i * count, count);

                var are = new AutoResetEvent(false);
                areEvent.Add(are);
                ThreadPool.QueueUserWorkItem(WriteRecordToDb, new { subList, are });

            }

            WaitHandle.WaitAll(areEvent.ToArray());
        }

        public void WriteRecordToDb(object state)
        {
            dynamic o = state;
            List<Customer> cust = (List<Customer>) o.subList;
            AutoResetEvent are = (AutoResetEvent) o.are;

            foreach (var customer in cust)
            {
                _repo.AddCustomer(customer,5);
                Console.WriteLine("Пользователь " + customer.Id);
            }

            Console.WriteLine("Поток закончен");
            are.Set();
        }

    }
}
