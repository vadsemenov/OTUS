using System;
using System.Data;
using System.Data.SqlClient;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using Otus.Teaching.Concurrency.Import.Handler.Repositories;

namespace Otus.Teaching.Concurrency.Import.DataAccess.Repositories
{
    public class SqlRepository
        : ICustomerRepository
    {
        private string _connectionString;
        private SqlConnection connection;
        private object obj = new object();

        public SqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddCustomer(Customer customer, int tryNumber = 0)
        {

            try
            {
                lock (obj)
                {

                    using (connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        var queryString = $"INSERT INTO otusDb.dbo.Customers values(@par1,@par2,@par3,@par4) ";
                        var command = new SqlCommand(queryString, connection);
                        command.Parameters.AddWithValue("@par1", customer.Id);
                        command.Parameters.AddWithValue("@par2", customer.FullName);
                        command.Parameters.AddWithValue("@par3", customer.Email);
                        command.Parameters.AddWithValue("@par4", customer.Phone);


                        var r = command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(customer.Id + ex.Message);
            }
        }

        public void DeleteAllRecords()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var queryString = $"TRUNCATE table [otusDb].[dbo].[Customers]";
                var command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    var r = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    var queryString = $"SELECT * FROM otusDb.dbo.Customers WHERE Id = @par1";
                    var command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@par1", id);

                    var r = command.ExecuteReader();

                    if (r.HasRows)
                    {
                        while (r.Read())
                        {
                            customer = new Customer();
                            customer.Id = r.GetInt32(0);
                            customer.FullName = r.GetString(1);
                            customer.Email = r.GetString(2);
                            customer.Phone = r.GetString(3);
                            return customer;
                        }

                    }

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                    return null;
                }
            }

            return customer;
        }
    }
}