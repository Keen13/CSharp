using System;
using System.Text.RegularExpressions;

namespace PaymentSystemApi
{
    public class PaymentInterface
    {
        private const string BankID1 = "VMPX";

        private const string BankID2 = "OBRX";

        private const string BankID3 = "SBRX";

        private const decimal MinimalCommission = 10;
        private const decimal MediumCommission = 30;
        private const decimal MaximumCommission = 110;
        private const decimal BestCommission = 200;
        private const decimal ConfidenceLimit = 7500;

        private const decimal MaximumPercent = 0.03m;
        private const decimal MediumPercent = 0.02m;
        private const decimal MinimalPercent = 0.01m;

        private const ConsoleKey KeyExit = ConsoleKey.Escape;

        private string userBank = string.Empty;

        private static string userName = string.Empty;

        private static string userAccount = string.Empty;

        private static string userMoney = string.Empty;

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Выбирите ваш бак: \n1)Банк Вампириал \n2)Банк Обирон \n3)Сбербанк России");
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
                            userBank = ChooseBank(1);
                            InsideMenu();
                            break;
                        }
                    
                    case ConsoleKey.D2:
                        {
                            Console.WriteLine("выбран пункт 2");
                            userBank = ChooseBank(2);
                            InsideMenu();
                            break;
                        }
                    
                    case ConsoleKey.D3:
                        {
                            Console.WriteLine("выбран пункт 3");
                            userBank = ChooseBank(3);
                            InsideMenu();
                            break;
                        }
                }
            }
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

        private static void InsideMenu()
        {
            userAccount = ReadAccount();
            if (userAccount == string.Empty || userAccount == "is not")
            {
                Console.WriteLine(userAccount);
            }
            else
            {
                userMoney = ReadMoney();
                Console.WriteLine("Со счета спишится {0} руб. в том числе {1} руб. комиссия", ParseMoney(userMoney) + СountingСommission(userMoney), СountingСommission(userMoney));
            }

            if (ParseMoney(userMoney) >= ConfidenceLimit && userAccount != "is not")
            {
                userName = ReadName();
            }
        }

        private static string ReadAccount()
        {
            Console.WriteLine("Введите номер счета :");
            var pattern = new Regex(@"^\d{9,12}$");
            var account = Console.ReadLine();

            return account != null && pattern.IsMatch(account) ? account : "is not";
        }

        private static string ReadMoney()
        {
            string money;
            var pattern = new Regex(@"^\d*$");

            while (true)
            {
                Console.WriteLine("Введите сумму денежного перевода.");
                money = Console.ReadLine();
                if (money != null && pattern.IsMatch(money) == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверная сумма! Повторите ввод.");
                }
            }

            Console.WriteLine("введенная сумма {0} руб.", money);
            return money;
        }

        private static decimal ParseMoney(string userMoney)
        {
            decimal parseMoney;
            const decimal BaseValue = 0;

            return decimal.TryParse(userMoney, out parseMoney) ? parseMoney : BaseValue;
        }

        private static string ReadName()
        {
            string name;
            var pattern = new Regex(@"^[a-z]+$");

            while (true)
            {
                Console.WriteLine("Для осуществления переводв ввидите Ваше имя:");
                name = Console.ReadLine();
                if (name != null && pattern.IsMatch(name))
                {
                    break;
                }

                Console.WriteLine("Некоректное имя! Повторите ввод.");
            }

            Console.WriteLine("введенное имя {0}", name);
            return name;
        }

        private static decimal СountingСommission(string money)
        {
            var intMoney = decimal.Parse(money);
            var resultCommission = 0.00m;

            if (intMoney < 1000)
            {
                resultCommission = intMoney * MaximumPercent;
                if (resultCommission < MinimalCommission)
                {
                    resultCommission = MinimalCommission;
                }
            }

            if (intMoney == 1000)
            {
                resultCommission = intMoney * MediumPercent;
            }
            
            if (intMoney >= 1000 && intMoney < 5000)
            {
                resultCommission = intMoney * MediumPercent + MediumCommission;
            }

            if (intMoney >= 5000)
            {
                resultCommission = intMoney * MinimalPercent + MaximumCommission;
                if (resultCommission > BestCommission)
                {
                    resultCommission = BestCommission;
                }
            }

            return resultCommission;
        }
    }
}
