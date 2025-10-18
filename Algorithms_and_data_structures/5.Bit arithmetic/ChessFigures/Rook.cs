using BitCount;
using Tester;

namespace ChessFigures
{
    public class Rook : ITask
    {
        public string Run(string[] data)
        {
            var pos = int.Parse(data[0]);

            var mask = GetRookBitboardMoves(pos);

            return $"{mask.Popcnt2()}\r\n{mask}";
        }

        public static ulong GetRookBitboardMoves(int pos)
        {
            ulong horizontalLine = 255UL << 8 * (pos / 8);
            ulong verticalLine = 72340172838076673UL << pos % 8;
            ulong mask = horizontalLine ^ verticalLine;

            return mask;
        }
    }
}