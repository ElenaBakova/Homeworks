using NUnit.Framework;

namespace UniqueList.Tests
{
    [TestFixture]
    public class UniqueListTest
    {
        UniqueList list;

        [SetUp]
        public void Init()
            => list = new UniqueList();

        [Test]
        public void AddingSameValueTest()
        {
            list.Add(5, 0);
            Assert.Throws<AddingExistingValueException>(() => list.Add(5, 1));
        }

        [Test]
        public void DeletingNonexistentElement()
        {
            list.Add(5, 0);
            list.Add(3, 1);
            Assert.Throws<DeletingNonPresentElementException>(() => list.Delete(3));
        }
    }
}
