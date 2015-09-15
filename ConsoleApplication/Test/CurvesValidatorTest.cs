using Microsoft.VisualStudio.TestTools.UnitTesting;

using Startup;

namespace Test
{
    [TestClass]
    public class CurvesValidatorTest
    {
        [TestMethod]
        public void PositiveTest()
        {
            TestPositiveCase(string.Empty);

            TestPositiveCase("12345");

            TestPositiveCase("()");
            TestPositiveCase("{}");
            TestPositiveCase("[]");

            TestNegativeCase("(");
            TestNegativeCase(")");
            TestNegativeCase("{");
            TestNegativeCase("}");
            TestNegativeCase("[");
            TestNegativeCase("]");

            TestNegativeCase(")(");
            TestNegativeCase("}{");
            TestNegativeCase("][");

            TestPositiveCase("000(1{2[123]4}5)000");
            TestPositiveCase("1(2)3{4}5[]9");

            TestNegativeCase("(123}");
            TestNegativeCase("({)}");
        }

        private void TestPositiveCase(string value)
        {
            var isValid = new CurvesValidator().Validate(value);
            Assert.IsTrue(isValid, " Validation failed for string " + value);
        }

        private void TestNegativeCase(string value)
        {
            var isValid = new CurvesValidator().Validate(value);
            Assert.IsFalse(isValid, " Validation failed for string " + value);
        }
    }
}
