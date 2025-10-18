namespace Compression
{
    public class Node
    {
        public readonly int freq;
        public readonly Node bit0;
        public readonly Node bit1;
        public readonly byte symbol;

        public Node(byte symbol, int freq)
        {
            this.symbol = symbol;
            this.freq = freq;
            bit0 = bit1 = null;
        }

        public Node(Node bit0, Node bit1)
        {
            this.freq = bit0.freq + bit1.freq;
            this.bit0 = bit0;
            this.bit1 = bit1;
        }
    }
}