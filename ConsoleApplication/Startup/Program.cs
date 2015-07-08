using System;

namespace Startup  
{
    public class Program 
    {
        public static void Main()
        {
            var expression = new Interface(); 
            expression.ExecuteCalculator();
  
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
