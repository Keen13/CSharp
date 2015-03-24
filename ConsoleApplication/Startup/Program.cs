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
            string stringInt=PrintValue(valueInt);
            Convert(stringInt);
        }

        private static string PrintValue(int i)
        {
            PrintStringValue(i.ToString());
            return i.ToString();
        }

        private static void PrintStringValue(string stringValue)
        {
            Console.WriteLine("Value = " + stringValue);
        }

        private static void Convert(string inString) 
        {
            PrintValue(int.Parse(inString));        
        }
    }
}
