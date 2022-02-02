using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        private Direction snakeDirection;

        public Snake(Point tail, int lenght, Direction snakeDirection)
        {
            figureList = new List<Point>();
            this.snakeDirection = snakeDirection;

            for (int i = 0; i < lenght; i++)
            {
                Point p = new Point(tail);
                p.Move(i, snakeDirection);
                figureList.Add(p);
            }
            Draw();
        }


        public void Move()
        {
            Point tail = figureList.First();
            figureList.Remove(tail);
            Point head = NextPoint();
            figureList.Add(head);

            tail.Clear(draw);
            head.Draw(draw);
        }

        public Point NextPoint()
        {
            Point head = figureList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, snakeDirection);
            return nextPoint;
        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow && snakeDirection != Direction.Down) snakeDirection = Direction.Up;
            if (key == ConsoleKey.DownArrow && snakeDirection != Direction.Up) snakeDirection = Direction.Down;
            if (key == ConsoleKey.LeftArrow && snakeDirection != Direction.Right) snakeDirection = Direction.Left;
            if (key == ConsoleKey.RightArrow && snakeDirection != Direction.Left) snakeDirection = Direction.Right;
        }


        public bool IsHitTail()
        {
            Point head = figureList.Last();
            foreach (var point in figureList)
            {
                if (head != point)
                {
                    if (head.IsHit(point)) return true;
                }
            }
            return false;
        }
    }
}
