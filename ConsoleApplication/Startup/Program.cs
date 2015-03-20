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
            Console.WriteLine("Value = " + i);
        }

        private static void PrintValue(bool b)
        {
            Console.WriteLine("Value = " + b);
        }

        private static void PrintValue(char ch)
        {
            Console.WriteLine("Value = " + ch);
        }

        private static void PrintValue(decimal d)
        {
            Console.WriteLine("Value = " + d);
        }

        private static void PrintValue(double db)
        {
            Console.WriteLine("Value = " + db);
        }

        private static void PrintValue(string s)
        {
            Console.WriteLine("Value = " + s);
        }

    } // TODO VS:  тут должна быть пустая строка  между закрывающей скобкой и новым классом, а не   так, как ты поставил выше
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
            char ch = char.Parse(inString[2]);
            PrintValue(ch);

            PrintStringValue(inString[3]); 
            decimal d = decimal.Parse(inString[3]);
            PrintValue(d);

            PrintStringValue(inString[4]); 
            double db = double.Parse(inString[4]);
            PrintValue(db);

            PrintStringValue(inString[5]); 
            PrintValue(inString[5]);        
        }

        private static void PrintStringValue(string stringValue)
        {
            Console.WriteLine("Value = " + stringValue);
        }
                
        private static void PrintValue(int i)
        {
            string s = i.ToString(); // TODO VS: Можно просто написать PrintStringParseValue(i.ToString()),  т.к. выражение для аргумента метода простое
            PrintStringParseValue(s);
        }

        private static void PrintValue(bool b)
        {
            string s = b.ToString();
            PrintStringParseValue(s);
        }

        private static void PrintValue(char ch)
        {
            string s = ch.ToString();
            PrintStringParseValue(s);
        }

        private static void PrintValue(decimal d)
        {
            string s = d.ToString();
            PrintStringParseValue(s);
        }

        private static void PrintValue(double db)
        {
            string s = db.ToString();
            PrintStringParseValue(s);
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