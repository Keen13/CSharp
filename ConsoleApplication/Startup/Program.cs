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
            Blok1();  //TODO VS: правильно пишется Block - исправь
            
            Program2 arg = new Program2(); // TODO VS: см. [1] внизу
            arg.Blok2();  //TODO VS: правильно пишется Block - исправь

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
    } // TODO VS:  После закрывающей фигурной скобки должна быть пустая строка
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

        private static void Conversion(string[] inString) // TODO VS: Conversion это плохое имя, т.к. это существительное. Может лучше Convert?
        {                       
            Console.WriteLine("Value = " + inString[0]); // TODO VS: см  [2] внизу
            PrintValue(int.Parse(inString[0]));

            Console.WriteLine("Value = " + inString[1]); // TODO VS: см  [2] внизу
            PrintValue(bool.Parse(inString[1]));

            Console.WriteLine("Value = " + inString[2]); // TODO VS: см  [2] внизу
            char ch = char.Parse(inString[2]);
            PrintValue(ch);

            Console.WriteLine("Value = " + inString[3]); // TODO VS: см  [2] внизу
            decimal d = decimal.Parse(inString[3]);
            PrintValue(d);

            Console.WriteLine("Value = " + inString[4]); // TODO VS: см  [2] внизу
            double db = double.Parse(inString[4]);
            PrintValue(db);

            Console.WriteLine("Value = " + inString[5]); // TODO VS: см  [2] внизу
            PrintValue(inString[5]);        
        }
                
        private static void PrintValue(int i)
        {
            Console.WriteLine("Parse Value = " + i); // TODO VS: см  [3] внизу
        }

        private static void PrintValue(bool b)
        {
            Console.WriteLine("Parse Value = " + b); // TODO VS: см  [3] внизу
        }

        private static void PrintValue(char ch)
        {
            Console.WriteLine("Parse Value = " + ch); // TODO VS: см  [3] внизу
        }

        private static void PrintValue(decimal d)
        {
            Console.WriteLine("Parse Value = " + d); // TODO VS: см  [3] внизу
        }

        private static void PrintValue(double db)
        {
            Console.WriteLine("Parse Value = " + db); // TODO VS: см  [3] внизу
        }

        private static void PrintValue(string s)
        {
            Console.WriteLine("Parse Value = " + s); // TODO VS: см  [3] внизу
        }
    }
}

// TODO VS: [1] Такое разбиение на логические куски уже хорошо, но можно сделать еще лучше. У тебя есть два варианта
// TODO VS:
// TODO VS: Вариант 1) Обрати внимание, что класс Program2 выполняет блок 2, а Program заключает в себе блок 1 и исполнение 
// TODO VS: основного  метода программы. То есть имеет две ответственности. Раз уж ты решил вынести блок 2 в отдельный класс,
// TODO VS: стоит  идти до конца и выделить блок 1 тоже в отдельный класс. Таким образом у тебя будет три класса - один 
// TODO VS: отвечает за исполнение программы, два за два независимых блока этой программы. 
// TODO VS: Если ты выберешь зтот путь, то  учти, что называть  два вспомогательных блока Program1 и Program2 будет неправильно
// TODO VS: (оно и сейчас неправильно, вообще), т.к. программа то у тебя одна. Имена должны соответствовать смыслу того,
// TODO VS: за что отвечает или что описывает собой класс. Как и имена методов.  Хорошим вариантом будет назвать классы
// TODO VS: Block1 и Block2, а их основной метод, который  ты будешь вызывать  снаружи, назвать Execute.
// TODO VS:
// TODO VS: Вариант 2) Как я уже упоминал, создавать класс для  выделения такой функциональности как блок 1 и блок 2 это допустимо, но 
// TODO VS: многовато, можно обойтись методом. То есть выделить блок 2 в метод внутри основой  программы точно так же, как ты выделил
// TODO VS: в метод блок 1. 
// TODO VS: Если ты выберешь этот путь,  то обрати внимание на правильное именование методов.  Метод - это  всегда какое-то действие,
// TODO VS: поэтому название метода должно описыать действие. То есть быть глаголом либо сочетанием слов, где глагол главный, например:
// TODO VS: Execute (Исполнить), ExecuteBlock1 (ИсполнитьБлок1), CalculatePaymentComission (ПосчитатьКомисииюЗаПлатеж) и в том же духе.
// TODO VS: Названия ExecuteBlock1 и ExecuteBlock2 неплохо подойдут. (С методом Main ничего не поделать, к сожалению, это имя жестко задано)
// TODO VS: 
// TODO VS: Чем подходы отличаются друг от друга - расскажу,  после того как сделаешь. И обрати внимание, что какой бы подход ты не выбрал,
// TODO VS: одинаковые по смыслу куски функциональности у тебя будет находиться на одном уровне иерархии - или оба как вспомогательные методы,
// TODO VS: либо оба как вспомогательные классы.

// TODO VS: [2] Указания к подзадаче 7.  Методы нужны не только, чтобы просто выделять в них логические куски кода, но и чтобы выделять в них куски
// TODO VS: _повторяющегося кода_,  чтобы не писать его несколько раз. Наглядную пользу от этого я покажу, как сделаешь  поздадачу 7. А пока обрати
// TODO VS: внимание, что у тебя шесть раз повторяется  одна и та же строка
// TODO VS: Console.WriteLine("Value = " + inString[0]);
// TODO VS: Console.WriteLine("Value = " + inString[1]);
// TODO VS: Console.WriteLine("Value = " + inString[2]);
// TODO VS: Console.WriteLine("Value = " + inString[3]);
// TODO VS: Console.WriteLine("Value = " + inString[4]);
// TODO VS: Console.WriteLine("Value = " + inString[5]);
// TODO VS: Понятно, что строка повторяется не  буквально, но если посмотреть чуть выше деталей (программирование это в том числе умение отделять детали
// TODO VS: от абстракций), то у тебя 6 раз написано 
// TODO VS: Console.WriteLine("Value = " + какая-то строка);
// TODO VS: Именно этот кусок и заслуживает выделения в отдельный метод, вроде
// TODO VS: private void PrintStringValue(string stringValue)
// TODO VS: {
// TODO VS:     Console.WriteLine("Value = " + stringValue);
// TODO VS: }
// TODO VS: и вызов в стиле
// TODO VS: PrintStringValue(inString[0]);
// TODO VS: PrintStringValue(inString[1]);
// TODO VS: PrintStringValue(inString[2]);
// TODO VS: PrintStringValue(inString[3]);
// TODO VS: PrintStringValue(inString[4]);
// TODO VS: PrintStringValue(inString[5]);

// TODO VS: [3] Указания к подзадаче 7. После пункта [2] выделить повторяющуюся функциональность здесь тебе будет просто =)