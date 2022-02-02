using System;
using System.Threading;

namespace Snake
{
       public static class GameSnake
       {

           public static void Start()
        {
            Start(30,30);
        }

        public static void Start(int fieldSizeX,int fieldSizeY)
        {

            Console.CursorVisible = false;

            GameScore gameScore = new();

            Point leftUpPoint = new Point(fieldSizeX, fieldSizeY);
            Point rightDowPoint = new Point(0, 0);

            //NEW FEATURE
            Border border = new(leftUpPoint, rightDowPoint);

            Snake snake = new(new Point(10, 10), 4, Direction.Right);

            Bonus bonus = new Bonus(new Figure[] {border, snake}, fieldSizeX,fieldSizeY);

            ConsoleKeyInfo keyInfo;

            while (true)
            {
                if (!snake.IsHit(border) && !snake.IsHitTail())
                {
                    snake.Move();
                    if (snake.IsHit(bonus))
                    {
                        bonus.CreateNewBonus();
                        gameScore.Score += 1;
                    }

                }
                else
                {
                    break;
                }


                Thread.Sleep(200);


                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey();
                    snake.HandleKey(keyInfo.Key);
                }
            }

            Console.WriteLine("Игра окончена!");
            GameOver(gameScore);
        }


        private static void GameOver(GameScore gameScore)
        {   Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Game over!");
            Console.WriteLine(gameScore);
            //NEW FEATURE
            if (gameScore is {Score: > 10})
            {
                Console.WriteLine("New Highscore!!!!");
            }

            Console.ReadKey();
        }

        //NEW FEATURE
        private record GameScore
        {
            public int Score { get; set;}
        }

    }
}
