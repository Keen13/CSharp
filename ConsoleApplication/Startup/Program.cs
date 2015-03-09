using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO VS: верни объявление пространства имен, и назови его как-нибудь по-умному. учти, что имя должно быть с большой буквы, и не содержать подчеркиваний
//namespace task_1  //вот это обязательно?  
//{
    class Program  // в с# объезательно нужно создавайть класс? 
    {
        // TODO VS: настрой в студии, чтобы  форматирование делалось пробелами, а не табуляцией.тогда при нажатии Tab студия будет сам ставить нужное число пробелов.
        // TODO VS: надо 4 пробела (имхо это значение по умолчанию)
        static void Main() // TODO VS: у метода обязательно должен быть  модификатор доступа
        {
        Console.WriteLine("Press any key to exit."); // TODO VS: тело метода должно быть смещено на 1 отступ относительно открывающей и закобывающей скобки
        Console.ReadKey();
        }
    }
//}

// я тут кучу всего оставил для примера. чтоб было понятно откуда я чего взял. 
//мне непонятно что такое классы, и я неумею с ними работать. 
//разобрал пример ниже, я пимерно понял что они делают, но это часный случай...
// не все понятно. хотелось бы коменты к каждой строчке.

    /*public class Person
    {
        // Field
        public string name;  // создание строковой переменной

        // Constructor that takes no arguments.
        public Person()           // что это делает? если вызывает процедуру(класс) без параметров то выводит знавение unknown?
        {
            name = "unknown";    // присваиваем переменной значение  
        }

        // Constructor that takes one argument.
        public Person(string nm) //если вызываем с со строковым параметном то возвращает его
        {
            name = nm;
        }

        // Method
        public void SetName(string newName)  //то-же что и предыддущей... в чем отличие?
        {
            name = newName;
        }
    }
    class TestPerson
    {
        static void Main()
        {
            // Call the constructor that has no parameters.
            Person person1 = new Person();    //создаем ссылку на объект
            Console.WriteLine(person1.name);  // так как объект созда без параметров выводим unknown

            person1.SetName("John Smith");  // вызываем созданный объект используя метод void SetName с параметром John Smith
            Console.WriteLine(person1.name); // получем John Smith

            // Call the constructor that has one parameter.
            Person person2 = new Person("Sarah Jones"); // создаем ссылку на обект с параметром Sarah Jones
            Console.WriteLine(person2.name);              // выводим Sarah Jones

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    // Output:
    // unknown
    // John Smith
    // Sarah Jones */