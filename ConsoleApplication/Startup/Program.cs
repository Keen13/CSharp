﻿using System;
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
            Block1 arg1 = new Block1();
            arg1.ExecuteBlock1();

            Block2 arg = new Block2(); 
            arg.ExecuteBlock2();
  
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    public class Block1
    {
        private const string constStringPrint = "Value = ";
        
        public void ExecuteBlock1()
        {
            int i = 10;
            bool b = true;
            char ch = 'C';
            decimal d = 123.45m;
            double db = 99.44;
            string s = "end";

            PrintValue(i);
            PrintValue(b);
            PrintValue(ch);
            PrintValue(d);
            PrintValue(db);
            PrintValue(s);
        }

        private static void PrintValue(int i)
        {
            Console.WriteLine(constStringPrint + i);
        }

        private static void PrintValue(bool b)
        {
            Console.WriteLine(constStringPrint + b);
        }

        private static void PrintValue(char ch)
        {
            Console.WriteLine(constStringPrint + ch);
        }

        private static void PrintValue(decimal d)
        {
            Console.WriteLine(constStringPrint + d);
        }

        private static void PrintValue(double db)
        {
            Console.WriteLine(constStringPrint + db);
        }

        private static void PrintValue(string s)
        {
            Console.WriteLine(constStringPrint + s);
        }
    } 
    
    public class Block2
    {
        public void ExecuteBlock2()
        {       
            Console.WriteLine("Bloсk 2:");
            string[] inString = new string[6];
            inString[0] = "123";
            inString[1] = "true";
            inString[2] = "C";
            inString[3] = "123,45";
            inString[4] = "99,12";
            inString[5] = "end";
            Convert(inString); 
        }

        private static void Convert(string[] inString) 
        {                       
            PrintStringValue(inString[0]); 
            PrintValue(int.Parse(inString[0]));

            PrintStringValue(inString[1]); 
            PrintValue(bool.Parse(inString[1]));

            PrintStringValue(inString[2]); 
            PrintValue(char.Parse(inString[2]));

            PrintStringValue(inString[3]); 
            PrintValue(decimal.Parse(inString[3]));

            PrintStringValue(inString[4]); 
            PrintValue(double.Parse(inString[4]));

            PrintStringValue(inString[5]); 
            PrintValue(inString[5]);        
        }

        private static void PrintStringValue(string stringValue)
        {
            Console.WriteLine("Value = " + stringValue);
        }
                
        private static void PrintValue(int i)
        {
           PrintStringParseValue(i.ToString());
        }

        private static void PrintValue(bool b)
        {
            PrintStringParseValue(b.ToString());
        }

        private static void PrintValue(char ch)
        {
            PrintStringParseValue(ch.ToString());
        }

        private static void PrintValue(decimal d)
        {
            PrintStringParseValue(d.ToString());
        }

        private static void PrintValue(double db)
        {
            PrintStringParseValue(db.ToString());
        }

        private static void PrintValue(string s)
        {
            PrintStringParseValue(s);
        }
        
        private static void PrintStringParseValue(string stringParse)
        {
            Console.WriteLine("Value Parse = " + stringParse);
        }
    }
}