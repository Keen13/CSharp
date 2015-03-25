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
            Block2 arg = new Block2(); 
            arg.ExecuteBlock2();
  
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
            var valueInt = 32;
            var valueString = "end!!!";
            
            string[] stringValue = new string[6];
            stringValue[0] = ParseToString(valueBool);
            stringValue[1] = ParseToString(valueChar);
            stringValue[2] = ParseToString(valueDecimal);
            stringValue[3] = ParseToString(valueDouble);
            stringValue[4] = ParseToString(valueInt);
            stringValue[5] = ParseToString(valueString);

            ParseToValue(stringValue);
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
            string stringFormatInt = string.Format("{0:000}", i);
            return stringFormatInt;
        }
        
        private static string ParseToString(string s)
        {
            return s;
        }

        private static void ParseToValue(string[] inString) 
        {
            PrintStringValue(bool.Parse(inString[0]), inString[0]);
            PrintStringValue(char.Parse(inString[1]), inString[1]);
            PrintStringValue(decimal.Parse(inString[2]), inString[2]);
            PrintStringValue(double.Parse(inString[3]), inString[3]);
            PrintStringValue(int.Parse(inString[4]), inString[4]);
            PrintStringValue(inString[5], inString[5]);
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
        private static void PrintStringValue(int parseValue, string stringValue)
        {
            Console.WriteLine(string.Format("Значение определенного типа {0} строка {1}", parseValue, stringValue));
        }
        private static void PrintStringValue(string parseValue, string stringValue)
        {
            Console.WriteLine(string.Format("Значение определенного типа {0} строка {1}", parseValue, stringValue));
        }
    }
}

 // TODO VS: Общие замечания.  Требовалось сделать перевод в строку и парсинг для всех  типов, использованных в  предыдущей задаче, не только для int.