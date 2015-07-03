using System.Linq;

namespace Startup
{
    public class Calculator 
    {
        private const char PlusSymbol = '+';
        private const char MinusSymbol = '-';

        public static int Calculate(string expression)
        {
            expression = expression ?? string.Empty;
            var parts = expression.Split(PlusSymbol);
            var result = 0;

            foreach (var subtractionExpression in parts)
            {
                result += CalculateSubtractionExpression(subtractionExpression);
            }

            return result;
        }

        private static int CalculateSubtractionExpression(string subtractionExpression)
        {
            var parts = subtractionExpression.Split(MinusSymbol);
            var result = ParseOneValueInt(parts[0]);

            for (var i = 1; i < parts.Count(); i++)
            {
                result -= ParseOneValueInt(parts[i]);
            }

            return result;
        }

        private static int ParseOneValueInt(string inString)
        {
            int intParse;
            const int BaseValue = 0;

            return int.TryParse(inString, out intParse) ? AdjustInt(intParse) : BaseValue;
        }

        private static int AdjustInt(int intParse) 
        {
            const int MaxValue = 1000;
            const int MinValue = -1000;

            if (intParse < MinValue)  
            {
                return MinValue; 
            }

            if (intParse > MaxValue)
            {
                return MaxValue;
            } 

            return intParse;
        }
    }
}