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
            var parseAnysengValue = new Block2(); // TODO VS:  did you mean "Anything" ?
            // TODO VS: если так, то 'anything' означает "что угодно", 'any' означает "любой, какой угодно,
            // TODO VS: вероятно, название parseAnyValue подойдет лучше по смыслу - "парситьЛюбоеЗначение"
            // TODO VS: но оно  тоже звучит не очень, т.к.  это название переменной,  оно должно быть  выражено существительным
            // TODO VS: как насчет anyValueParser? ("парсерЛюбыхЗначений")
            parseAnysengValue.ExecuteBlock2();
  
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    
    public class Block2
    {
        public void ExecuteBlock2()
        {       
            Console.WriteLine("Bloсk 2:");

            var valueBool = true;
            var valueChar = 'C';
            var valueDecimal = 150.99m;
            var valueDouble = 444.44;
            var valueInt1 = 32;
            var valueString = "end!!!";
            var valueInt2 = 6;
            var valueInt3 = 140;
            var testString = "4.12";
            
            var stringValue = new string[5]; 
            stringValue[0] = ParseToString(valueBool);
            stringValue[1] = ParseToString(valueChar);
            stringValue[2] = ParseToString(valueDecimal);
            stringValue[3] = ParseToString(valueDouble);
            stringValue[4] = ParseToString(valueString);

            var arbitraryString = "-3,5,abc,42,99.99,true,150"; 
            var stringValueInt = new string[4]; 
            stringValueInt[0] = ParseToString(valueInt1);
            stringValueInt[1] = ParseToString(valueInt2);
            stringValueInt[2] = ParseToString(valueInt3);
            stringValueInt[3] = testString;
            string[] splitArguments = SplitArguments(arbitraryString); //TODO VS: use 'var'

            PrintStringValue(ParseStringToInt(stringValueInt), stringValueInt);
            PrintStringValue(ParseStringToInt(splitArguments), splitArguments);

            PrintStringValue(ParseStringToBool(stringValue[0]), stringValue[0]);
            PrintStringValue(ParseStringToChar(stringValue[1]), stringValue[1]);
            PrintStringValue(ParseStringToDecimal(stringValue[2]), stringValue[2]);
            PrintStringValue(ParseStringToDouble(stringValue[3]), stringValue[3]);
            PrintStringValue(ParseStringToString(stringValue[4]), stringValue[4]);
        }

        private static string ParseToString(bool b) 
        {
            return b.ToString();
        }

        private static string ParseToString(char ch)
        {
            return ch.ToString();
        }

        private static string ParseToString(decimal d)
        {
            return d.ToString();
        }

        private static string ParseToString(double db)
        {
            return db.ToString();
        }

        private static string ParseToString(int i)
        {
            return string.Format("{0:000}", i);
        }
        
        private static string ParseToString(string s)
        {
            return s;
        }

        private static bool ParseStringToBool(string inString)
        {
            return bool.Parse(inString);
        }

        private static char ParseStringToChar(string inString)
        {
            return char.Parse(inString);
        }

        private static decimal ParseStringToDecimal(string inString)
        {
            return decimal.Parse(inString);
        }

        private static double ParseStringToDouble(string inString)
        {
            return double.Parse(inString);
        }

        private static string[] SplitArguments(string inString) 
        {
            const char separator = ','; 
            var massString = inString.Split(separator); 
            return massString;
        }

        private static int ParseOneValueInt(string inString) //TODO VS: методы ParseOneValueInt и ParseStringToInt должны идти в другом порядке.
        // TODO VS: код читается сверху вниз
        {
            int intParse;
            bool result; //TODO VS: Нет никаких причин разделять тут объявление переменой и присвоение. как минимум их надо объединить
            result = int.TryParse(inString, out intParse); 
            //TODO VS: еще лучше будет написать  if (int.TryParse(inString, out intParse)) , это стандартная запись. переменная result вообще не нужна
            if (result)
            {
                if (intParse < 10)
                {
                    intParse = 10; //TODO VS: код написан  корректно, но на самом деле тебе нет необходимости присваивать значение переменной, ты ведь
                    //TODO VS:  с этой переменной потом ничего не делаешь, кроме возврата.  используй return сразу там, где становится ясно, что вернуть.
                }

                if (intParse > 100)
                {
                    intParse = 100;
                }
            }
            else
            {
                intParse = -1;
            }

            return intParse;
        } //TODO VS: обрати внимание, что в этом методе у тебя присутствует кусок логики, являющейся  самостоятельной функциональностью. 
          //TODO VS: вынеси его в отдельный метод, если понятно, что выносить [принцип единственной ответственности]
       
        private static int[] ParseStringToInt(string[] inString)
        {
            var intParse = new int[inString.Length];

            for (int i = 0; i < inString.Length; i++) //TODO VS: for (var i = 0; i < inString.Length; i++) - так var тоже используется, практически всегда
            {
                intParse[i] = ParseOneValueInt(inString[i]); 
            }

            return intParse;
        }

        private static string ParseStringToString(string inString)
        {
            return inString;
        }         
        
        private static void PrintStringValue(bool parseValue, string stringValue) 
        {
            Console.WriteLine(string.Format("Значение определенного типа {0} строка {1}", parseValue, stringValue));
        }
        
        private static void PrintStringValue(char parseValue, string stringValue)
        {
            Console.WriteLine(string.Format("Значение определенного типа {0} строка {1}", parseValue, stringValue));
        }

        private static void PrintStringValue(decimal parseValue, string stringValue)
        {
            Console.WriteLine(string.Format("Значение определенного типа {0} строка {1}", parseValue, stringValue));
        }

        private static void PrintStringValue(double parseValue, string stringValue)
        {
            Console.WriteLine(string.Format("Значение определенного типа {0} строка {1}", parseValue, stringValue));
        }

        private static void PrintStringValue(int[] parseValue, string[] stringValue) //TODO VS: см комментарий [1] внизу
        {
            char separator = ','; // TODO VS: use 'const' instead of variable
            string stringWriteInt = ""; // TODO VS: [CG 1] + use 'var'
            string stringWriteStr = ""; // TODO VS: [CG 1] + use 'var'

            for (int i = 0; i < parseValue.Length; i++)  // TODO VS: use var
            {
                stringWriteInt = string.Concat(stringWriteInt, separator, parseValue[i]);
                stringWriteStr = string.Concat(stringWriteStr, separator, stringValue[i]);
            }

            stringWriteInt = stringWriteInt.Remove(0, 1); 
            stringWriteStr = stringWriteStr.Remove(0, 1);
            Console.WriteLine(string.Format("Значение типа int {0} строка {1}", stringWriteInt, stringWriteStr));
        }

        private static void PrintStringValue(string parseValue, string stringValue)
        {
            Console.WriteLine(string.Format("Значение определенного типа {0} строка {1}", parseValue, stringValue));
        }
    }
}

// TODO VS: [CG 1] Правила оформления кода - всегда используй для пустой строки константу string.Empty, встроенную в
// TODO VS: класс string, никогда не пиши пустую строку явно.


//TODO VS: Задача вывести все одной строкой сделана, однако реализация плохая.  Проблемы три (плюс по мелочам...)
//TODO VS:
//TODO VS: 1) Ты в цикле обновляешь строку, дописывая к ней что-то еще. Вспомни, что string это _неизменяемый_ тип, то есть 
//TODO VS: каждый  раз, когда вызывается  
//TODO VS: stringWriteInt = string.Concat(stringWriteInt, separator, parseValue[i]);
//TODO VS: реально создается новый объект. А если у тебя  цикла не на  10 значений, а на сотни и тысячи? А если каждая новая строка 
//TODO VS: отличается от предыдущей  не на  2-3 символа, а на несколько строк?  Привет утечке памяти... 
//TODO VS: Это одно из правил хорошего программирования - избегать дописывания или модификации строк в любых блоках программы,
//TODO VS: которые вызываются часто. Циклы это типичный пример.
//TODO VS: 
//TODO VS: 2) Эту проблему заметить сложнее, чем  первую - про поведение строк в цикле знает любой, кто прочитал  про это, ты вот 
//TODO VS: теперь тоже будешь знать - но потенциально она серьезнее. Обрати внимание на этот код
//TODO VS:            for (int i = 0; i < parseValue.Length; i++)
//TODO VS:            {
//TODO VS:                stringWriteInt = string.Concat(stringWriteInt, separator, parseValue[i]);
//TODO VS:                stringWriteStr = string.Concat(stringWriteStr, separator, stringValue[i]);
//TODO VS:            }
//TODO VS: Здесь ты идешь по циклу ограниченому длиной  однойго массива, а перебираешь два. То есть, ты  неявно делаешь предположение, 
//TODO VS: что размеры массивов совпадают, чего тебе никто не гарантирует. Мало ли, что можно передать на вход методу,а использовать его
//TODO VS: может и совершенно другой код, и даже ты, забывшйи про детали реализации  через пару месяцев. Если  размеры массивов не
//TODO VS: совпадут, ты либо потеряешь часть значений, либо получишь исключение.
//TODO VS: 
//TODO VS: 3) После того, как строка сформирована, тебе приходится делать дополнительное действие, обрезая с начала запятую
//TODO VS: stringWriteInt = stringWriteInt.Remove(0, 1);
//TODO VS: Это признак  неудачного  алгоритма формирования строки.
//TODO VS:
//TODO VS: Теперь всякие мелочи, которые полезно знать
//TODO VS:
//TODO VS: 4)  stringWriteInt = string.Concat(stringWriteInt, separator, parseValue[i]);
//TODO VS: Тот же результат ты получишь, просто сложив строки 
//TODO VS: stringWriteInt = stringWriteInt + separator + parseValue[i];
//TODO VS: Второе читается проще. По производительности это то же самое. Случаи, когда использование string.Concat предпочтительно,
//TODO VS: редки (ну разве что так принято в определенной команде), как правило это делают ради читаемости
//TODO VS:
//TODO VS: 5) stringWriteInt = stringWriteInt.Remove(0, 1);
//TODO VS: Смысл строки непонятен без предыдущео контекста. Видно, что  ты  обрезаешь  начальный символ, но что это  за символ, и
//TODO VS: чем он тебе помешал?.. В классе string есть  другой метод на такие случаи - Trim() и его варианты TrimStart(), TrimEnd()
//TODO VS: stringWriteInt = stringWriteInt.TrimStart(separator); 
//TODO VS: Такой вариант читается лучше - сразу понятно, что ты удаляешь разделительные символы в начале строки. Почитай, как 
//TODO VS: работают эти три метода.
//TODO VS: 
//TODO VS: 6) Console.WriteLine(string.Format("Значение типа int {0} строка {1}", stringWriteInt, stringWriteStr));
//TODO VS: А это пример хорошей идеи - сначала сформировать промежуточные строки, а потом использовать их для формирования большой строки =)
//TODO VS: Кстати,  по производительности string.Format хуже чем Concat() или +,  но его широко используют (кроме часто вызываемых блоков)
//TODO VS: за его хорошую читаемость и гибкость. 
//TODO VS: "Значение типа int " + stringWriteInt + " строка " + stringWriteStr;
//TODO VS: Такой вариант читается хуже, плюс легко потерять  пробелы на концах слов. И изменять его куда менее удобно, чем формат. А если 
//TODO VS: вспомнить, что в Format можно одну и ту же переменную  указывать несколько раз, например...
//TODO VS:  string.Format("Сумма в рублях {0:c0}, сумма с копейками {0:c}", 100.33m)
//TODO VS: В общем, если  нужно вставить  значения в шаблон строки - Format как раз для этого.
//TODO VS: 
//TODO VS: Ну и вопрос - а что же делать с циклом, который плох? Просто не использовать =)  Посмотри на метод String.Join() и его возможности.
