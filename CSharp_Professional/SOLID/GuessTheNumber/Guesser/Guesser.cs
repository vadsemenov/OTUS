using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    //Принцип разделения интерфейса;The Interface Segregation Principle
    //Но нарушается принцип единственной ответственности
    class Guesser : IGuessable, IWritable
    {
        private INumberGenerator _numberGenerator;

        //Принцип инверсии зависимостей; The Dependency Inversion Principle
        private Logger _logger;

        public int TryCount
        {
            get { return _tryCount; }
        }

        private int _tryCount;

        //Принцип открытости/закрытости;The Open Closed Principle
        //т.е. выносим функционал генерации в классы реализующие интерфейс INumberGenerator
        public Guesser(INumberGenerator numberGenerator, Logger logger)
        {
            _numberGenerator = numberGenerator;
            _logger = logger;
        }

        public bool TryGuess(int number)
        {
            if (number == _numberGenerator.Digit)
            {
                WriteGuessResult("Число угадано!");
                return true;
            }

            if (number < _numberGenerator.Digit)
                WriteGuessResult("Число меньше загаданного!");

            if (number > _numberGenerator.Digit)
                WriteGuessResult("Число больше загаданного!");

            _tryCount++;
            return false;
        }

        public void WriteGuessResult(string message)
        {
            Console.WriteLine(message);
            _logger.AddMessege(message);
        }
    }
}