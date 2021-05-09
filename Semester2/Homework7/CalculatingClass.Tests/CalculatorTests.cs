using Calculator;
using NUnit.Framework;

namespace CalculatingClasss.Tests
{
    /// <summary>
    /// Tests for calculating class
    /// </summary>
    public class Tests
    {
        private CalculatingClass calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new();
        }

        /// <returns>True if given symbol is operation sign</returns>
        private bool IsOperation(char symbol)
        {
            return symbol == '-' || symbol == '+' || symbol == '*' || symbol == '/';
        }

        /// <summary>
        /// Clicks buttons in given expression
        /// </summary>
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
        [TestCase("5 * 3 - 2 + 7 / 10000 =", ExpectedResult = 0.002)]
        [TestCase("2 * 2 + 6 / 0 5 =", ExpectedResult = 2)]
        [TestCase("7 - 9 / 0", ExpectedResult = -2)]
        [TestCase("7 - =", ExpectedResult = 7)]
        [TestCase("9", ExpectedResult = null)]
        [TestCase("=", ExpectedResult = 0)]
        public double? DifferentExpressionsTest(string expression)
        {
            ClickButtons(expression);
            return calculator.Value;
        }
    }
}