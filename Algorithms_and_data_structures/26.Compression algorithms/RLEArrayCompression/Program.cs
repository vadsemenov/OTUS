using System;
using System.Collections.Generic;

namespace RLEArrayCompress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] {4, 5, 7, 8, 9, 11};

            List<byte> arch = new List<byte>();

            foreach (var value in array)
            {
                arch.AddRange(BitConverter.GetBytes(value));
            }

            var rle = new RLE();

            var compressedBytes = rle.CompressBytes(arch.ToArray());

            var decompressedBytes = rle.DecompressBytes(compressedBytes);

            var newArrayList = new List<int>();

            var tempArray = new byte[4];

            for (int i = 0; i < decompressedBytes.Length; i += 4)
            {
                tempArray[0] = decompressedBytes[i];
                tempArray[1] = decompressedBytes[i + 1];
                tempArray[2] = decompressedBytes[i + 2];
                tempArray[3] = decompressedBytes[i + 3];

                newArrayList.Add(BitConverter.ToInt32(tempArray, 0));
            }

            var newArray = newArrayList.ToArray();

            Console.Read();
        }
    }
}