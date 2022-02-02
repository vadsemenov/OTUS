
//NEW FEATURE
//Console.WriteLine("Игра Змейка версия 1.0");

using System;
using System.Runtime.CompilerServices;

namespace Snake
{
    class Program
    {
        //NEW FEATURE
        [ModuleInitializer]
        public static void Initializer()
        {
            Console.WriteLine("Игра Змейка версия 1.0");
        }

        static void Main(string[] args)
        {
            GameSnake.Start();
        }
    }
}
