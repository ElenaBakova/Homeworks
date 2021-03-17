using System;
using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    class CalculatorTest
    {
        [TestCase("555 20 /", 27.75, ExpectedResult = true)]
        [TestCase("1234 56 +", 1290, ExpectedResult = true)]
        [TestCase("54 798 -", -744, ExpectedResult = true)]
        [TestCase("56 32 *", 1792, ExpectedResult = true)]
        [TestCase("1 10000 /", 0.0001, ExpectedResult = true)]
        [TestCase("2356 67894 *", 159958264, ExpectedResult = true)]
        [TestCase("23456 999958264 +", 999981720, ExpectedResult = true)]
        [TestCase("1 994527999 -", -994527998, ExpectedResult = true)]
        [TestCase("5 3 - 6 * 9 -", 3, ExpectedResult = true)]
        [TestCase("5 6 + 4 7 - * 5 /", -6.6, ExpectedResult = true)]
        [TestCase("1 2 + 3 * 25 /", 0.36, ExpectedResult = true)]
        [TestCase("5 1 + 8 - 2 *", -4, ExpectedResult = true)]
        [TestCase("1 4 + 1 5 + 4 + /", 0.5, ExpectedResult = true)]
        public bool MultipleExpressionsTest(string expression, double result)
        {
            bool testResult = Math.Abs(Calculator.CountAnExpression(expression, new StackArray()).Item1 - result) < 1e-4;
            return testResult && Math.Abs(Calculator.CountAnExpression(expression, new StackList()).Item1 - result) < 1e-4;
        }

        [TestCase("8 8 + tt", ExpectedResult = false)]
        [TestCase("2 2 + +", ExpectedResult = false)]
        [TestCase("47367 546 2 +", ExpectedResult = false)]
        [TestCase("+ 6365 376 +", ExpectedResult = false)]
        [TestCase("654 24 + 3 3 - /", ExpectedResult = false)]
        public bool IncorrectExpressionsTest(string expression)
        {
            return Calculator.CountAnExpression(expression, new StackArray()).Item2 && Calculator.CountAnExpression(expression, new StackList()).Item2;
        }
    }
}
