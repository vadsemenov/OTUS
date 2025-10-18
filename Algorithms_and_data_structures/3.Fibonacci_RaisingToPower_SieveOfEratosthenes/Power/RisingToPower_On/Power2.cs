using System;
using Tester;

namespace RisingToPower
{
    //Алгоритм возведения в степень через домножение O(N/2+LogN) = O(N)
    public class Power2 : ITask
    {
        private double _number;
        private long _power;

        public string Run(string[] data)
        {
            _number = Convert.ToDouble(data[0]);
            _power = Convert.ToInt64(data[1]);

            var res = Math.Round(RisingPower(_number, _power), 11);

            return res.ToString();
        }

        public double RisingPower(double number, long power)
        {
            _number = number;
            _power = power;

            if (_power == 0)
                return 1;

            var tempNumber = _number;
            int tempPow = 1;

            for (; tempPow <= _power / 2; tempPow *= 2)
            {
                _number *= _number;
            }

            for (; tempPow < _power; tempPow++)
            {
                _number *= tempNumber;

            }

            return _number;
        }
    }
}