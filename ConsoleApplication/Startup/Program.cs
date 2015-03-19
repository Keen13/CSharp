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
            Block1 arg1 = new Block1();
            arg1.ExecuteBlock1();

            Block2 arg = new Block2(); 
            arg.ExecuteBlock2();
  
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    public class Block1
    {
        public void ExecuteBlock1()
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

    } 
    public class Block2
    {
        public void ExecuteBlock2()
        {       
            Console.WriteLine("Bloсk 2:");
            string[] inString = new string[6];
            inString[0] = "123";
            inString[1] = "true";
            inString[2] = "C";
            inString[3] = "123,45";
            inString[4] = "99,12";
            inString[5] = "end";
            Convert(inString); 
        }

        private static void Convert(string[] inString) 
        {                       
            PrintStringValue(inString[0]); 
            PrintValue(int.Parse(inString[0]));

            PrintStringValue(inString[1]); 
            PrintValue(bool.Parse(inString[1]));

            PrintStringValue(inString[2]); 
            char ch = char.Parse(inString[2]);
            PrintValue(ch);

            PrintStringValue(inString[3]); 
            decimal d = decimal.Parse(inString[3]);
            PrintValue(d);

            PrintStringValue(inString[4]); 
            double db = double.Parse(inString[4]);
            PrintValue(db);

            PrintStringValue(inString[5]); 
            PrintValue(inString[5]);        
        }

        private static void PrintStringValue(string stringValue)
        {
            Console.WriteLine("Value = " + stringValue);
        }
                
        private static void PrintValue(int i)
        {
            string s = i.ToString();
            PrintStringParseValue(s);
        }

        private static void PrintValue(bool b)
        {
            string s = b.ToString();
            PrintStringParseValue(s);
        }

        private static void PrintValue(char ch)
        {
            string s = ch.ToString();
            PrintStringParseValue(s);
        }

        private static void PrintValue(decimal d)
        {
            string s = d.ToString();
            PrintStringParseValue(s);
        }

        private static void PrintValue(double db)
        {
            string s = db.ToString();
            PrintStringParseValue(s);
        }

        private static void PrintValue(string s)
        {
            PrintStringParseValue(s);
        }
        
        private static void PrintStringParseValue(string stringParse)
        {
            Console.WriteLine("Value Parse = " + stringParse);
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