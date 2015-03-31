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
            Block2 arg = new Block2(); // TODO VS:  используй var, и дай переменной нормальное имя
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
            
            string[] stringValue = new string[5]; // TODO VS:  используй var 
            stringValue[0] = ParseToString(valueBool);
            stringValue[1] = ParseToString(valueChar);
            stringValue[2] = ParseToString(valueDecimal);
            stringValue[3] = ParseToString(valueDouble);
            stringValue[4] = ParseToString(valueString);

            string[] stringValueInt = new string[4]; // TODO VS: используй var
            stringValueInt[0] = ParseToString(valueInt1);
            stringValueInt[1] = ParseToString(valueInt2);
            stringValueInt[2] = ParseToString(valueInt3);
            stringValueInt[3] = testString;
            string arbitraryString = "-3,5,abc,42,99.99,true,150";

            PrintStringValue(ParseStringToInt(stringValueInt), stringValueInt);

            PrintStringValue(ParseStringToInt(ParseStringToInt2(arbitraryString)), ParseStringToInt2(arbitraryString));

            PrintStringValue(ParseStringToBool(stringValue[0]), stringValue[0]);
            PrintStringValue(ParseStringToChar(stringValue[1]), stringValue[1]);
            PrintStringValue(ParseStringToDecimal(stringValue[2]), stringValue[2]);
            PrintStringValue(ParseStringToDouble(stringValue[3]), stringValue[3]);
            PrintStringValue(ParseStringToString(stringValue[4]), stringValue[4]);
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

        private static string[] ParseStringToInt2(string inString)
        {
            char separator = ',';
            string[] massString = inString.Split(separator);
            return massString;
        }
		
        private static int[] ParseStringToInt(string[] inString)
        {
            int[] intParse = new int[inString.Length];
            bool result;
            for (int i = 0; i < inString.Length; i++)
            {
                result = int.TryParse(inString[i], out intParse[i]);
                if (result == false)
                {
                    intParse[i] = -1;
                }

                else
                {
                    if (intParse[i] < 10)
                    {
                        intParse[i] = 10;
                    }

                    if (intParse[i] > 100)
                    {
                        intParse[i] = 100;
                    }
                }       
            }

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
            for (int i = 0; i < parseValue.Length; i++)
            {
                Console.WriteLine(string.Format("Значение типа int {0} строка {1}", parseValue[i], stringValue[i]));
            }
        }

        private static void PrintStringValue(string parseValue, string stringValue)
        {
            Console.WriteLine(string.Format("Значение определенного типа {0} строка {1}", parseValue, stringValue));
        }
    }
}
