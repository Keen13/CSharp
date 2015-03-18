using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup  
{
	// TODO VS: поменяй  местами  class Program2 и class Program1. Код должен читаться сверху вниз, точка входа в приложение у тебя Program1,
	// TODO VS: Program2 вызывается из  Program1 - поэтому лучше  их расположить в другом порядке. Также см. примечание внизу.
	public class Program2
    {
        public void Conversion(string[] SS) // TODO VS: [CG] имена параметров, так же как и локальных переменных, должны быть в стиле Camel
		// TODO VS: То есть, начинаться с маленькой буквы, заглавной выделяются начала слов внутри имени,  подчеркивания не используются
		// TODO VS: Неправильыне примеры: Number, SomeString, some_string
		// TODO VS: Правильно: number, someString
		// TODO VS: А вообще, имена должны отражать смысл переменной или параметра. Вообще, это тоже обязательное требование к коду, 
		// TODO VS: но правильное именование это очень непростое дело, так что пока можно оставить. Но сам посмотри, насколько тебе
		// TODO VS: будет понятно читать код с невнятными переменными из одной-двух букв. А код всегда читается  на порядок чаще, 
		// TODO VS: чем пишется.
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
            decimal d1 = 123.45m; // TODO VS: а это тут зачем?? и проверка потом тоже пока не нужна
            if (d == d1)
                { // TODO VS: [CG] кстати, форматирование неверное. скобки должны стоять на том же уровне отсутпа, что и if (...), т.к. это все один оператор.
				  // TODO VS: А вот блок внутри скобок совершенно правильно сдвинут на один отступ от них
                    Console.WriteLine("decimal OK!!!");
                } // TODO VS: [CG]  И  закрывающая скобка должна отделяться от следующего за ней кода пустой строкой. 
				  // TODO VS: обрати внимание - от следующего за ней кода. если за ней идет другая закрывающая скобка,
				  // TODO VS: они не разделяются пустой строкой (см. например конец файла или конец класса)
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
            
            Console.WriteLine("Bloсk 2:");
            string[] SS = new string[6]; // TODO VS:  в подзадаче 3 сказано "Добавить во второй блок  код...", в не заменить =)
										 // TODO VS: то есть второй блок должен  и выводить разные значения, и парсить их + выводить распарсенное.
										 // TODO VS: Вторая часть у тебя уже есть...
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

// TODO VS: Вообще, разбиение программы на два куска можно сделать намного лучше. Попробуй сначала придумать сам - посмотри на классы  Program1 и Program2,
// TODO VS: чем они отличаются, чем похожи, и как можно сделать их более похожими и улучшить логическую организацию всей программы.
