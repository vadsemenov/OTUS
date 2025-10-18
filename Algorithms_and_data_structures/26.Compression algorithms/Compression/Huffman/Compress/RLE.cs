using System.Collections.Generic;
using System.IO;

namespace Compression
{
    public class RLE : ICompressor
    {
        public void CompressInFile(string sourcePath, string destinationPath)
        {
            byte[] data = File.ReadAllBytes(sourcePath);

            File.WriteAllBytes(destinationPath, CompressBytes(data));
        }

        private byte[] CompressBytes(byte[] data)
        {
            var archByte = new List<byte>();

            var symbolQueue = new Queue<byte>();

            for (int i = 0; i < data.Length; i++)
            {

                if (i < data.Length - 1 && data[i] == data[i+1])
                {
                    while (i < data.Length-1 && data[i] == data[i+1])
                    {
                        if (symbolQueue.Count == 128)
                        {
                            AddRepeatSymbolCompressBytes(symbolQueue, archByte);
                            symbolQueue.Clear();
                        }

                        symbolQueue.Enqueue(data[i]);
                        i++;
                    }

                    symbolQueue.Enqueue(data[i]);

                    AddRepeatSymbolCompressBytes(symbolQueue, archByte);
                    symbolQueue.Clear();
                }
                else
                {
                    while (i < data.Length - 1 && data[i] != data[i + 1])
                    {
                        if (symbolQueue.Count == 128)
                        {
                            AddUniqueSymbolCompressBytes(symbolQueue, archByte);
                            symbolQueue.Clear();
                        }

                        symbolQueue.Enqueue(data[i]);
                        i++;
                    }

                    if (i == data.Length - 1)
                    {
                        symbolQueue.Enqueue(data[i]);
                        i++;
                    }

                    i--;

                    AddUniqueSymbolCompressBytes(symbolQueue, archByte);
                    symbolQueue.Clear();
                }

            }

            return archByte.ToArray();
        }

        private void AddRepeatSymbolCompressBytes(Queue<byte> symbolQueue, List<byte> archByte)
        {
            byte specialByte = 0b_0000_0000;
            byte repeatCount = (byte)(symbolQueue.Count - 1);
            specialByte |= repeatCount;
            
            archByte.Add(specialByte);
            archByte.Add(symbolQueue.Dequeue());
        }

        private void AddUniqueSymbolCompressBytes(Queue<byte> symbolQueue, List<byte> archByte)
        {
            byte specialByte = 0b_1000_0000;
            byte repeatCount = (byte)(symbolQueue.Count - 1);
            specialByte |= repeatCount;

            archByte.Add(specialByte);
            archByte.AddRange(symbolQueue);
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
            var data = new List<byte>();

            for (int i = 0; i < arch.Length;)
            {
                int archChunkLength = AddChunkBytes(i, arch, data);

                i += archChunkLength;
            }

            return data.ToArray();
        }

        private int AddChunkBytes(int i, byte[] arch, List<byte> data)
        {
            var specialByte = arch[i];

            if (specialByte >> 7 == 0) // Repeat symbol 
            {
                for (int j = 0; j <= specialByte; j++)
                {
                    data.Add(arch[i+1]);
                }

                return 2;
            }
            else // Unique symbols
            {
                var symbolAmount = (specialByte & 0b_0111_1111);

                for (int j = 0; j <= symbolAmount; j++)
                {
                    data.Add(arch[i+1+j]);
                }

                return (symbolAmount + 1) + 1;
            }
        }
    }
}