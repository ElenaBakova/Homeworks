using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class StackListTest
    {
        private IStack stack;

        [TestInitialize]
        public void Init()
        {
            stack = new StackList();
        }

        [TestMethod]
        public void PushIntoEmptyStackTest()
        {
            stack.Push(654);
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
            stack.Push(1234);
            stack.Push(99.75);
            Assert.AreEqual(99.75, stack.Pop());
        }
    }
}