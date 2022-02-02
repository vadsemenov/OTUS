using System;

namespace GuessTheNumber
{
    public class GuesserGame
    {
        private INumberGenerator _generator;
        private Guesser _guesser;
        private Logger _logger;

        private readonly int MAXDIGIT;
        private readonly int NUMBEROFTRY;

        public GuesserGame(int maxDigit, int numberOfTry)
        {
            MAXDIGIT = maxDigit;
            NUMBEROFTRY = numberOfTry;
        }

        public void RunGame()
        {
            _generator = new SimpleNumberGenerator(MAXDIGIT);
            _logger = new ListLogger();
            _guesser = new Guesser(_generator, _logger);

            //Console.WriteLine("Загадано число " + _generator.Digit);
            int digit;
            while (NUMBEROFTRY > _guesser.TryCount)
            {
                Console.WriteLine("Введите загаданное число:");
                if (Int32.TryParse(Console.ReadLine(), out digit))
                {
                    if (_guesser.TryGuess(digit))
                    {
                        break;
                    }
                }
            }

            Console.WriteLine("Конец игры.");
        }
    }
}