using NUnit.Framework;

namespace RLEAlgorithm.Tests
{
    /// <summary>
    /// RLE tests class
    /// </summary>
    public class RLETests
    {
        private bool AreEqual()
        {
            return true;
        }

        [TestCase("\\..\\..\\..\\testInput.txt", "\\..\\..\\..\\answers.txt")]
        public void CompressionTest(string inputPath, string answerPath)
        {
            
        }
    }
}