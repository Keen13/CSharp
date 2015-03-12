using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup  
{
    public class Program   
    {
        public static void Main()  // TODO VS: [CG 2] 
        {
            Program s = new Program();// TODO VS: ?
            string s1;
            string s2;
            s1 = "Bu-ga-ga"; // TODO VS: ?
            s2 = "Metod 2:  ";// TODO VS: ?
            s.Method1(s1);
            s.Method2(s2, 13, 13);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        
        private void Method1(string s) // TODO VS: [CG 2]
        {            
            Console.WriteLine(s);            
        } 
        
        private void Method2(string q1, int a, int b) // TODO VS: [CG 2] 
        {
            string q = Convert.ToString(a * b); // TODO VS:  ?
            string q2 = q1 + q;
            Program s = new Program();            // TODO VS: ?
            s.Method1(q2);            
        }      
    }
}

// TODO VS: замечания по  оформлению кода я буду писать кратко  на строке в виде [CG 1] (coding guidelines, то есть правила написания кода, и номер в ссылке снизу),
// TODO VS:которую нужно испраить, а подробное описание будет внизу.

// TODO VS: [CG 1] пустые строки используются  для  логического разделения  кода на куски, это  нормально.  но две пустые строки подряд идти не должны - только одна
// TODO VS: [CG 2] старайся размещать  методы в том порядке, как они вызываются, чтобы код читался сверху вниз. это не старые языки, где метод должен быть объявлен
// TODO VS: до его использования. в твоем случае хороший порядок будет: Main,  method2, method1 - так все методы, использованные на какой-то строке, раскрываются ниже
// TODO VS: [CG 3] Имя метода должно начинаться с заглавной. Если имя состоит из нескольких слов - каждое с заглавной, например: PrintString()
// TODO VS: Подчеркивания внутри имен не используются. Print_String() - неверно.
// TODO VS: [CG 4] методы отделяются  друг от друга  пустой строкой
// TODO VS: [CG 5] при написании списка, после разделительной запятой идет пробел. это верно и для списка параметров метода, и для списка переменных, передаваемых в метод
// TODO VS: [CG 6] знак операции между значениями отделяется пробелами с обеих сторон. ""string q2 = q1 + q;" - оформлено правильно. "a*b" - неправильно
// TODO VS: [CG 7] объявляй одну переменную на одной строке, даже если две переменные одного типа
