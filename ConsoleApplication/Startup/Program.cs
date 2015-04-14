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

            var arbitraryString = ReadString();
            var splitArguments = SplitArguments(arbitraryString); 

            PrintStringValue(ParseStringToInt(splitArguments), splitArguments);

        }

        private static string ReadString()
        {
            Console.WriteLine("Ввидите строку для парсинга в тип Int, значения разделяйте ','");
            return Console.ReadLine();
        }

        private static string[] SplitArguments(string inString) 
        {
            char[] Separator = new char[] {'-', '+'}; 
            var massString = inString.Split(Separator); 
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
            int BaseValue = 0;

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

        private static void PrintStringValue(int[] parseValue, string[] stringValue) 
        {
            const string Separator = ","; 

            var stringWriteInt = string.Join(Separator, parseValue);
            var stringWriteStr = string.Join(Separator, stringValue);
            Console.WriteLine(string.Format("Значение типа int {0} строка {1}", stringWriteInt, stringWriteStr));
        }

    }
}
