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

            var result = Calculator.Calculate(input);

            Assert.AreEqual(0, result);
        }
        
        [TestMethod]
        public void NullInputTest()
        {
            var result = Calculator.Calculate(null);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void BorderlineSignificanceUpTest()
        {
            var result = Calculator.Calculate("1001");

            Assert.AreEqual(1000, result); 
        }

        [TestMethod]
        public void BorderlineSignificanceTest()
        {
            var result = Calculator.Calculate("1000");

            Assert.AreEqual(1000, result); 
        }

        [TestMethod]
        public void BorderlineSignificanceDownTest()
        {
            var result = Calculator.Calculate("999");

            Assert.AreEqual(999, result); 
        }
        
        [TestMethod]
        public void CalculatorFunctionPlus()
        {
            var result = Calculator.Calculate("5+3");

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void CalculatorFunctionMinus()
        {
            var result = Calculator.Calculate("3-5");

            Assert.AreEqual(-2, result); 
        }

        [TestMethod]
        public void CalculatorFunctionTestSpace() 
        {
            var result = Calculator.Calculate(" 5 + 3 ");

            Assert.AreEqual(8, result); 
        }

        [TestMethod]
        public void CalculatorFunctionTestSpace1()  
        {
            var result = Calculator.Calculate("4 8"); 

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CalculatorFunctionTestNotValid()
        {
            var result = Calculator.Calculate("invalid");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CalculatorFunctionTestNotValid1()
        {
            var result = Calculator.Calculate("4.56");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CalculatorFunctionTestNegativeNumber()
        {
            var result = Calculator.Calculate("-5");

            Assert.AreEqual(-5, result);
        }

        [TestMethod]
        public void CalculatorFunctionTestSign()
        {
            var result = Calculator.Calculate("-");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CalculatorFunctionTestTwoSigns()
        {
            var result = Calculator.Calculate("1-5+10");

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void CalculatorFunctionTestDoublePlusSign()
        {
            var result = Calculator.Calculate("++10");

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void CalculatorFunctionTestDoubleMinusSign()
        {
            var result = Calculator.Calculate("--10");

            Assert.AreEqual(-10, result);
        }

        [TestMethod]
        public void CalculatorFunctionTestLongExample()
        {
            var result = Calculator.Calculate("345.78+grgr-  - 5+ 45 4+ 10 + 9999");

            Assert.AreEqual(1005, result);
        }

        [TestMethod]
        public void CalculatorFunctionTestMultiplication()
        {
            var result = Calculator.Calculate("1+2*3");

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void CalculatorFunctionTestLongMultiplication()
        {
            var result = Calculator.Calculate("34534df -  - 5+ 45 4+ 10 + 9999+ 3*3*2");

            Assert.AreEqual(1023, result);
        }
    }
}
