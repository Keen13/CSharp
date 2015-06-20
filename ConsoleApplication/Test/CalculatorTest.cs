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
        public void BorderlineSignificanceUpTest()
        {
            var result = Calculator.Sum("1001");

            Assert.AreEqual(1000, result); 
        }

        [TestMethod]
        public void BorderlineSignificanceTest()
        {
            var result = Calculator.Sum("1000");

            Assert.AreEqual(1000, result); 
        }

        [TestMethod]
        public void BorderlineSignificanceDownTest()
        {
            var result = Calculator.Sum("999");

            Assert.AreEqual(999, result); 
        }
        
        [TestMethod]
        public void CalculatorFunctionPlus()
        {
            var result = Calculator.Sum("5+3");

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void CalculatorFunctionMinus()
        {
            var result = Calculator.Sum("3-5");

            Assert.AreEqual(-2, result); 
        }

        [TestMethod]
        public void CalculatorFunctionTestSpace() 
        {
            var result = Calculator.Sum(" 5 + 3 ");

            Assert.AreEqual(8, result); 
        }

        [TestMethod]
        public void CalculatorFunctionTestSpace1()  
        {
            var result = Calculator.Sum("4 8"); 

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CalculatorFunctionTestNotValid()
        {
            var result = Calculator.Sum("invalid");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CalculatorFunctionTestNotValid1()
        {
            var result = Calculator.Sum("4.56");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CalculatorFunctionTestNegativeNumber()
        {
            var result = Calculator.Sum("-5");

            Assert.AreEqual(-5, result);
        }

        [TestMethod]
        public void CalculatorFunctionTestLongExample()
        {
            var result = Calculator.Sum("345.78+grgr-  - 5+ 45 4+ 10 + 9999");

            Assert.AreEqual(1005, result);
        }
    }
}
