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
            Blok1();
            
            Program2 arg = new Program2();
            arg.Blok2(); 

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void Blok1()
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
    }
    public class Program2
    {
        public void Blok2()
        {
            Console.WriteLine("Bloсk 2:");
            string[] inString = new string[6];
            inString[0] = "123";
            inString[1] = "true";
            inString[2] = "C";
            inString[3] = "123,45";
            inString[4] = "99,12";
            inString[5] = "end";
            Conversion(inString); 
        }

        private static void Conversion(string[] inString) 
        {                       
            Console.WriteLine("Value = " + inString[0]);          
            PrintValue(int.Parse(inString[0]));

            Console.WriteLine("Value = " + inString[1]);
            PrintValue(bool.Parse(inString[1]));

            Console.WriteLine("Value = " + inString[2]);
            char ch = char.Parse(inString[2]);
            PrintValue(ch);

            Console.WriteLine("Value = " + inString[3]);
            decimal d = decimal.Parse(inString[3]);
            PrintValue(d);

            Console.WriteLine("Value = " + inString[4]);
            double db = double.Parse(inString[4]);
            PrintValue(db);

            Console.WriteLine("Value = " + inString[5]);
            PrintValue(inString[5]);        
        }
                
        private static void PrintValue(int i)
        {
            Console.WriteLine("Parse Value = " + i);
        }

        private static void PrintValue(bool b)
        {
            Console.WriteLine("Parse Value = " + b);
        }

        private static void PrintValue(char ch)
        {
            Console.WriteLine("Parse Value = " + ch);
        }

        private static void PrintValue(decimal d)
        {
            Console.WriteLine("Parse Value = " + d);
        }

        private static void PrintValue(double db)
        {
            Console.WriteLine("Parse Value = " + db);
        }

        private static void PrintValue(string s)
        {
            Console.WriteLine("Parse Value = " + s);
        }
    }
}

// TODO VS: Вообще, разбиение программы на два куска можно сделать намного лучше. Попробуй сначала придумать сам - посмотри на классы  Program1 и Program2,
// TODO VS: чем они отличаются, чем похожи, и как можно сделать их более похожими и улучшить логическую организацию всей программы.
