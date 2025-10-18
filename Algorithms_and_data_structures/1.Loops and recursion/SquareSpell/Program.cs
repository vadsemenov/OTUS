using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareSpell
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int x = 0; x < 25; x++)
            {
                for (int y = 0; y < 25; y++)
                {
                    Console.Write(x < y ? "# " : ". "); //1+
                    // Console.Write(x == y ? "# " : ". "); //2+
                    // Console.Write(x == 24 - y ? "# " : ". "); //3+
                    // Console.Write(x < 30 - y ? "# " : ". "); //4+
                    // Console.Write(y == x * 2 || y == x * 2 + 1 ? "# " : ". "); //5+
                    // Console.Write(x < 10 || y < 10 ? "# " : ". "); //6+
                    // Console.Write(x > 15 && y > 15 ? "# " : ". "); //7+
                    // Console.Write(x * y == 0 ? "# " : ". "); //8+
                    // Console.Write(x < y - 10 || x > y + 10 ? "# " : ". "); //9+
                    // Console.Write(y - 2 < 2 * x && y > x ? "# " : ". "); //10+
                    // Console.Write(x == 1 || y == 1 || x == 23 || y == 23 ? "# " : ". "); //11+
                    // Console.Write(x > 19 - y && x < 29 - y ? "# " : ". "); //13+
                    // Console.Write((x != 0 && y != 0 && x < 100 / y) || x * y == 0 ? "# " : ". "); //14+
                    // Console.Write(x < y - 10 && x > y - 21 || x > y + 10 && x < y + 21 ? "# " : ". "); //15+
                    // Console.Write(x <= y + 9 && x >= y - 9 && x > 14 - y && x < 34 - y ? "# " : ". "); //16+
                    // Console.Write(x > 8 * Math.Sin((double) y / 3) + 16 ? "# " : ". "); //17+
                    // Console.Write((x == 0 ^ y == 0) || (x == 1 || y == 1) ? "# " : ". "); //18+
                    // Console.Write(x == 0 || y == 0 || x == 24 || y == 24 ? "# " : ". "); //19+
                    // Console.Write(x % 2 == y % 2 ? "# " : ". "); //20+
                    // Console.Write(x % 3 == 0 && y % 2 == 0 ? "# " : ". "); //23+
                    // Console.Write(x == y || x == 24 - y ? "# " : ". "); //24+
                    // Console.Write(x % 6 == 0 || y % 6 == 0 ? "# " : ". "); //25+
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}