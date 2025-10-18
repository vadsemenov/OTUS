using BitCount;
using Tester;

namespace ChessFigures
{
    public class Knight :ITask
    {
        public string Run(string[] data)
        {
            var pos = int.Parse(data[0]);

            var mask = GetKnightBitboardMoves(pos);

            return $"{mask.Popcnt2()}\r\n{mask}";
        }

        public static ulong GetKnightBitboardMoves(int pos)
        {
            ulong K = 1UL << pos;
            ulong noA = 18229723555195321596UL;
            ulong noH = 4557430888798830399UL;
            ulong Ka = K & noA;
            ulong Kh = K & noH;

            ulong mask = (Ka << 15) | (Kh << 17) |
                         (Ka << 6) | (Kh << 10) |
                         (Ka >> 10) | (Kh >> 6) |
                         (Ka >> 17) | (Kh >> 15);

            return mask;
        }
    }
}