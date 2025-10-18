using System;
using System.Globalization;
using Tester;

namespace RisingToPower
{
    //Итеративный O(N) алгоритм возведения числа в степень.
    public class Power : ITask
    {
        public string Run(string[] data)
        {
            var number = Double.Parse(data[0]);
            var power = Double.Parse(data[1]);

            var result = Math.Round(RisingPower(number, power),11).ToString();

            return result;
        }

        public double RisingPower(double number, double power)
        {
            double result = 1;

            for (int i = 0; i < power; i++)
                result *= number;

            return result;
        }
    }
}
