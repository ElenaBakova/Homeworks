using NUnit.Framework;

namespace MatrixMultiplication.Tests
{
    /// <summary>
    /// Matrix multiplication test class
    /// </summary>
    public class Tests
    {
        [TestCase(15, 20, 40)]
        [TestCase(1, 20, 5)]
        [TestCase(1, 1, 1)]
        [TestCase(100, 150, 500)]
        [TestCase(500, 100, 500)]
        public void BothMethodsResultShouldBeEqual(int firstRows, int firstColumns, int secondColumns)
        {
            var firstMatrix = Matrix.GenerateMatrix((firstRows, firstColumns));
            var secondMatrix = Matrix.GenerateMatrix((firstColumns, secondColumns));
            var first = Matrix.MultiplicateMatrices(firstMatrix, secondMatrix);
            var second = Matrix.MultiplicateMatricesUsually(firstMatrix, secondMatrix);
            Assert.IsTrue(Matrix.AreEqual(first, second));
        }

        [TestCase(500, 200, 100, 1000)]
        [TestCase(1, 200, 201, 10)]
        public void IncorrectSizeShouldReturnNull(int rowsFirst, int columnsFirst, int rowsSecond, int columnsSecond)
        {
            var firstMatrix = Matrix.GenerateMatrix((rowsFirst, columnsFirst));
            var secondMatrix = Matrix.GenerateMatrix((rowsSecond, columnsSecond));
            Assert.IsNull(Matrix.MultiplicateMatrices(firstMatrix, secondMatrix));
            Assert.IsNull(Matrix.MultiplicateMatricesUsually(firstMatrix, secondMatrix));
        }
    }
}