using System;
using PaymentSystemApi;

namespace Startup  
{
    public class Program 
    {
        public static void Main()
        {
            //var expression = new Interface(); 
            //expression.ExecuteCalculator();

            var expression = new PaymentInterface();
            expression.Run();
            
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
