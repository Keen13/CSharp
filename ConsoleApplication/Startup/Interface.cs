using System;

namespace Startup
{
    public class Interface
    {
        private const string EscapeString = "end";
        private static readonly char[] FloodSymbols = { ' ', '.', '!' };

        public void ExecuteCalculator()
        {
            Run();
        }

        private static void Run()
        {
            while (true)
            {
                var arbitraryString = ReadString();
                if (arbitraryString.Trim(FloodSymbols) == EscapeString)
                {
                    break;
                }

                Console.WriteLine("Ответ : {0}", Calculator.Calculate(arbitraryString));
            }

            Console.WriteLine("Спасибо что воспользовались этой программой.");
        }

        private static string ReadString()
        {
            Console.WriteLine(
                "Введите арифметический пример произвольной длины на сложение и вычитание \nцелых чисел или end для выхода :");
            return Console.ReadLine();
        }
    }
}