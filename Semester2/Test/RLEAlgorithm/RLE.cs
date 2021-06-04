using System.Collections.Generic;

namespace RLEAlgorithm
{
    /// <summary>
    /// Class for compression/decompression methods
    /// </summary>
    public class RLE
    {
        /// <summary>
        /// Pair of symbol and number of that symbols
        /// </summary>
        public struct Pair
        {
            public byte Symbol;
            public int Count;
        }

        /// <summary>
        /// Compression method
        /// </summary>
        /// <param name="array">Byte array to compress</param>
        /// <returns>List - result of compression</returns>
        public List<Pair> Compress(byte[] array)
        {
            var list = new List<Pair>();
            for (int i = 1; i < array.Length; )
            {
                int count = 1;
                while (array[i] == array[i - 1] && i < array.Length)
                {
                    i++;
                    count++;
                }
                list.Add(new Pair() { Count = count, Symbol = array[i - 1] });
                i++;
            }
            if (array[array.Length - 1] != array[array.Length - 2])
            {
                list.Add(new Pair() { Count = 1, Symbol = array[array.Length - 1] });
            }
            return list;
        }

        /// <summary>
        /// Decompression method
        /// </summary>
        /// <param name="list">List to decompress</param>
        /// <returns>Byte array - result of decompression</returns>
        public byte[] Decompress(List<Pair> list)
        {
            var array = new byte[1000];
            int currentIndex = 0;
            foreach (var element in list)
            {
                for (int i = element.Count; i > 0; i--)
                {
                    array[currentIndex] = element.Symbol;
                    currentIndex++;
                }
            }
            return array;
        }
    }
}
