using System;
using BitCount;
using Tester;

namespace ChessFigures
{
    public class Bishop : ITask
    {
        public string Run(string[] data)
        {
            var pos = int.Parse(data[0]);

            var mask = GetBishopBitboardMoves(pos);

            return $"{mask.Popcnt2()}\r\n{mask}";
        }

        public static ulong GetBishopBitboardMoves(int pos)
        {
            int verticalPosition = pos / 8;
            int horizontalPosition = pos % 8;

            ulong firstDiagonal = 9241421688590303745UL; //   /
            ulong secondDiagonal = 72624976668147840UL; //    \

            int moveUpDown = horizontalPosition - verticalPosition; //        \
            int moveDownUp = verticalPosition - (7 - horizontalPosition); //  /   

            if (moveUpDown >= 0)
                firstDiagonal >>= (8 * Math.Abs(moveUpDown));
            else
                firstDiagonal <<= (8 * Math.Abs(moveUpDown));

            if (moveDownUp >= 0)
                secondDiagonal <<= (8 * Math.Abs(moveDownUp));
            else
                secondDiagonal >>= (8 * Math.Abs(moveDownUp));

            ulong mask = firstDiagonal ^ secondDiagonal;

            return mask;
        }
    }
}