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
            int valueInt = 32;            
            string stringValueInt=PrintValue(valueInt);
            Convert(stringValueInt);
        }

        private static string PrintValue(int i)
        {
            return i.ToString();
        }

        private static void PrintStringValue(int parseValueItn, string stringValue)
        {
            Console.WriteLine(string.Format("Значение определенного типа {0} строка {1}", parseValueItn, stringValue));
        }

        private static void Convert(string inString) 
        {
            PrintStringValue(int.Parse(inString), inString);        
        }
    }
}
