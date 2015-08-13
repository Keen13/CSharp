using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PaymentSystemApi
{
    public class PaymentInterface
    {
        private const string BankID1 = "VMPX";

        private const string BankID2 = "OBRX";

        private const string BankID3 = "SBRX";
        private const ConsoleKey KeyExit = ConsoleKey.Escape;

        private string myBank = string.Empty;

        private string myAccount = string.Empty;

        private string myMoney = string.Empty;

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
                            myBank = ChooseBank(1);
                            myAccount = ReadString();
                            Console.WriteLine(myAccount);
                            break;
                        }
                    
                    case ConsoleKey.D2:
                        {
                            Console.WriteLine("выбран пункт 2");
                            myBank = ChooseBank(2);
                            break;
                        }
                    
                    case ConsoleKey.D3:
                        {
                            Console.WriteLine("выбран пункт 3");
                            myBank = ChooseBank(3);
                            break;
                        }
                }
            }
        }

        private static string ReadString()
        {
            Console.WriteLine("Введите номер счета :");
            var pattern = new Regex(@"\d{9,12}");
            var account = Console.ReadLine();

            return account != null && pattern.IsMatch(account) ? account : "is not";
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
