using System;
using BitCount;
using Tester;

namespace ChessFigures 
{
    public class King : ITask
    {
        public string Run(string[] data)
        {
            var pos = int.Parse(data[0]);

            var mask = GetKingBitboardMoves(pos);

            return $"{mask.Popcnt2()}\r\n{mask}";
        }

        public static ulong GetKingBitboardMoves(int pos)
        {
            ulong K = 1UL << pos;
            ulong noA = 18374403900871474942UL;
            ulong noH = 9187201950435737471UL;
            ulong Ka = K & noA;
            ulong Kh = K & noH;

            ulong mask = (Ka << 7) | (K << 8) | (Kh << 9) |
                         (Ka >> 1) | (Kh << 1) |
                         (Ka >> 9) | (K >> 8) | (Kh >> 7);
            return mask;
        }
    }
}