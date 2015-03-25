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
            Console.WriteLine("Bloсk 2:");  // TODO VS: после этой строки неплохо бы пустую строку поставить, т.к. дальше идет логически отделенный блок кода
            int valueInt = 32;  // TODO VS: используй var            
            string stringValueInt=PrintValue(valueInt); // TODO VS: форматирование - пробелы вокруг '='. посмотри как у тебя оно выше написано
            Convert(stringValueInt);
        }

        private static string PrintValue(int i) // TODO VS: метод сделан правильно, но название плохое - метод же ничего не печатает
        {
            return i.ToString();
        }

        // TODO VS: этот мтод лучше перенести низ, после метода Convert, который его вызывает.  Код по возможности читается сверху вниз.
		private static void PrintStringValue(int parseValueItn, string stringValue) // TODO VS: опечатка в названии параметра "parseValueItn", исправить
        {
            Console.WriteLine(string.Format("Значение определенного типа {0} строка {1}", parseValueItn, stringValue));
        }

        private static void Convert(string inString) // TODO VS: опять же неудачное название метода
        {
            PrintStringValue(int.Parse(inString), inString);        
        }
    }
}

 // TODO VS: Общие замечания.  Требовалось сделать перевод в строку и парсинг для всех  типов, использованных в  предыдущей задаче, не только для int.