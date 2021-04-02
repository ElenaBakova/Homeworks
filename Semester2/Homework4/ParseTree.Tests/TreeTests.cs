using System;
using NUnit.Framework;

namespace ParseTree.Tests
{
    /// <summary>
    /// Tests for a parse tree
    /// </summary>
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var tree = new Tree();
        }

        private double CountAnExpression(string expression)
        {
            var elements = expression.Split(new char[] { ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            var tree = new Tree();
            tree.BuildTree(elements);
            return tree.Count();
        }

        [TestCase("(* 2 ( - 0 (- 5 (+ 6 11) ) ) ", ExpectedResult = 24)]
        [TestCase("(* (+ 1 1) 2)", ExpectedResult = 4)]
        [TestCase("(/ (* 2 (- 5 (+ 6 11)) (+ (+ 1 1) (- 4 1)) ) ", ExpectedResult = -4.8)]
        [TestCase("(+ (/ 13 (- 5 3) (/ (+ 1 1) (+ 4 1)) ) ", ExpectedResult = 6.9)]
        public double DifferentExpressionsTest(string expression)
            => CountAnExpression(expression);

        [TestCase("/ 2 (- 5 (+ 2 3))")]
        [TestCase("/ 0 0")]
        public void DivideByZeroTest(string expression)
            => Assert.That(() => CountAnExpression(expression), Throws.TypeOf<DivideByZeroException>());

        [TestCase("/ $ (+ 5 (+ @ 3))")]
        [TestCase("/ 9 p")]
        public void InvalidExpressionTest(string expression)
            => Assert.That(() => CountAnExpression(expression), Throws.TypeOf<ArgumentException>());
    }
}