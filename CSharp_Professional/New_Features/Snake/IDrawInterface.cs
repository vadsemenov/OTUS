using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    interface IDrawInterface
    {
        public void Draw(int x, int y, char marker);

        public void Clear(int x, int y);
    }
}
