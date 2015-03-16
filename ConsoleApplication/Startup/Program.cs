using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup  
{
    public class Program2
    {
        /*public void Conversion(string s)
        {
            int i1 = Convert.ToInt32(s);
            PrintValue(i1); 
        }*/

        public void PrintValue(int i)
        {
           Console.WriteLine("Value = " + i);
        }

        public void PrintValue(bool b)
        {
            Console.WriteLine("Value = " + b);
        }

        public void PrintValue(char ch)
        {
            Console.WriteLine("Value = " + ch);
        }

        public void PrintValue(decimal d)
        {
            Console.WriteLine("Value = " + d);
        }

        public void PrintValue(double db)
        {
            Console.WriteLine("Value = " + db);
        }

        public void PrintValue(string s)
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
            string s2 = "12g3";
                        
            Program2 arg = new Program2();
            //arg.Conversion(s2); 
            arg.PrintValue(i);
            arg.PrintValue(b);
            arg.PrintValue(ch);
            arg.PrintValue(d);
            arg.PrintValue(db);
            arg.PrintValue(s);

            /*Type t = ch.GetType();
            Console.WriteLine(t.Name);
            */
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
