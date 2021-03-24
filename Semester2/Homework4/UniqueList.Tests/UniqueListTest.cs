using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UniqueList.Tests
{
    [TestClass]
    public class UniqueListTest
    {
        UniqueList list;

        [TestInitialize]
        public void Init()
            => list = new UniqueList();

        [TestMethod]
        public void AddingSameValueTest()
        {
            list.Add(5, 0);
            Assert.ThrowsException<AddingExistingValueException>(() => list.Add(5, 1));
        }
        
        [TestMethod]
        public void DeletingNonexistentElement()
        {
            list.Add(5, 0);
            list.Add(3, 1);
            Assert.ThrowsException<DeletingNonPresentElementException>(() => list.Delete(3));
        }
    }
}
