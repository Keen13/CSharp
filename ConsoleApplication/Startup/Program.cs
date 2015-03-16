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
			// TODO VS: Используй пустые строки, чтобы разбить  код на  логически связанные блоки. Ты сказал,  не любишь фарш из кода, и это хорошо.   
			// TODO VS: Сплошная простыня из кода это другой пример плохого структурирования. 
			// TODO VS: Как на какие куски разбить  код решай сам,  потом обсудим, если получится криво.  Один блок вполне может состоять и из одной строки,
			// TODO VS: если она  логически отделена от  соседних. И кстати,  возможен другой порядок строк.
            string s1 = "Bu-ga-ga"; // TODO VS: старый код можешь удалить. Если тебе потом он вдруг понадобится,  напишешь снова.
            string s2 = "Metod 2:  ";// TODO VS: старый код можешь удалить
            Method1(s1);// TODO VS: старый код можешь удалить
            Method2(s2, 13, 13);// TODO VS: старый код можешь удалить
            int i = 10;
            PrintValue(i);
            bool b = true;
            PrintValue(b);
            char ch = 'C';
            PrintValue(ch);
            decimal d = 123.45m;
            PrintValue(d);
            double db = 99.44;
            PrintValue(db);
            string s = "end";
            PrintValue(s);
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

        private static void PrintValue(int i)
        {
            Console.WriteLine("Value = " + i);   
        }

        private static void PrintValue(bool b)
        {
            Console.WriteLine("Value = " + b);
        }

        private static void PrintValue(Char ch) // TODO VS [CG 1]
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
// TODO VS:  Ненужная пустая строка. Между фигурными скобками, закрывающими блоки разного уровня, строка не нужна [coding guidelines]
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
