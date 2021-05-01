using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UniqueList.Tests
{
    [TestClass]
    public class ListTest
    {
        private List list;

        [TestInitialize]
        public void Init()
            => list = new List();

        [TestMethod]
        public void AfterAddingShouldNotBeEmpty()
        {
            list.Add(2, 0);
            Assert.IsFalse(list.Empty);
        }

        [TestMethod]
        public void ValueShouldBeReplacedByNewOne()
        {
            list.Add(2, 0);
            bool result = list.IsContain(2);
            list.ChangeElement(5, 0);
            result &= !list.IsContain(2) && list.IsContain(5);
            Assert.IsTrue(result);
        }

        private bool CheckPresent(List list, int start, int finish)
        {
            bool result = true;
            for (int i = start; i <= finish; i++)
            {
                result &= list.IsContain(i);
            }
            return result;
        }

        [TestMethod]
        public void AddToTheList()
        {
            list.Add(1, 0);
            list.Add(2, 1);
            list.Add(0, 0);
            list.Add(3, 3);
            Assert.IsTrue(CheckPresent(list, 0, 3));
        }

        [TestMethod]
        public void ListSizeShouldBeIncreasedAfterAdd()
        {
            list.Add(1, 0);
            list.Add(2, 1);
            Assert.AreEqual(list.Size, 2);
        }
        
        [TestMethod]
        public void ListSizeShouldBeDecreasedAfterDelete()
        {
            list.Add(1, 0);
            list.Add(2, 1);
            list.Add(3, 2);
            list.Delete(1);
            Assert.AreEqual(list.Size, 2);
        }
    }
}
