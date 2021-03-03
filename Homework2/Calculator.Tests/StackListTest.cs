using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class StackListTest
    {
        public IStack stack;

        [TestInitialize]
        public void Init()
            => stack = new StackList();

        [TestMethod]
        public void PushIntoEmptyStackTest()
            => Assert.IsTrue(StackTest.PushTest(stack));

        [TestMethod]
        public void EmptySatckIsEmptyShouldBeTrue()
            => Assert.IsTrue(StackTest.EmptySatckIsEmptyShouldBeTrue(stack));

        [TestMethod]
        public void PopAfterPushWillReturnLastPushedValue()
            => Assert.IsTrue(StackTest.PopAfterPushWillReturnLastPushedValue(stack));
        
        [TestMethod]
        public void DeletedValueShouldBeRplacedByNew()
            => Assert.IsTrue(StackTest.DeletedValueShouldBeRplacedByNew(stack));
    }
}