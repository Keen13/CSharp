using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace PaymentSystemApi
{
    public class PaymentInterface
    {
        private const decimal MinimalCommission = 10;
        private const decimal MediumCommission = 30;
        private const decimal MaximumCommission = 110;
        private const decimal BestCommission = 200;
        private const decimal ConfidenceLimit = 7500;

        private const decimal MaximumPercent = 0.03m;
        private const decimal MediumPercent = 0.02m;
        private const decimal MinimalPercent = 0.01m; 

        private const int OneBarrierRemittance = 1000;
        private const int TowBarrierRemittance = 5000;

        private UserInputData _data;

        private static readonly List<Bank> ListBanks = new List<Bank>(); 

        public void Run()
        {
            _data = new UserInputData();

            ListBanks.Add(new Bank { BankId = "VMPX", BankName = "Банк Вампириал" });
            ListBanks.Add(new Bank { BankId = "OBRX", BankName = "Банк Обирон" });
            ListBanks.Add(new Bank { BankId = "SBRX", BankName = "Сбербанк России" });
            
            while (true)
            {
                var selectUser = SelectUser();
                
                if (selectUser == "0")
                {
                    break;
                }

                if (selectUser != "is not")
                {
                    _data.UserBank = ChooseBank(selectUser);
                    InsideMenu();
                }
                else
                {
                    Console.WriteLine("Нет такого пункта меню \n");
                }
            }
        }

        private static string SelectUser() //////////////////////////////////////////
        {
            Console.WriteLine("Выбирите ваш банк или нажмите 0 для выхода");
            for (var i = 1; i <= ListBanks.Count; i++)
            {
                Console.WriteLine("{1}) {0}", ListBanks[(i - 1)].BankName, i);
            }

            var menuItem = ReadMenuItem();
            if (menuItem != 0 && menuItem <= ListBanks.Count)
            {
                return menuItem.ToString();
            }

            return menuItem == 0 ? "0" : "is not";
        }

        private static int ReadMenuItem()
        {
            var pattern = new Regex(@"^\d{1,2}$");
            var menuItem = Console.ReadLine();

            if (!string.IsNullOrEmpty(menuItem) && pattern.IsMatch(menuItem))
            {
                return int.Parse(menuItem);
            }

            Console.WriteLine("Нет такого пункта меню");
            return 0;
        }

        private static string ChooseBank(string number)
        {
            var numberParse = int.Parse(number) - 1;
            if (numberParse < ListBanks.Count)
            {
                return ListBanks[numberParse].BankId;
            }

            Console.WriteLine("Выбирите один из представленных банков \n");
            return "0";
        }

        private void InsideMenu()
        {
            var money = 0.00m;
            _data.UserAccount = ReadAccount();
            if (_data.UserAccount != "is not")
            {
                _data.UserMoney = ReadMoney();
                money = ParseMoney(_data.UserMoney);
                var countingCommission = CountingCommission(_data.UserMoney);
                Console.WriteLine("Со счета спишится {0} руб. в том числе {1} руб. комиссия \n", money + countingCommission, countingCommission);
            }

            if (money >= ConfidenceLimit && _data.UserAccount != "is not")
            {
                _data.UserName = ReadName();
            }
        }

        private static string ReadAccount()
        {
            Console.WriteLine("Введите номер счета :");
            var pattern = new Regex(@"^\d{9,12}$");
            var account = Console.ReadLine();

            if (!string.IsNullOrEmpty(account) && pattern.IsMatch(account))
            {
                return account;
            }

            Console.WriteLine("Неверный номер счета");
            return "is not";
        }

        private static string ReadMoney()
        {
            string money;
            var pattern = new Regex(@"^\d*$");

            while (true)
            {
                Console.WriteLine("Введите сумму денежного перевода.");
                money = Console.ReadLine();
                if (money != null && pattern.IsMatch(money))
                {
                    break;
                }

                Console.WriteLine("Неверная сумма! Повторите ввод.\n");
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

        private static decimal CountingCommission(string money)
        {
            var decimalMoney = decimal.Parse(money);
            decimal resultCommission;

            if (decimalMoney < OneBarrierRemittance)
            {
                resultCommission = decimalMoney * MaximumPercent;
                if (resultCommission < MinimalCommission)
                {
                    return MinimalCommission;
                }
            }
            else if (decimalMoney == OneBarrierRemittance)
            {
                return decimalMoney * MediumPercent;
            }
            else if (decimalMoney >= OneBarrierRemittance && decimalMoney < TowBarrierRemittance)
            {
                return (decimalMoney * MediumPercent) + MediumCommission;
            }
            else
            {
                resultCommission = (decimalMoney * MinimalPercent) + MaximumCommission;
                if (resultCommission > BestCommission)
                {
                    return BestCommission;
                }
            }

            return resultCommission;
        }
    }
}
