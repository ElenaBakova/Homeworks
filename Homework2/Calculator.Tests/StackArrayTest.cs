using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class StackArrayTest
    {
        private IStack stack;

        [TestInitialize]
        public void Init()
        {
            stack = new StackArray();
        }

        [TestMethod]
        public void PushIntoEmptyStackTest()
        {
            stack.Push(1);
            Assert.IsTrue(!stack.IsEmpty());
        }

        [TestMethod]
        public void EmptySatckIsEmptyShouldBeTrue()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void PopAfterPushWillReturnLastPushedValue()
        {
            stack.Push(55);
            stack.Push(-1.23);
            Assert.AreEqual(-1.23, stack.Pop());
        }

        [TestMethod]
        public void DeletedValueShouldBeRplacedByNew()
        {
            stack.Push(5.2);
            stack.Pop();
            stack.Push(9.633);
            Assert.AreEqual(9.633, stack.Pop());
        }
    }
}
