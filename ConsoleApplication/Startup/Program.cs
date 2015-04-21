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
            var anyExpression = new Сalculator();
            anyExpression.ExecuteСalculator();
  
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    public class Сalculator
    {
        public void ExecuteСalculator()
        {       
            Run();
        }

        private static void Run()
        {
            const string escString = "end";
            char[] trimSymbol = { ' ', '.', '!' };
            var arbitraryString = string.Empty;
            var esc = string.Empty;

            while (esc != escString)
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
        
        private static string ReadString()
        {
            Console.WriteLine("Ввидите арифметический пример произвольной длины на сложение и вычитание \nцелых чисел или end для выхода :");
            return Console.ReadLine();
        }

        private static int Sum(string inString)
        {
            var massInt = ParseStringToInt(SplitArguments(inString));
            var massSing = MassSing(inString);
            const char findSymbol1 = '-';
            const char findSymbol2 = '+';
            var sum = massInt[0];
            var numberSing = 0;
            

            for (int i = 1; i < massInt.Length; i++)
            {
                if (massSing[numberSing] == findSymbol2)
                {
                    sum = sum + massInt[i];
                    numberSing++;
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
            char[] Separator = new char[] {'-', '+'}; 
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
            
            for (int i = 0; i < inString.Length; i++)
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
        {
            int i = 0;
            int numberIndex = -1;
            int amountSymbol = 0;
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
    }
}
