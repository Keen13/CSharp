using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup  
{
    public class Program // TODO VS: [CG 1]
    {
        public static void Main()
        {
            var anyExpression = new Сalculator(); // TODO VS:  и почему объект типа "калькулятор" у тебя называется "любоеВыражение"?
												  // TODO VS: как это описывает его смысл?
            anyExpression.ExecuteСalculator();
  
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    public class Сalculator // TODO VS: [CG 1]
    {
        public void ExecuteСalculator()
        {       
            Run();
        }

        private static void Run()
        {
            const string escString = "end"; // TODO VS:  1) [CG 2] 
											// TODO VS: 2) не сокращ. названия - код читается на порядок чаще, чем пишется. "escapeString"
											// TODO VS: 3) эта константа должна быть на уровне класса
            char[] trimSymbol = { ' ', '.', '!' }; // TODO VS: 1 )Почему такой странный набор символов? Если у него есть смысл, вырази его в имени
													// TODO VS: 2) Это набор, значит  имя должно быть во множественном числе  - trimSymbols
													// TODO VS: 3) По смыслу этот набор опять же принадлежит уровню класса
													// TODO VS: 4) по сути  это константа, но  объявить такую константу ты не можешь, 
													// TODO VS: зато можешь  использовать модификатор readonly
            var arbitraryString = string.Empty;
            var esc = string.Empty; // TODO VS: непонятно, что должно значить это имя. но скорее всего тебе эта переменная и не нужна

            while (esc != escString) // TODO VS: обрати внимание - здесь и тремя строками ниже ты  делаешь одно и то же сравнение.  зачем?
            {
                arbitraryString = ReadString();
                esc = arbitraryString.Trim(trimSymbol);
                if (esc == escString)
                {
                    Console.WriteLine("Спасибо что воспользовались этой программой.");
                }
                else
                {
                    Console.WriteLine("Ответ : {0}", Sum(arbitraryString));
                }
            }
        }
        
        private static string ReadString() // VS: это хорошая изоляция функциональности в одном методе
        {
            Console.WriteLine("Ввидите арифметический пример произвольной длины на сложение и вычитание \nцелых чисел или end для выхода :");
            return Console.ReadLine();
        }

        private static int Sum(string inString)
        {
            var massInt = ParseStringToInt(SplitArguments(inString));
            var massSing = MassSing(inString); // TODO VS: ты хотел написать "Sign" (знак)? Если да, исправь по всему коду. Если нет, то что это имя значит?
            const char findSymbol1 = '-'; // TODO VS:  1) [CG 2] 2) плохое название, не отражает смысл. почему не plusSymbol например? 
										// TODO VS:  3) у тебя этот символ повторяется 4 раза в разных методах.  что , если завтра  скажут, что вычитание
										// TODO VS: для этих примеров должно записываться  другим знаком - будешь искать и менять все 4 места?
            const char findSymbol2 = '+'; // TODO VS:  1) все те же замечание, что на  предудыщей строке
            var sum = massInt[0];
            var numberSing = 0;
            
// TODO VS: две пустые строки подряд недопустимы [Coding Guidelines]
            for (int i = 1; i < massInt.Length; i++) // TODO VS: use 'var'
            {
                if (massSing[numberSing] == findSymbol2) // TODO VS: ты два раза проверяешь на равенство одну и ту же переменную с разными значениями
														// TODO VS: во-первых, в таком коде у тебя всегда будут выполнены оба сравнения,
														// TODO VS: в отличие от конструкции  if ... else if ...
														// TODO VS: во-вторых, тут можно воспользоваться оператором switch(...)
														// TODO VS: напиши оба варианта  кода для этого блока,  покажешь в скайп, что получилось,
														// TODO VS: потом выберешь  один из них
                {
                    sum = sum + massInt[i];
                    numberSing++; // TODO VS: тебе нафига эта переменная? она всегда равна 'i'
                }

                if (massSing[numberSing] == findSymbol1)
                {
                    sum = sum - massInt[i];
                    numberSing++;
                }
            }

            return sum;
        }
        
        private static string[] SplitArguments(string inString) 
        {
            char[] Separator = new char[] {'-', '+'}; // TODO VS: 1) это не константа, почему имя с большой буквы? 2) пробелы вокруг фигурных скобок неправильно стоят.
													// TODO VS: посмотри строку 34, там у тебя все верно. 3) явно создавать новый массив через "new char[]" не требуется
													// TODO VS: опять же смотри строку 34, как сделано там. почему в двух местах разные подходы?
            var massString = inString.Split(Separator); 
            return massString;
        }

        private static char[] MassSing(string inString)
        {
            const char findSymbol1 = '-';
            const char findSymbol2 = '+';
            var numderSing = FindNumberSingPlusOne(inString);
            var massSing = new char[numderSing];
            var massSingNumber = 0;
            
            for (int i = 0; i < inString.Length; i++) // TODO VS: use 'var'
            {
                if (inString[i] == findSymbol1)
                {
                    massSing[massSingNumber] = findSymbol1;
                    massSingNumber = massSingNumber + 1;
                }

                if (inString[i] == findSymbol2)
                {
                    massSing[massSingNumber] = findSymbol2;
                    massSingNumber = massSingNumber + 1;
                }
            }

            return massSing;
        }

        private static int FindNumberSingPlusOne(string inString)  //не нашел ничего уменее как свести массивы к одной длинне таким вот способом.
		// VS: ну тоже подход, нашел ведь его.  доведи до ума, потом будет тебе другая идея.
        {
            int i = 0; // TODO VS: use 'var'
            int numberIndex = -1; // TODO VS: use 'var'
            int amountSymbol = 0; // TODO VS: use 'var'
            var findSymbols = new char[] {'+', '-'};

            while (i != -1)
            {
                i = inString.IndexOfAny(findSymbols, numberIndex + 1);
                numberIndex = i;
                amountSymbol++;
            }

            return amountSymbol;
        }

        private static int[] ParseStringToInt(string[] inString)
        {
            var intParse = new int[inString.Length];

            for (var i = 0; i < inString.Length; i++) 
            {
                intParse[i] = ParseOneValueInt(inString[i]); 
            }

            return intParse;
        }
        
        private static int ParseOneValueInt(string inString)
        {
            int intParse;
            int BaseValue = 0; // TODO VS: const

            if (int.TryParse(inString, out intParse)) 
            {
                return AdjustInt(intParse);
            }

            return BaseValue;
        }

        private static int AdjustInt(int intParse) 
        {
            const int MaxValue = 1000;
            const int MinValue = -1000;

            if (intParse < MinValue)  // VS: обрати внимание, что в этом случае у тебя вторая проверка не будет вызвана, если сработает первая
									// VS: это отличает этот случай от строки 77
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

// TODO VS: [CG 2] имена констант начинаются с большой буквы, как и у методов.
 