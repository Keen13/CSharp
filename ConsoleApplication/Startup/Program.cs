using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup  
{
    public class Program   
    {
        public static void Main()
        {
            var anyValueParser = new Block2(); 
            anyValueParser.ExecuteBlock2();
  
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    
    public class Block2
    {
        public void ExecuteBlock2()
        {       
            Console.WriteLine("Bloсk 2:");

            var valueBool = true;
            var valueChar = 'C';
            var valueDecimal = 150.99m;
            var valueDouble = 444.44;
            var valueInt1 = 32;
            var valueString = "end!!!";
            var valueInt2 = 6;
            var valueInt3 = 140;
            var testString = "4.12";
            
            var stringValue = new string[5]; 
            stringValue[0] = ParseToString(valueBool);
            stringValue[1] = ParseToString(valueChar);
            stringValue[2] = ParseToString(valueDecimal);
            stringValue[3] = ParseToString(valueDouble);
            stringValue[4] = ParseToString(valueString);

            //var arbitraryString = "-3,5,abc,42,99.99,true,150"; 
            var arbitraryString = ReadString();
            var stringValueInt = new string[4]; 
            stringValueInt[0] = ParseToString(valueInt1);
            stringValueInt[1] = ParseToString(valueInt2);
            stringValueInt[2] = ParseToString(valueInt3);
            stringValueInt[3] = testString;
            var splitArguments = SplitArguments(arbitraryString); 

            PrintStringValue(ParseStringToInt(stringValueInt), stringValueInt);
            PrintStringValue(ParseStringToInt(splitArguments), splitArguments);

            PrintStringValue(ParseStringToBool(stringValue[0]), stringValue[0]);
            PrintStringValue(ParseStringToChar(stringValue[1]), stringValue[1]);
            PrintStringValue(ParseStringToDecimal(stringValue[2]), stringValue[2]);
            PrintStringValue(ParseStringToDouble(stringValue[3]), stringValue[3]);
            PrintStringValue(ParseStringToString(stringValue[4]), stringValue[4]);
        }

        private static string ReadString()
        {
            Console.WriteLine("Ввидите строку для парсинга в тип Int, значения разделяйте ','");
            return Console.ReadLine();
        //TODO VS: лишняя пустая строка
        }

        private static string ParseToString(bool b) 
        {
            return b.ToString();
        }

        private static string ParseToString(char ch)
        {
            return ch.ToString();
        }

        private static string ParseToString(decimal d)
        {
            return d.ToString();
        }

        private static string ParseToString(double db)
        {
            return db.ToString();
        }

        private static string ParseToString(int i)
        {
            return string.Format("{0:000}", i);
        }
        
        private static string ParseToString(string s)
        {
            return s;
        }

        private static bool ParseStringToBool(string inString)
        {
            return bool.Parse(inString);
        }

        private static char ParseStringToChar(string inString)
        {
            return char.Parse(inString);
        }

        private static decimal ParseStringToDecimal(string inString)
        {
            return decimal.Parse(inString);
        }

        private static double ParseStringToDouble(string inString)
        {
            return double.Parse(inString);
        }

        private static string[] SplitArguments(string inString) 
        {
            const char separator = ','; //TODO VS: [CG] Имена констант начинаются с большой буквы (не путать с переменными)
            var massString = inString.Split(separator); 
            return massString;
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

            if (Utils.TryParseIntStrict(inString, out intParse)) // NB! Не изменять эту строку.
            {
                return ComparisonInt(intParse);
            }
            else //TODO VS: Сделано хорошо, но  обрати внимание, что блок  после if завершает  исполнение всего метода, если в него 
                 //TODO VS: попало управление. 'else' в такой  ситуации становится излишним - он и так исполнится только в том случае, 
                 //TODO VS: если не исполнился первый блок.  убери ненужный 'else' и ставшие после этого ненужными скобки
                //TODO VS: и не забудь про пустую строку =)
            {
                return -1;
            }            
        }

        private static int ComparisonInt(int intParse) //TODO VS: Имена методов это глаголы, т.к. метод это действие. у тебя получилось
        //TODO VS: "СравнениеИнт". Вероятно ты хотел "CompareInt" ("СравнитьИнт"), но  это имя будет неверным -  ведь метод не просто 
        //TODO VS: сравнивает значение (сравнение подразумевает ответ в стиле "да-нет", "больше-меньше-равно"), а изменяет его,
        //TODO VS: подгоняя под заданные рамки. Я бы использовал в имени слово "Adjust" (AdjustValue, AdjustInt или как еще придумаешь...)
        {
            if (intParse < 10)  //TODO VS: неплохо, но можно лучше. что означают эти загадочные числа "10" и "100" в логике метода?
            //TODO VS: в программировании это называется магическими числами, и это плохая практика програмирования, т.к.
            //TODO VS: смысл кода неясен, и при изменени легко пропустить такое число.  и опять же - представь, что  у тебя большой 
            //TODO VS: проект, с которым работаешь не ты один - насколько был бы понятен этот код тебе, если бы его написал кто-то другой?
            //TODO VS: см. https://ru.wikipedia.org/wiki/%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%BE%D0%B5_%D1%87%D0%B8%D1%81%D0%BB%D0%BE_(%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5)
            //TODO VS: хорошее решение - вынести магические числа в хорошо именованные константы. назови их "MinValue" и "MaxValue"
            //TODO VS:  и посмотри, насколько понятнее станет код. особенно, если избавиться от дублирования этих чисел.
            {
                return 10; 
            }

            if (intParse > 100)
            {
                return 100;
            } //TODO VS: добавь пустую строку
            return intParse;
        }

        private static string ParseStringToString(string inString)
        {
            return inString;
        }         
        
        private static void PrintStringValue(bool parseValue, string stringValue) 
        {
            Console.WriteLine(string.Format("Значение определенного типа {0} строка {1}", parseValue, stringValue));
        }
        
        private static void PrintStringValue(char parseValue, string stringValue)
        {
            Console.WriteLine(string.Format("Значение определенного типа {0} строка {1}", parseValue, stringValue));
        }

        private static void PrintStringValue(decimal parseValue, string stringValue)
        {
            Console.WriteLine(string.Format("Значение определенного типа {0} строка {1}", parseValue, stringValue));
        }

        private static void PrintStringValue(double parseValue, string stringValue)
        {
            Console.WriteLine(string.Format("Значение определенного типа {0} строка {1}", parseValue, stringValue));
        }

        private static void PrintStringValue(int[] parseValue, string[] stringValue) 
        {
            const string separator = ","; //TODO VS: [CG] Имена констант начинаются с большой буквы (не путать с переменными)

            var stringWriteInt = string.Join(separator, parseValue);
            var stringWriteStr = string.Join(separator, stringValue);
            Console.WriteLine(string.Format("Значение типа int {0} строка {1}", stringWriteInt, stringWriteStr));
        }

        private static void PrintStringValue(string parseValue, string stringValue)
        {
            Console.WriteLine(string.Format("Значение определенного типа {0} строка {1}", parseValue, stringValue));
        }
    }
}
