using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    abstract class Figure
    {
      public List<Point> figureList;
      protected IDrawInterface draw;
      
      protected Figure()
      {
          draw = new ConsoleDraw();
      }

      public void Draw()
      {
          foreach (var point in figureList)
          {
              point.Draw(draw);
          }
      }

      public void Clear()
      {
          foreach (var point in figureList)
          {
              point.Clear(draw);
          }
      }


      public bool IsHit(Figure figure)
      {
          foreach (var p in figureList)
          {
              if (figure.IsHit(p)) return true;
          }
          return false;
      }

      public bool IsHit(Point point)
      {
          foreach (var p in figureList)
          {
              if (p.IsHit(point)) return true;
          }

          return false;
      }
    }
}
