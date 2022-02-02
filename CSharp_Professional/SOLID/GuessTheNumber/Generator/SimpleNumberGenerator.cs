using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    //Принцип единственной ответственности 
    //The Single Responsibility Principle
    //SimpleNumberGeneratorCheck - вынесено в отдельный класс
    class SimpleNumberGenerator : INumberGenerator
    {
        public int Digit { get; set; }
        private int _maxDigit;
        private Random rnd;

        public SimpleNumberGenerator(int maxDigit)
        {
            rnd = new Random();
            this._maxDigit = maxDigit;
            GenerateDigit(_maxDigit);
        }

        public bool GenerateDigit(int maxDigit)
        {
            Digit = 0;
            while (!SimpleNumberGeneratorCheck.CheckNumber(Digit))
            {
                Digit = rnd.Next(0, maxDigit + 1);
            }

            return true;
        }
    }
}