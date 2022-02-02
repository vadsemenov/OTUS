using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Delegates
{
    class Program 
    {
        static void Main(string[] args)
        {
            var list = new List<String>() {"1.1","2.2","3.3","4.4","5.5"};
            Func<String, float> getParameter = ConvertParametr;


            Console.WriteLine($"Максимальный элемент коллекции: {list.GetMax(getParameter)}");
            Console.ReadKey();

        }

        static float ConvertParametr(String str)
        {
            return Convert.ToSingle(str);
        }


    }
}
