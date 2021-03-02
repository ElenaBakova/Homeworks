using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void CheckTestsFromFile()
        {
            using (var stream = new StreamReader("Test.txt"))
            {
                for (int i = 0; i < 7; i++)
                {
                    string expression = stream.ReadLine();
                    string answerString = stream.ReadLine();
                    double answer = double.Parse(answerString);
                    var result = Calculator.CountAnExpression(expression, 0);
                    Assert.AreEqual(result.Item1, answer);
                    Assert.IsTrue(result.Item2);
                }
            }
        }
    }
}
