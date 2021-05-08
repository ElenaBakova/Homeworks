using Calculator;
using NUnit.Framework;
using System;

namespace CalculatingClasss.Tests
{
    public class Tests
    {
        [SetUp]
        public void SetUp()
        {
            CalculatingClass calculator = new();
        }

        [Test]
        public void DivideByZeroTest()
        {
            Assert.Throws<DivideByZeroException>(() => );
        }
    }
}