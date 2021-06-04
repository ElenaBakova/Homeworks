using System.Collections.Generic;

namespace RLEAlgorithm
{
    /// <summary>
    /// Class for compression/decompression methods
    /// </summary>
    public class RLE
    {
        /// <summary>
        /// Pair of symbol and number of that symbol
        /// </summary>
        public struct Pair
        {
            public byte Symbol;
            public byte Count;

            public override string ToString()
                => Count.ToString() + Symbol;
        }

        /// <summary>
        /// Turns list of pair to the string
        /// </summary>
        public static string ConvertToString(List<Pair> list)
        {
            string result = "";
            foreach (var element in list)
            {
                result += element;
            }
            return result;
        }

        private const byte maxByte = 255;

        /// <summary>
        /// Compression method
        /// </summary>
        /// <param name="array">Byte array to compress</param>
        /// <returns>List - result of compression</returns>
        public static List<Pair> Compress(byte[] array)
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
                for (int j = 0; j < count / maxByte; j++)
                {
                    list.Add(new Pair() { Count = maxByte, Symbol = array[i - 1] });
                }
                list.Add(new Pair() { Count = (byte)(count % maxByte), Symbol = array[i - 1] });
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
        public static byte[] Decompress(List<Pair> list)
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
