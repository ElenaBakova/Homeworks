using NUnit.Framework;
using System.Collections.Generic;
using static RLEAlgorithm.RLE;

namespace RLEAlgorithm.Tests
{
    /// <summary>
    /// RLE tests class
    /// </summary>
    public class RLETests
    {
        [TestCase("WWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWBWWWWWWWWWWWWWW", ExpectedResult = "9W3B24W1B14W")]
        [TestCase("ABCABCABCDDDFFFFFF", ExpectedResult = "1A1B1C1A1B1C1A1B1C3D6F")]
        public string CompressionTest(byte[] input)
            => ConvertToString(Compress(input));
    }
}