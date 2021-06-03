using NUnit.Framework;
using System;

namespace BTree.Tests
{
    public class BTreeTests
    {
        private BTree tree;

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
            Assert.IsTrue(tree.IsContain("1") && tree.IsContain("2") && !tree.IsContain("3") && !tree.IsContain("4"));
            tree.Insert("3", "4");
            Assert.IsTrue(tree.IsContain("3"));
            tree.Insert("4", "5");
            Assert.IsTrue(tree.IsContain("4"));
        }
        
        [Test]
        public void AfterInsertingSameKeyIntoLeafValueShouldBeReplaced()
        {
            tree.Insert("1", "2");
            var initialValue = tree.FindValueByKey("1");
            tree.Insert("1", "5");
            Assert.AreNotEqual(initialValue, tree.FindValueByKey("1"));
        }
        
        [Test]
        public void ValueShouldBeReplaced()
        {
            tree.Insert("1", "2");
            tree.Insert("3", "4");
            tree.Insert("0", "11");
            tree.Insert("5", "6");
            tree.Insert("8", "9");
            tree.Insert("6", "7");
            tree.Insert("2", "7");
            tree.Insert("4", "4");
            tree.Insert("01", "6");
            tree.Insert("7", "31");
            tree.Insert("07", "7");
            tree.Insert("9", "1");
            var initialValue = tree.FindValueByKey("9");
            tree.ReplaceValue("9", "6");
            Assert.AreNotEqual(initialValue, tree.FindValueByKey("9"));
            Assert.AreEqual("6", tree.FindValueByKey("9"));
        }

        [Test]
        public void AfterDeletionValueShouldNotBeFound()
        {
            tree.Insert("1", "2");
            tree.Insert("3", "4");
            tree.Insert("0", "11");
            tree.Insert("5", "6");
            tree.Insert("8", "9");
            tree.Insert("6", "7");
            tree.Insert("2", "7");
            tree.Insert("4", "4");
            tree.Insert("01", "6");
            tree.Insert("7", "31");
            tree.Insert("07", "7");
            tree.Insert("9", "1");
            Assert.IsTrue(tree.IsContain("6"));
            tree.RemoveKey("6");
            Assert.IsFalse(tree.IsContain("6"));
        }

        [Test]
        public void AfterDeletingNonExistantKeyExceptionShouldBeThrown()
        {
            tree.Insert("1", "2");
            tree.Insert("3", "4");
            tree.Insert("0", "11");
            tree.Insert("5", "6");
            tree.Insert("8", "9");
            Assert.Throws<ArgumentOutOfRangeException>(() => tree.RemoveKey("07"));
        }
    }
}