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

            var valueInt = 32;              
            string stringValueInt = ParseToString(valueInt);
            ParseToInt(stringValueInt);
        }

        private static string ParseToString(int i) 
        {
            return i.ToString();
        }

        private static void ParseToInt(string inString) 
        {
            PrintStringValue(int.Parse(inString), inString);        
        }

        private static void PrintStringValue(int parseValueInt, string stringValue) 
        {
            Console.WriteLine(string.Format("Значение определенного типа {0} строка {1}", parseValueInt, stringValue));
        }
    }
}

 // TODO VS: Общие замечания.  Требовалось сделать перевод в строку и парсинг для всех  типов, использованных в  предыдущей задаче, не только для int.