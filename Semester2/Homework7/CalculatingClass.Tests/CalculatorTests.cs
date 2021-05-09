using Calculator;
using NUnit.Framework;
using System;

namespace CalculatingClasss.Tests
{
    public class Tests
    {
        private CalculatingClass calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new();
        }

        private bool IsOperation(char symbol)
        {
            return symbol == '-' || symbol == '+' || symbol == '*' || symbol == '/';
        }

        private void ClickButtons(string expression)
        {
            for (int i = 0; i < expression.Length; i++)
            {
                if (char.IsDigit(expression[i]))
                {
                    calculator.NewNumber(expression[i].ToString());
                }
                if (IsOperation(expression[i]))
                {
                     calculator.NewOperation(expression[i].ToString());
                }
                if (expression[i] == '=')
                {
                    calculator.EqualSign();
                }
            }
        }

        [TestCase("8 / +")]
        [TestCase("2 * 2 +-")]
        public void InvalidExpressionTest(string expression)
            => Assert.Throws<MissingOperandException>(() => ClickButtons(expression));

        [TestCase("4 - 8 + 3 =", ExpectedResult = -1)]
        [TestCase("6 / 5 + 6 =", ExpectedResult = 7.2)]
        [TestCase("1 / 0 2 =", ExpectedResult = 0.5)]
        [TestCase("2 * 2 + 6 / 0 5 =", ExpectedResult = 2)]
        [TestCase("7 - 9 / 0 =", ExpectedResult = -0.2222222222222222)]
        public double DifferentExpressionsTest(string expression)
        {
            ClickButtons(expression);
            return calculator.Value ?? 0;
        }
    }
}