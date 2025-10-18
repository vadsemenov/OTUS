using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Compression
{
    public class Huffman : ICompressor
    {
        public void CompressInFile(string sourcePath, string destinationPath)
        {
            byte[] data = File.ReadAllBytes(sourcePath);

            File.WriteAllBytes(destinationPath, CompressBytes(data));
        }

        private byte[] CompressBytes(byte[] data)
        {
            int[] freqs = CalculateFreqs(data);
            byte[] header = CreateHeader(data.Length, freqs);
            Node root = CreateHuffmanTree(freqs);

            string[] codes = CreateHuffmanCode(root);

            byte[] bits = CreateBody(data, codes);

            return header.Concat(bits).ToArray();
        }

        private byte[] CreateBody(byte[] data, string[] codes)
        {
            List<byte> bits = new List<byte>();
            byte sum = 0;
            byte bit = 1;

            foreach (var symbol in data)
            {
                foreach (var ch in codes[symbol])
                {
                    if (ch == '1')
                    {
                        sum |= bit;
                    }

                    if (bit == 128)
                    {
                        bits.Add(sum);
                        sum = 0;
                        bit = 1;
                    }
                    else
                    {
                        bit <<= 1;
                    }
                }
            }

            if (bit > 1)
            {
                bits.Add(sum);
            }

            return bits.ToArray();
        }

        private string[] CreateHuffmanCode(Node root)
        {
            string[] codes = new string[256];
            Next(root, "");
            return codes;

            void Next(Node node, string code)
            {
                if (node.bit0 == null)
                {
                    codes[node.symbol] = code;
                }
                else
                {
                    Next(node.bit0, code + "0");
                    Next(node.bit1, code + "1");
                }
            }
        }

        private Node CreateHuffmanTree(int[] freqs)
        {
            PriorityQueue<Node> pq = new PriorityQueue<Node>();

            for (int i = 0; i < 256; i++)
            {
                if (freqs[i] > 0)
                {
                    pq.Enquueue(freqs[i], new Node((byte) i, freqs[i]));
                }
            }

            while (pq.Size() > 1)
            {
                Node bit0 = pq.Dequeue();
                Node bit1 = pq.Dequeue();
                Node parent = new Node(bit0, bit1);

                pq.Enquueue(parent.freq, parent);
            }

            return pq.Dequeue();
        }

        private byte[] CreateHeader(int dataLength, int[] freqs)
        {
            var head = new List<byte>();

            //Add full file size - number of bytes 
            head.Add((byte) (dataLength & 255));
            head.Add((byte) ((dataLength >> 8) & 255));
            head.Add((byte) ((dataLength >> 16) & 255));
            head.Add((byte) ((dataLength >> 24) & 255));

            //Add for each symbol,number of symbols which amount in text > 0
            //var symbolCount =  freqs.Where(x => x > 0).Count();
            int symbolCount = 0;

            for (int i = 0; i < freqs.Length; i++)
            {
                if (freqs[i] > 0)
                    symbolCount++;
            }

            head.Add((byte) symbolCount);

            //Add dictionary: symbol number in ascii, symbol amount in text
            for (int i = 0; i < freqs.Length; i++)
            {
                if (freqs[i] > 0)
                {
                    head.Add((byte) i);
                    head.Add((byte) freqs[i]);
                }
            }

            return head.ToArray();
        }

        private int[] CalculateFreqs(byte[] data)
        {
            int[] freq = new int[256];

            foreach (var b in data)
            {
                freq[b]++;
            }

            NormalizeFreqs();

            return freq;

            void NormalizeFreqs()
            {
                long max = freq.Max();

                if (max <= 255)
                {
                    return;
                }

                for (int i = 0; i < 256; i++)
                {
                    if (freq[i] > 0)
                    {
                        freq[i] = 1 + (int)((long)freq[i]*255 / (max + 1));
                    }
                }
            }
        }

        public string DecompressFromFile(string sourcePath, string destinationPath)
        {
            if (!File.Exists(sourcePath))
            {
                return "File doesnt exist!";
            }

            byte[] arch = File.ReadAllBytes(sourcePath);

            byte[] data = DecompressBytes(arch);

            File.WriteAllBytes(destinationPath, data);
            return "Decompress done.";
        }

        private byte[] DecompressBytes(byte[] arch)
        {
            ParseHeader(arch, out int dataLength, out int startIndex, out int[] freqs);

            Node root = CreateHuffmanTree(freqs);

            byte[] data = Decompress(arch, startIndex, dataLength, root);

            return data;
        }

        private byte[] Decompress(byte[] arch, int startIndex, int dataLength, Node root)
        {
            int size = 0;

            Node currentNode = root;

            byte[] data = new byte[dataLength];

            for (int j = startIndex; j < arch.Length; j++)
            {
                for (int bit = 1; bit <= 128; bit <<= 1)
                {
                    if ((arch[j] & bit) == 0)
                    {
                        currentNode = currentNode.bit0;
                    }
                    else
                    {
                        currentNode = currentNode.bit1;
                    }

                    if (currentNode.bit0 == null)
                    {
                        if (size < dataLength)
                        {
                            data[size++] = currentNode.symbol;
                        }

                        currentNode = root;
                    }
                }
            }

            return data;
        }

        private void ParseHeader(byte[] arch, out int dataLength, out int startIndex, out int[] freqs)
        {
            dataLength = arch[0] |
                         (arch[1] << 8) |
                         (arch[2] << 16) |
                         (arch[3] << 24);

            freqs = new int[256];

            int count = arch[4];
            if (count == 0) count = 256;

            for (int i = 0; i < count; i++)
            {
                byte symbol = arch[5 + i * 2];
                freqs[symbol] = arch[5 + i * 2 + 1];
            }

            startIndex = 4 + 1 + 2 * count;
        }
    }
}