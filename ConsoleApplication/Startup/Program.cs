using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Startup  
{
    public class Program   
    {
        private void metod1(string s)
        {            
            Console.WriteLine(s);            
        }
        private void metod2(string q1,int a,int b)
        {
            string q = Convert.ToString(a*b);
            string q2 = q1 + q;
            Program s = new Program();            
            s.metod1(q2);            
        }
        public static void Main() 
        {
            Program s = new Program();
            string s1, s2;
            s1 = "Bu-ga-ga";
            s2 = "Metod 2:  ";
            s.metod1(s1);
            s.metod2(s2,13,13);
            Console.WriteLine("Press any key to exit."); 
            Console.ReadKey();
        }
    }
}
