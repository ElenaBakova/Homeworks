using NUnit.Framework;
using System;

namespace BTree.Tests
{
    public class BTreeTests
    {
        BTree tree;

        [SetUp]
        public void Setup()
        {
            tree = new BTree(3);
        }

        [Test]
        public void AfterInsertKeyCountShouldIncrease()
        {
            int initialCount = tree.RootKeysCount;
            tree.Insert("1", "1");
            Assert.AreEqual(initialCount, tree.RootKeysCount - 1);
        }
        
        [Test]
        public void AfterInsertKeyShouldBeInTree()
        {
            tree.Insert("1", "2");
            tree.Insert("2", "3");
            bool result = tree.IsContain("1") && tree.IsContain("2") && !tree.IsContain("3") && !tree.IsContain("4");
            tree.Insert("3", "4");
            result &= tree.IsContain("3");
            tree.Insert("4", "5");
            Assert.IsTrue(result && tree.IsContain("4"));
        }
        
        [Test]
        public void AfterInsertingSameKeyIntoLeafValueShouldBeReplaced()
        {
            tree.Insert("1", "2");
            var initialValue = tree.FindValueByKey("1");
            tree.Insert("1", "5");
            Assert.AreNotEqual(initialValue, tree.FindValueByKey("1"));
        }
    }
}