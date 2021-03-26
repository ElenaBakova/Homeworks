using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapFilterFold.Tests
{
    [TestClass]
    public class FunctionsTests
    {
        private bool CheckEquality<T>(List<T> first, List<T> second)
        {
            bool result = true;
            for (int i = 0; i < first.Count; i++)
            {
                result &= Equals(first[i], second[i]);
            }
            return result;
        }

        [TestMethod]
        public void MapIntTest()
        {
            var list = MapFilterFold.Map(new List<int>() { 1, 2, 3 }, x => x * 2);
            var answerList = new List<int>() { 2, 4, 6 };
            Assert.IsTrue(CheckEquality(list, answerList));
        }
        
        [TestMethod]
        public void MapStringTest()
        {
            var list = MapFilterFold.Map(new List<string>() { "abc", "bw", "ph" }, x => x + "d");
            var answerList = new List<string>() { "abcd", "bwd", "phd" };
            Assert.IsTrue(CheckEquality(list, answerList));
        }
        
        [TestMethod]
        public void FilterIntTest()
        {
            var list = MapFilterFold.Filter(new List<int>() { 3, 1, 4, 1, 5 }, x => x % 2 == 1);
            var answerList = new List<int>() { 3, 1, 1, 5 };
            Assert.IsTrue(CheckEquality(list, answerList));
        }
        
        [TestMethod]
        public void FilterStringTest()
        {
            var list = MapFilterFold.Filter(new List<string>() { "Queue", "List", "Map", "Set" }, x => x.Length > 3);
            var answerList = new List<string>() { "Queue", "List" };
            Assert.IsTrue(CheckEquality(list, answerList));
        }
        
        [TestMethod]
        public void FoldTest()
        {
            int answer = MapFilterFold.Fold(new List<int>() { 1, 3, 8, 21, 55 }, 1, (x, y) => x + y);
            Assert.AreEqual(89, answer);
        }
    }
}
