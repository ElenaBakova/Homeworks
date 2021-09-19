using NUnit.Framework;

namespace MatrixMultiplication.Tests
{
    public class Tests
    {
        Matrix firstMatrix;
        Matrix secondMatrix;

        [SetUp]
        public void Setup()
        {
            firstMatrix = Matrix.GenerateMatrix((15, 20));
            secondMatrix = Matrix.GenerateMatrix((20, 40));
        }

        [Test]
        public void BothMethodsShouldBeEqual()
        {
            var first = Matrix.MultiplicateMatrices(firstMatrix, secondMatrix);
            var second = Matrix.MultiplicateMatricesUsually(firstMatrix, secondMatrix);
            Assert.IsTrue(Matrix.AreEqual(first, second));
        }
    }
}