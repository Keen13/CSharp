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
            Program s = new Program();// TODO VS: тебе нет необходимости  создавать новый экэемпляр типа Program. 
			// TODO VS: вспомни, что я рассказывал про статические  свойства и методы (static) и используй их
            string s1; // TODO VS: в C# не обязательно объявлять переменную на отдельной строке для ее использования.
			// TODO VS: иногда это требуется (это мы потом рассмотрим),  но в данном случае можно объединить объявление и использование на одной строке
			// TODO VS: то же самое касается s2
            string s2;
            s1 = "Bu-ga-ga";
            s2 = "Metod 2:  ";
            s.Method1(s1);
            s.Method2(s2, 13, 13);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        
        private void Method1(string s)
        {            
            Console.WriteLine(s);            
        } 
        
        private void Method2(string q1, int a, int b)
        {
            string q = Convert.ToString(a * b); // TODO VS: строку ты таким образом получишь, да, но "Convert" это слишком тяжелый метод для такой операции
			// TODO VS: найди самый простой  (он же самый распространенный) метод превращения числа в строку и используй его
            string q2 = q1 + q;
            Program s = new Program();   // TODO VS: опять же нет необходимости  создавать новый экэемпляр типа Program. 
            s.Method1(q2);            
        }      
    }
}