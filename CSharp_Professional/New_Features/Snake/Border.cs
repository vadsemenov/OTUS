using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Border : Figure
    {
        private Point leftupPoint;
        private Point rightDownPoint;
        private char _borderMark;

        public Border(Point leftupPoint, Point rightDownPoint) : this(leftupPoint, rightDownPoint, '+')
        {
        }

        public Border(Point leftupPoint, Point rightDownPoint, char borderMark)
        {
            figureList = new List<Point>();
            this.leftupPoint = leftupPoint;
            this.rightDownPoint = rightDownPoint;
            this._borderMark = borderMark;
            FillTheFigure();
            this.Draw();
        }

        private void FillTheFigure()
        {
            for (int i = 0; i < Math.Abs(rightDownPoint.X-leftupPoint.X); i++)
            {
                figureList.Add(new Point(i,leftupPoint.Y));
                figureList.Add(new Point(i, rightDownPoint.Y));
            }
            for (int i = 0; i <Math.Abs(leftupPoint.Y- rightDownPoint.Y); i++)
            {
                figureList.Add(new Point(leftupPoint.X, i));
                figureList.Add(new Point(rightDownPoint.X, i));
            }
        }
    }
}
