using NUnit.Framework;
using System.Collections.Generic;

namespace BubbleSort.Tests
{
    public class Tests
    {
        private bool CheckEquality<TValue>(List<TValue> first, List<TValue> second)
        {
            if (first.Count != second.Count)
            {
                return false;
            }
            bool result = true;
            for (int i = 0; i < first.Count; i++)
            {
                result &= Equals(first[i], second[i]);
            }
            return result;
        }

        [Test]
        public void IntTest()
        {
            var list = new List<int> { 1, 5, 2, 9 };
            var answerList = new List<int> { 9, 5, 2, 1 };
            BubbleSort.Sorting(list, (x, y) => x < y);
            Assert.IsTrue(CheckEquality(list, answerList));
        }
        
        [Test]
        public void IntEvenTest()
        {
            var list = new List<int> { 2, 1, 4, 8, 5, 7 };
            var answerList = new List<int> { 1, 5, 7, 8, 4, 2 };
            BubbleSort.Sorting(list, (x, y) => x % 2 == 0);
            Assert.IsTrue(CheckEquality(list, answerList));
        }
        
        [Test]
        public void StringTest()
        {
            var list = new List<string> { "abc", "aba", "cdab", "dad" };
            var answerList = new List<string> { "aba", "cdab", "abc", "dad" };
            BubbleSort.Sorting(list, (x, y) => x[x.Length - 1] > y[y.Length - 1]);
            Assert.IsTrue(CheckEquality(list, answerList));
        }
    }
}