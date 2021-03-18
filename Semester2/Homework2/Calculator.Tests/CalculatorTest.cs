using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalculatorTest
    {
        private bool Check(string expression, double answer)
        {
            var temp = Calculator.CountAnExpression(expression, new StackArray());
            bool result = temp.Item2;
            result &= Math.Abs(temp.Item1 - answer) < 1e-5;
            return result;
        }

        [TestMethod]
        public void FirstTest()
            => Assert.IsTrue(Check("5 3 - 6 * 9 -", 3));

        [TestMethod]
        public void SecondTest()
            => Assert.IsFalse(Check("55 0 /", 0));

        [TestMethod]
        public void ThirdTest()
            => Assert.IsTrue(Check("10 1 + 4 7 - * 5 /", -6.6));
    }
}
