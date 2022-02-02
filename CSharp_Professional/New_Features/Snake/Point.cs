using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    partial class Point
    {
        private int _x;
        private int _y;
        private char _pointMark;

        public int X { get { return _x; } }
        public int Y { get { return _y; } }


        public Point(int x, int y)
        {
            _x = x;
            _y = y;
            _pointMark = '*';
        }

        public Point(int x, int y, char pointMark)
        {
            _x = x;
            _y = y;
            _pointMark = pointMark;
        }

        public Point(Point point)
        {
            _x = point._x;
            _y = point._y;
            _pointMark = point._pointMark;
        }
        
        public partial void Move(int dist, Direction direction);
        public partial bool IsHit(Point point);
        public partial void Draw(IDrawInterface draw);
        public partial void Clear(IDrawInterface draw);


    }

    //NEW FEATURE
    partial class Point
    {
        public partial void Move(int dist, Direction direction)
        {
            if (direction == Direction.Up) _y -= dist;
            if (direction == Direction.Down) _y += dist;
            if (direction == Direction.Right) _x += dist;
            if (direction == Direction.Left) _x -= dist;
        }

        public partial bool IsHit(Point point)
        {
            return _x == point._x && _y == point._y;
        }

        public partial void Draw(IDrawInterface draw)
        {
            draw.Draw(_x,_y,_pointMark);
            //Console.SetCursorPosition(_x, _y);
            //Console.Write(_pointMark);
        }

        public partial void Clear(IDrawInterface draw)
        {
           draw.Clear(_x,_y);
            //_pointMark = ' ';
            //this.Draw();
        }

        public override string ToString()
        {
            return "x=" + _x + ";" + "y=" + _y + ";" + "PointMark=" + _pointMark;
        }
    }

}
