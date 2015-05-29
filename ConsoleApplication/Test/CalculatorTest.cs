using Microsoft.VisualStudio.TestTools.UnitTesting;

using Startup;

namespace Test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void EmptyInputTest()
        {
            var input = string.Empty;

            var result = Calculator.Sum(input);

            Assert.AreEqual(0, result);
        }
        
        [TestMethod]
        public void NullInputTest()
        {
            var result = Calculator.Sum(null);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void BorderlineSignificanceTest()
        {
            var testString = new[] { "1001", "1000", "999" };
            var result = Calculator.ParseStringToInt(testString);

            Assert.AreEqual(1000, result[0]);
            Assert.AreEqual(1000, result[1]);
            Assert.AreEqual(999, result[2]);
        }
        
        [TestMethod]
        public void CalculatorFunction()
        {
            var testString = new[] { "5+3", "5-3", "0" };
            var result = Calculator.Sum(testString[0]);
            Assert.AreEqual(8, result);
            result = Calculator.Sum(testString[1]);
            Assert.AreEqual(2, result);
            result = Calculator.Sum(testString[2]);
            Assert.AreEqual(0, result);
        }
    }
}
