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
    }
}