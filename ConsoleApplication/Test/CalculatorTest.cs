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
        public void CalculatorFunctionTestSpase()
        {
            var result = Calculator.Sum(" 5 + 3 ");

            Assert.AreEqual(8, result); 
        }

        [TestMethod]
        public void CalculatorFunctionTestSpase1()
        {
            var result = Calculator.Sum("4 8+3");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void CalculatorFunctionTestNotValid()
        {
            var result = Calculator.Sum("invalid");

            Assert.AreEqual(0, result);
        }
    }
}

// TODO VS: [CG1] Если в тесте больше одного раза используется любой Assert, то каждый из них должен иметь уникальное (в рамках теста) сообщение. 
// TD VS: Исполнение теста прервется на первой упавшей проверке, и любой, кто использует эти тесты (а это может быть кто-то, кто их в перый раз видит),
// TD VS: должен сразу видеть, какая именно проверка упала.
// TD VS: В тестах с единственной проверкой  сообщение можно не писать, но иногда оно бывает  полезно, чтобы предоставить дополнительную информацию.
// TD VS: Тесты, как и любой код, читаются на порядок  чаще, чем пишутся, и что еще важнее, запускаются на два порядка чаще, поэтому экономить на
// TD VS: быстром определении упавшей  проверки не стоит.

// TODO VS: Комментарий: Но в твоем случае (тесты BorderlineSignificanceTest и CalculatorFunction) все еще проще - не надо проверять несколько случаев в одном тесте.  
// TD VS: Тест должен быть настолько простым, насколько возможно, и проверять один случай / одну комбинацию параметров.  То есть,  оба этих теста тебе надо разбить
// TD VS: на три штуки каждый, и назвать их по смыслу. А правило [CG1]  надо знать и следовать ему там, где требуется больше одной проверки на один случай.

// VS: насчет именования тестов поговорим чуть позже, но вообще  на эту тему тоже есть определенные соглашения, и как минимум здравый смысл

// TODO VS: Насчет других тестов - возьми техзадание, фактически это будет готовое описание того, что ты должен тестировать. Например, читаешь:
// TD VS: "Одиночное значение должно восприниматься как  валидный пример" - вот тебе готовый test case (который ты, кстати, уже написал). И так далее.