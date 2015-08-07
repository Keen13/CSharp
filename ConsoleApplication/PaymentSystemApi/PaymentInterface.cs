using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystemApi
{
    public class PaymentInterface
    {
        private const string BankID1 = "VMPX";

        private const string BankID2 = "OBRX";

        private const string BankID3 = "SBRX";
        private const ConsoleKey KeyExit = ConsoleKey.Escape;
        
        public void Run()
        {
            Console.WriteLine("Выбирите ваш бак: \n1)Банк Вампириал \n2)Банк Обирон \n3)Сбербанк России");
            
            while (true)
            {
                var keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == KeyExit)
                {
                    break;
                }

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        {
                            Console.WriteLine("выбран пункт 1");
                            break;
                        }
                    
                    case ConsoleKey.D2:
                        {
                            Console.WriteLine("выбран пункт 2");
                            break;
                        }
                    
                    case ConsoleKey.D3:
                        {
                            Console.WriteLine("выбран пункт 3");
                            break;
                        }
                }
            }
        }

        private static string ReadString()
        {
            Console.WriteLine(
                "Введите арифметический пример произвольной длины на сложение и вычитание \nцелых чисел или end для выхода :");
            return Console.ReadLine();
        }

        private static string ChooseBank(int number)
        {
            if (number == 1)
            {
                return BankID1;
            }

            if (number == 2)
            {
                return BankID2;
            }

            if (number == 3)
            {
                return BankID3;
            }

            return "0";
        }
    }
}
