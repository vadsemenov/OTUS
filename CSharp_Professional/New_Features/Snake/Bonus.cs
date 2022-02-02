using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Bonus : Figure
    {
        private Figure[] borderAndSnake;
        private int _fieldSizeX, _fieldSizeY;


        public Bonus(Figure[] borderAndSnakeFigures, int fieldSizeX, int fieldSizeY)
        {
            borderAndSnake = borderAndSnakeFigures;
            this._fieldSizeX = fieldSizeX;
            this._fieldSizeY = fieldSizeY;
            figureList = new List<Point>();
            CreateNewBonus();

        }

        public void CreateNewBonus()
        {
            figureList.Clear();

            Point point = null;

            while (true)
            {
                point = new(new Random().Next(_fieldSizeX+1), new Random().Next(_fieldSizeY+1));
                if (FieldEmptyPoint(point))
                {
                    figureList.Add(point);
                    break;
                }
            }
            Draw();
        }


        private bool FieldEmptyPoint(Point point)
        {
            foreach (var figur in borderAndSnake)
            {
                foreach (var pt in figur.figureList)
                {
                    if (point.IsHit(pt) == true) return false;

                }
            }
            return true;
        }

    }
}
