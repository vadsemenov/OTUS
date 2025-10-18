using BitCount;
using Tester;

namespace ChessFigures
{
    public class Queen : ITask
    {
        public string Run(string[] data)
        {
            var pos = int.Parse(data[0]);

            var mask = GetQueenBitboardMoves(pos);

            return $"{mask.Popcnt2()}\r\n{mask}";
        }

        public static ulong GetQueenBitboardMoves(int pos)
        {
            ulong mask = Rook.GetRookBitboardMoves(pos) ^ Bishop.GetBishopBitboardMoves(pos);

            return mask;
        }
    }
}