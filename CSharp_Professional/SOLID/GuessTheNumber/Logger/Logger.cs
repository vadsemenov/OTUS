using System;
using System.Collections.Generic;

namespace GuessTheNumber
{
    //Принцип подстановки Барбары Лисков;The Liskov Substitution Principle
    //Подстановка классов наследников Logger без нарушения функционала.
    public class Logger : ILogger
    {
        public virtual void AddMessege(string message)
        {
            Console.WriteLine("Message added");
        }

        public virtual List<string> GetAllLog()
        {
            List<string> log = new List<string>();
            log.Add("Get all Log");
            Console.WriteLine(log[0]);

            return log;
        }
    }
}