using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup  
{
    public class Program2
    {
        public void Conversion(string[] SS)
        {
            int i = int.Parse(SS[0]);
            PrintValue(i);
            
            bool b = bool.Parse(SS[1]);
            PrintValue(b);
            
            char ch = char.Parse(SS[2]);  
            PrintValue(ch);
            
            decimal d = decimal.Parse(SS[3]);  
            PrintValue(d);
            
            double db = double.Parse(SS[4]); 
            PrintValue(db);            
            
            PrintValue(SS[5]);
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
            decimal d1 = 123.45m;
            if (d == d1)
                {
                    Console.WriteLine("decimal OK!!!");
                }
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

    public class Program   
    {
        public static void Main()
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
            
            Console.WriteLine("Blok 2:");
            string[] SS = new string[6];
            SS[0] = "123";
            SS[1] = "true";
            SS[2] = "C";
            SS[3] = "123,45";
            SS[4] = "99,12";
            SS[5] = "end";
            Program2 arg = new Program2();
            arg.Conversion(SS); 

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
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
}

// TODO VS: [CG 1] для встроенных типов C# есть два способа  объявлять их тип - один через имя типа, другой через  соответствующее ему кодовое имя (см таблицу).
// TODO VS: Всегда используй для встроенных типов кодовое имя (имена чувствительны  к регистру). Сейчас ты их используешь вперемешку (сам того не замечая)
// TODO VS: 	Имя типа		Кодовое имя
// TODO VS:		Int32			int
// TODO VS:		Int16			short
// TODO VS:		Int64			long
// TODO VS:		Boolean			bool	
// TODO VS:		Char			char
// TODO VS:		Decimal			decimal	
// TODO VS:		String			string
// TODO VS:		Double			double
