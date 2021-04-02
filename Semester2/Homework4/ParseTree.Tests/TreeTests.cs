using System;
using NUnit.Framework;

namespace ParseTree.Tests
{
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
        public double Test1(string expression)
            => CountAnExpression(expression);
    }
}