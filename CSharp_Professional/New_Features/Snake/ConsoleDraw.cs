using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class ConsoleDraw : IDrawInterface
    {
        public void Draw(int x, int y, char marker)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(marker);
        }

        public void Clear(int x, int y)
        {
            Draw(x,y,' ');
        }
    }
}
