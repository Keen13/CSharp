using System;
using System.Runtime.InteropServices;
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

        private UserInputData _data;

        public void Run()
        {
            _data = new UserInputData();

            while (true)
            {
                var selectUser = SelectUser();
                _data.UserBank = ChooseBank(selectUser);
                InsideMenu();
            }
        }

        private static string SelectUser()  // ограничить выбор банка!!!
        {
            Console.WriteLine("Выбирите ваш бак: \n1)Банк Вампириал \n2)Банк Обирон \n3)Сбербанк России");
            var keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.D1)
            {
                Console.WriteLine("выбран пункт 1");
                return "1";
            }

            if (keyInfo.Key == ConsoleKey.D2)
            {
                Console.WriteLine("выбран пункт 2");
                return "2";
            }
            
            if (keyInfo.Key == ConsoleKey.D3)
            {
                Console.WriteLine("выбран пункт 3");
                return "3";
            }

            return "is not";
        }

        private static string ChooseBank(string number)
        {
            switch (number)
            {
                case "1":
                    return BankID1;
                case "2":
                    return BankID2;
                case "3":
                    return BankID3;
                default:
                    Console.WriteLine("Выбирите один из представленных банков");
                    return "0";
            }
        }

        private void InsideMenu()
        {
            _data.UserAccount = ReadAccount();
            if (_data.UserAccount == string.Empty || _data.UserAccount == "is not")
            {
                Console.WriteLine(_data.UserAccount);
            }
            else
            {
                _data.UserMoney = ReadMoney();
                Console.WriteLine("Со счета спишится {0} руб. в том числе {1} руб. комиссия", ParseMoney(_data.UserMoney) + СountingСommission(_data.UserMoney), СountingСommission(_data.UserMoney));
            }

            if (ParseMoney(_data.UserMoney) >= ConfidenceLimit && _data.UserAccount != "is not")
            {
                _data.UserName = ReadName();
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
