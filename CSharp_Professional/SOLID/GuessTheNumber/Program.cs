﻿using System;

namespace GuessTheNumber
{
    class Program
    {
        //На примере реализации игры «Угадай число» продемонстрировать практическое
        //применение SOLID принципов.Программа рандомно генерирует число, пользователь 
        //должен угадать это число.При каждом вводе числа программа пишет больше или 
        //меньше отгадываемого.Кол-во попыток отгадывания и диапазон чисел должен
        //задаваться из настроек.
        //В отчёте написать, что именно сделано по каждому принципу.
        //Приложить ссылку на проект и написать, сколько времени ушло на выполнение задачи.

        //1 балла: Принцип единственной ответственности;The Single Responsibility Principle
        //2 балла: Принцип открытости/закрытости;The Open Closed Principle
        //2 балла: Принцип подстановки Барбары Лисков;The Liskov Substitution Principle
        //2 балла: Принцип разделения интерфейса;The Interface Segregation Principle
        //1 балла: Принцип инверсии зависимостей;The Dependency Inversion Principle

        static void Main(string[] args)
        {
            GuesserGame game = new GuesserGame(10, 5);
            game.RunGame();
        }
    }
}