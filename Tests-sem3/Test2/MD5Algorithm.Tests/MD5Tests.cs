using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MD5Algorithm.Tests
{
    public class Tests
    {
        private static string[] testData = new[]
        {
            "../../../../Files",
            "../../../../Files/File.txt",
            "../../../../Files/File2.txt",
            "../../../../Files/Folder",
            "../../../../Files/Folder/SomeFile.txt",
        };

        private static IEnumerable<TestCaseData> Cases
            =>
                testData.SelectMany(data => new TestCaseData[]
                {
                    new TestCaseData(new SingleThreadedCounting(), data),
                    new TestCaseData(new MultiThreadedCounting(), data)
                });

        [TestCaseSource(nameof(Cases))]
        public void CheckSumShouldNotChange(ICheckSumCounting sumCounting, string path)
        {
            var firstResult = sumCounting.CountCheckSum(path);
            var secondResult = sumCounting.CountCheckSum(path);
            Assert.AreEqual(firstResult, secondResult);
        }
    }
}