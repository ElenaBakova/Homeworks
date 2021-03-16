using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Calculator.Tests
{
    [TestFixture]
    class CalculatorTest
    {
        [TestCaseSource(nameof(Stacks))]
        [TestCase("555 20 /", ExpectedResult = 27.75)]
        [TestCase("1234 56 +", ExpectedResult = 1290)]
        [TestCase("54 798 -", ExpectedResult = -744)]
        [TestCase("56 32 *", ExpectedResult = 1792)]
        [TestCase("1 10000 /", ExpectedResult = 0.0001)]
        [TestCase("2356 67894 *", ExpectedResult = 159958264)]
        [TestCase("23456 999958264 +", ExpectedResult = 999981720)]
        [TestCase("0.1 9994527999 -", ExpectedResult = -9994527998.9)]
        [TestCase("5 3 - 6 * 9 -", ExpectedResult = 3)]
        [TestCase("5 6 + 4 7 - * 5 /", ExpectedResult = -6.6)]
        [TestCase("1 2 + 3 * 25 /", ExpectedResult = 0.36)]
        [TestCase("5 1 + 8 - 2 *", ExpectedResult = -4)]
        [TestCase("1 4 + 1 5 + 4 + /", ExpectedResult = 0.5)]
        public double MultipleExpressionsTest(string expression, IStack stack)
        {
            return Calculator.CountAnExpression(expression, stack).Item1;
        }
        
        [TestCaseSource(nameof(Stacks))]
        [TestCase("", ExpectedResult = false)]
        [TestCase("8 8 + tt", ExpectedResult = false)]
        [TestCase("2 2 + +", ExpectedResult = false)]
        [TestCase("47367 546 2 +", ExpectedResult = false)]
        [TestCase("+ 6365 376 +", ExpectedResult = false)]
        [TestCase("654 24 + 3 3 - /", ExpectedResult = false)]
        public bool IncorrectExpressionsTest(string expression, IStack stack)
        {
            return Calculator.CountAnExpression(expression, stack).Item2;
        }

        private static IEnumerable<TestCaseData> Stacks
            => new TestCaseData[]
            {
                new TestCaseData(new StackArray()),
                new TestCaseData(new StackList()),
            };
    }
}
