using System;
using Tester;

namespace RisingToPower
{
    //Алгоритм возведения в степень через двоичное разложение показателя степени O(2LogN) = O(LogN)
    public class Power3 : ITask
    {
        public string Run(string[] data)
        {
            var number = Convert.ToDecimal(data[0]);
            var power = Convert.ToInt64(data[1]);

            var res = Math.Round(RisingPower(number, power), 11);

            return res.ToString();
        }

        public decimal RisingPower(decimal number, long power)
        {
            var n =  power;
            var d = number;
            decimal p = 1;

            while (n > 0)
            {

                if (n % 2 == 1)
                    p *= d;

                n /= 2;
                d *= d;
            }

            return p;
        }
    }
}