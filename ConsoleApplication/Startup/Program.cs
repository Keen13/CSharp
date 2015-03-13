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
            string s1 = "Bu-ga-ga";
            string s2 = "Metod 2:  ";
            Method1(s1);
            Method2(s2, 13, 13);
            int i = 10;
            PrintInt(i);
            bool b = true;
            PrintBool(b);
            char ch = 'C';
            PrintChar(ch);
            decimal d = 123.45m;
            PrintDecimal(d);
            double db = 99.44;
            PrintDouble(db);
            string s = "end";
            PrintString(s);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        
        private static void Method1(string s)
        {            
            Console.WriteLine(s);            
        } 
        
        private static void Method2(string q1, int a, int b)
        {
            string q = (a * b).ToString();
            string q2 = q1 + q;
            Method1(q2);            
        }
        
        private static void PrintInt(int i)
        {
            Console.WriteLine("Value = " + i);   
        }

        private static void PrintBool(bool b)
        {
            Console.WriteLine("Value = " + b);
        }

        private static void PrintChar(Char ch)
        {
            Console.WriteLine("Value = " + ch);
        }

        private static void PrintDecimal(decimal d)
        {
            Console.WriteLine("Value = " + d);
        }

        private static void PrintDouble(double db)
        {
            Console.WriteLine("Value = " + db);
        }

        private static void PrintString(string s)
        {
            Console.WriteLine("Value = " + s);
        }

    }
}