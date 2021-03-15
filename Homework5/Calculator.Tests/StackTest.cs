using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Calculator.Tests
{
    [TestFixture]
    public class StackTest
    {
        [TestCaseSource(nameof(Stacks))]
        public void PushTest(IStack stack)
        {
            stack.Push(1);
            Assert.IsFalse(stack.Empty);
        }

        [TestCaseSource(nameof(Stacks))]
        public void EmptyStackIsEmptyShouldBeTrue(IStack stack)
        {
            Assert.IsTrue(stack.Empty);
        }

        [TestCaseSource(nameof(Stacks))]
        public void PopAfterPushWillReturnLastPushedValue(IStack stack)
        {
            stack.Push(55);
            stack.Push(-1.23);
            Assert.IsTrue(Math.Abs(-1.23 - stack.Pop()) < 1e-5);
        }

        [TestCaseSource(nameof(Stacks))]
        public void DeletedValueShouldBeRplacedByNew(IStack stack)
        {
            stack.Push(5.2);
            stack.Pop();
            stack.Push(9.633);
            Assert.IsTrue(Math.Abs(9.633 - stack.Pop()) < 1e-5);
        }

        private static IEnumerable<TestCaseData> Stacks
        => new TestCaseData[]
        {
        new TestCaseData(new StackArray()),
        new TestCaseData(new StackList()),
        };
    }
}
