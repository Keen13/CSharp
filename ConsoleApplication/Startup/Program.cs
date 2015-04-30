using System;
using System.Collections.Generic;

namespace Startup  
{
    public class Program // TODO VS: [CG 1]
    {
        public static void Main()
        {
            var expression = new Сalculator(); 
            expression.ExecuteСalculator();
  
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    public class Сalculator // TODO VS: [CG 1]
    {
        private const char PlusSymbol = '+';
        private const char MinusSymbol = '-';
        private const string EscapeString = "end";

        public void ExecuteСalculator()
        {       
            Run();
        }

        private static void Run()
        {
            char[] floodSymbol = { ' ', '.', '!' }; // TODO VS: 1 )Почему такой странный набор символов? Если у него есть смысл, вырази его в имени
                                                    // TODO VS: 2) Это набор, значит  имя должно быть во множественном числе  - trimSymbols
                                                    // TODO VS: 3) По смыслу этот набор опять же принадлежит уровню класса
                                                    // TODO VS: 4) по сути  это константа, но  объявить такую константу ты не можешь, 
                                                    // TODO VS: зато можешь  использовать модификатор readonly
            var esc = string.Empty; // TODO VS: непонятно, что должно значить это имя. но скорее всего тебе эта переменная и не нужна

            while (esc != EscapeString) // TODO VS: обрати внимание - здесь и тремя строками ниже ты  делаешь одно и то же сравнение.  зачем?
            {
                var arbitraryString = ReadString();
                esc = arbitraryString.Trim(floodSymbol);
                if (esc != EscapeString)
                {
                    Console.WriteLine("Ответ : {0}", Sum(arbitraryString));
                }
            }

            Console.WriteLine("Спасибо что воспользовались этой программой.");
        }
        
        private static string ReadString() 
        {
            Console.WriteLine("Ввидите арифметический пример произвольной длины на сложение и вычитание \nцелых чисел или end для выхода :");
            return Console.ReadLine();
        }

        private static int Sum(string inString)
        {
            var massInt = ParseStringToInt(SplitArguments(inString));
            var massSign = MassSign(inString); 
  
            var sum = massInt[0];
            
            for (var i = 0; i < massInt.Length; i++) 
            {
                switch (massSign[i])
                {
                    case PlusSymbol:
                        sum = sum + massInt[i + 1];
                        break;
                    case MinusSymbol:
                        sum = sum - massInt[i + 1];
                        break;
                }
            }

            return sum;
        }
        
        private static string[] SplitArguments(string inString) 
        {
            char[] separator = { PlusSymbol, MinusSymbol }; 
            var massString = inString.Split(separator); 
            return massString;
        }
        
        private static char[] MassSign(string inString)
        {
            var numberSign = FindNumberSignPlusOne(inString);
            var massSign = new char[numberSign];
            var massSignNumber = 0;

            for (var i = 0; i < inString.Length; i++) 
            {
                if (inString[i] == MinusSymbol)
                {
                    massSign[massSignNumber] = MinusSymbol;
                    massSignNumber = massSignNumber + 1;
                }

                if (inString[i] == PlusSymbol)
                {
                    massSign[massSignNumber] = PlusSymbol;
                    massSignNumber = massSignNumber + 1;
                }
            }

            return massSign;
        }
        
        private static int FindNumberSignPlusOne(string inString)  //не нашел ничего уменее как свести массивы к одной длинне таким вот способом.
        // VS: ну тоже подход, нашел ведь его.  доведи до ума, потом будет тебе другая идея.
        {
            var i = 0; 
            var numberIndex = -1; 
            var amountSymbol = 0;
            var findSymbols = new[] { PlusSymbol, MinusSymbol }; 

            while (i != -1)
            {
                i = inString.IndexOfAny(findSymbols, numberIndex + 1);
                numberIndex = i;
                amountSymbol++;
            }

            return amountSymbol;
        }

        private static int[] ParseStringToInt(IList<string> inString)
        {
            var intParse = new int[inString.Count];

            for (var i = 0; i < inString.Count; i++) 
            {
                intParse[i] = ParseOneValueInt(inString[i]); 
            }

            return intParse;
        }
        
        private static int ParseOneValueInt(string inString)
        {
            int intParse;
            const int BaseValue = 0;

            return int.TryParse(inString, out intParse) ? AdjustInt(intParse) : BaseValue;
        }

        private static int AdjustInt(int intParse) 
        {
            const int MaxValue = 1000;
            const int MinValue = -1000;

            if (intParse < MinValue)  
            {
                return MinValue; 
            }

            if (intParse > MaxValue)
            {
                return MaxValue;
            } 

            return intParse;
        }
    }
}

// TODO VS: [CG 1] Каждый публичный класс, интерфейс, перечисление  должны располагаться в отдельном файле. Помещать в тот же файл два класса можно только
// TODO VS: для приватных классов. Добро пожаловать в реальный мир =)
