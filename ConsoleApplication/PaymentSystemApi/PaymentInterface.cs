using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystemApi
{
    public class PaymentInterface
    {
        public void Run()
        {
            const ConsoleKey KeyExit = ConsoleKey.Escape;
            string arbitraryString;
            
            while (true)
            {
                var keyInfo = Console.ReadKey(true);
                arbitraryString = ReadString();
                if (KeyExit == keyInfo.Key)
                {
                    break;
                }
            }

            Console.WriteLine("Спасибо что воспользовались этой программой {0}.", arbitraryString);
        }

        private static string ReadString()
        {
            Console.WriteLine(
                "Введите арифметический пример произвольной длины на сложение и вычитание \nцелых чисел или end для выхода :");
            return Console.ReadLine();
        }
    }
}
