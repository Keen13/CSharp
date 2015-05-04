using System;

namespace Startup  
{
    public class Program 
    {
        public static void Main()
        {
            var expression = new Calculator(); 
            expression.ExecuteCalculator();
  
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
