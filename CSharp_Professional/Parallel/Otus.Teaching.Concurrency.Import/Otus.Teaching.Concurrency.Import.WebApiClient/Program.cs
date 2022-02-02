using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System.Net.Http.Headers;
using Otus.Teaching.Concurrency.Import.DataGenerator.Generators;

namespace Otus.Teaching.Concurrency.Import.WebApiClient
{

    public class Program
    {
        public static async Task Main(string[] args)
        {
            bool IsQuit = false;

            do
            {
                Console.WriteLine("-----------------Меню-----------------------");
                Console.WriteLine("1.Прочитать пользователя по Id - введите 1");
                Console.WriteLine("2.Добавить случайного пользователя - введите 2");
                Console.WriteLine("3.Очистить экран - введите 3");
                Console.WriteLine("4.Выход из приложения - введите 4");

                int.TryParse(Console.ReadLine(), out int answer);

                switch (answer)
                {
                    case 1:
                        ReadCustomerByID();
                        break;
                    case 2:
                        SendRandomCustomer();
                        break;
                    case 3:
                        Console.Clear();
                        break;
                    case 4:
                        IsQuit = true;
                        break;
                    default:
                        break;
                }

            } while (!IsQuit);
        }

        public static void ReadCustomerByID()
        {
            Console.WriteLine("Введите Id пользователя:");
            int.TryParse(Console.ReadLine(), out int id);

            Customer customer = GetCustomer(id).Result;
            if (customer == null)
            {
                Console.WriteLine("Не удалось получить пользователя или он не существует!");
            }
            else
            {
                Console.WriteLine(customer.ToString());
            }
        }

        public static void SendRandomCustomer()
        {
            var randCust = RandomCustomerGenerator.GenerateOneCustomer();
            if (PostCustomer(randCust).Result)
            {
                Console.WriteLine("Случайный пользователь добавлен: " + randCust.ToString());
            }
            else
            {
                Console.WriteLine("Не удалось добавить случайного пользователя!(Возможно пользователь существует.)");
            }
        }

        public static async Task<Customer> GetCustomer(int id)
        {
            Customer customer = new Customer();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resp = await client.GetAsync("http://localhost:42088/customers/" + id);

                resp.EnsureSuccessStatusCode();
                if ((int)resp.StatusCode == 200)
                {
                    customer = await resp.Content.ReadFromJsonAsync<Customer>();
                    return customer;
                }

            }

            return null;
        }


        public static async Task<bool> PostCustomer(Customer customer)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    HttpResponseMessage resp = await client.PostAsJsonAsync<Customer>("http://localhost:42088/customers", customer);

                    resp.EnsureSuccessStatusCode();
                    if ((int)resp.StatusCode == 200)
                    {
                        return true;
                    }
                }
                catch (HttpRequestException exp)
                {
                    return false;
                }
            }
            return false;
        }
    }
}




