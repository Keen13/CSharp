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

    // VS: Нарушение правила, подчеркнуто синим. при наведении мышью на строку показывается, какое правило нарушеною Заметь - подчеркнута вся строка,
    // VS: но здесь у тебя есть несколько опций - если ты встанешь просто на строку, то тебе будут доступны только опции  управление этим правилом.
    // VS: если встать на имя класса, то будет предложена в том числе опция исправления кода (пирамидка)
    public class Сalculator // TODO VS: [CG 1]
    {
        private const char PlusSymbol = '+';
        private const char MinusSymbol = '-';

        public void ExecuteСalculator()
        {       
            Run();
        }

        private static void Run()
        {
            const string EscapeString = "end"; // TODO VS:  1) [CG 2] 
                                            // TODO VS: 3) эта константа должна быть на уровне класса
            char[] trimSymbol = { ' ', '.', '!' }; // TODO VS: 1 )Почему такой странный набор символов? Если у него есть смысл, вырази его в имени
                                                    // TODO VS: 2) Это набор, значит  имя должно быть во множественном числе  - trimSymbols
                                                    // TODO VS: 3) По смыслу этот набор опять же принадлежит уровню класса
                                                    // TODO VS: 4) по сути  это константа, но  объявить такую константу ты не можешь, 
                                                    // TODO VS: зато можешь  использовать модификатор readonly
            var esc = string.Empty; // TODO VS: непонятно, что должно значить это имя. но скорее всего тебе эта переменная и не нужна

            while (esc != EscapeString) // TODO VS: обрати внимание - здесь и тремя строками ниже ты  делаешь одно и то же сравнение.  зачем?
            {
                var arbitraryString = ReadString();
                esc = arbitraryString.Trim(trimSymbol);
                if (esc != EscapeString)
                {
                    Console.WriteLine("Ответ : {0}", Sum(arbitraryString));
                }
            }

            Console.WriteLine("Спасибо что воспользовались этой программой.");
        }
        
        private static string ReadString() // VS: это хорошая изоляция функциональности в одном методе
        {
            Console.WriteLine("Ввидите арифметический пример произвольной длины на сложение и вычитание \nцелых чисел или end для выхода :");
            return Console.ReadLine();
        }

        private static int Sum(string inString)
        {
            var massInt = ParseStringToInt(SplitArguments(inString));
            var massSign = MassSign(inString); 
  
            var sum = massInt[0];
            var numberSign = 0;
            
            for (var i = 1; i < massInt.Length; i++) 
            {
                if (massSign[numberSign] == PlusSymbol) // TODO VS: ты два раза проверяешь на равенство одну и ту же переменную с разными значениями
                                                        // TODO VS: во-первых, в таком коде у тебя всегда будут выполнены оба сравнения,
                                                        // TODO VS: в отличие от конструкции  if ... else if ...
                                                        // TODO VS: во-вторых, тут можно воспользоваться оператором switch(...)
                                                        // TODO VS: напиши оба варианта  кода для этого блока,  покажешь в скайп, что получилось,
                                                        // TODO VS: потом выберешь  один из них
                {
                    sum = sum + massInt[i];
                    numberSign++; // TODO VS: тебе нафига эта переменная? она всегда равна 'i'
                }

                // VS: Предложение по улучшению кода. Впрочем, не стоит спешить следовать ему а) это такой типичный случай, про который  надо тебе рассказать
                // VS: б) после того, как ты исправишь код по моим замечаниям, этот кусок все равно изменится.
                if (massSign[numberSign] == MinusSymbol)
                {
                    sum = sum - massInt[i];
                    numberSign++;
                }
            }

            return sum;
        }
        
        private static string[] SplitArguments(string inString) 
        {
            char[] separator = { '-', '+' }; // TODO VS: 1) это не константа, почему имя с большой буквы? 2) пробелы вокруг фигурных скобок неправильно стоят.
                                            // TODO VS: посмотри строку 34, там у тебя все верно. 3) явно создавать новый массив через "new char[]" не требуется
                                            // TODO VS: опять же смотри строку 34, как сделано там. почему в двух местах разные подходы?
            var massString = inString.Split(separator); 
            return massString;
        }
        
        private static char[] MassSign(string inString)
        {
            // VS: Нарушение правил.
            const char FindSymbol1 = '-';
            // VS: Нарушение правил.
            const char FindSymbol2 = '+';
            var numberSign = FindNumberSignPlusOne(inString);
            var massSign = new char[numberSign];
            var massSignNumber = 0;

            // VS: Предложение по улучшению
            for (var i = 0; i < inString.Length; i++) 
            {
                if (inString[i] == FindSymbol1)
                {
                    massSign[massSignNumber] = FindSymbol1;
                    massSignNumber = massSignNumber + 1;
                }

                // VS: Предложение по улучшению (и опять тот самый типичный случай)
                if (inString[i] == FindSymbol2)
                {
                    massSign[massSignNumber] = FindSymbol2;
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
            // VS: излиишний код. выделен бледным
            var findSymbols = new[] { '+', '-' }; 

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

            if (intParse < MinValue)  // VS: обрати внимание, что в этом случае у тебя вторая проверка не будет вызвана, если сработает первая
                                    // VS: это отличает этот случай от строки 77
            {
                return MinValue; 
            }

            // VS: Предложение по улучшению (тоже желательно сначала разробрать вместе)
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