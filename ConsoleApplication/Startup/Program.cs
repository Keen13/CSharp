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
            var valueInt1 = 32;
            var valueString = "end!!!";
            var valueInt2 = 6;
            var valueInt3 = 140;
            var testString = "4.12";
            
            string[] stringValue = new string[5];
            stringValue[0] = ParseToString(valueBool);
            stringValue[1] = ParseToString(valueChar);
            stringValue[2] = ParseToString(valueDecimal);
            stringValue[3] = ParseToString(valueDouble);
            //stringValue[4] = ParseToString(valueInt1);
            stringValue[4] = ParseToString(valueString);
            //stringValue[6] = ParseToString(valueInt2);
            //stringValue[7] = ParseToString(valueInt3);

            string[] stringValueInt = new string[4];
            stringValueInt[0] = ParseToString(valueInt1);
            stringValueInt[1] = ParseToString(valueInt2);
            stringValueInt[2] = ParseToString(valueInt3);
            stringValueInt[3] = testString;

            ParseStringToInt(stringValueInt);

            PrintStringValue(ParseStringToBool(stringValue[0]), stringValue[0]);
            PrintStringValue(ParseStringToChar(stringValue[1]), stringValue[1]);
            PrintStringValue(ParseStringToDecimal(stringValue[2]), stringValue[2]);
            PrintStringValue(ParseStringToDouble(stringValue[3]), stringValue[3]);
            //PrintStringValue(ParseStringToInt(stringValue[4]), stringValue[4]);
            PrintStringValue(ParseStringToString(stringValue[4]), stringValue[4]);
            //PrintStringValue(ParseStringToInt(stringValue[6]), stringValue[6]);
            //PrintStringValue(ParseStringToInt(stringValue[7]), stringValue[7]);
            //PrintStringValue(ParseStringToInt(testString), testString);
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

        private static void ParseStringToInt(string[] inString)
        {
            int intParse;

            for (int i = 0; i < inString.Length; i++)
            {
                if (inString[i].Contains("."))
                {
                    intParse = -1;
                }
                else
                {
                    intParse = int.Parse(inString[i]);

                    if (intParse < 10)
                    {
                        intParse = 10;
                    }

                    if (intParse > 100)
                    {
                        intParse = 100;
                    }
                }
                PrintStringValue(intParse, inString[i]);
            }
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
        private static void PrintStringValue(int parseValue, string stringValue)
        {
            Console.WriteLine(string.Format("Значение типа int {0} строка {1}", parseValue, stringValue));
        }
        private static void PrintStringValue(string parseValue, string stringValue)
        {
            Console.WriteLine(string.Format("Значение определенного типа {0} строка {1}", parseValue, stringValue));
        }
    }
}

 // TODO VS: Общие замечания.  Требовалось сделать перевод в строку и парсинг для всех  типов, использованных в  предыдущей задаче, не только для int.