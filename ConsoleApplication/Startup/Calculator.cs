namespace Startup
{
    public class Calculator 
    {
        private const char PlusSymbol = '+';
        private const char MinusSymbol = '-';

        public static int Sum(string inString)
        {
            inString = inString ?? string.Empty;
            var separator = new[] { PlusSymbol, MinusSymbol }; 
            var indexFindSymbol = inString.LastIndexOfAny(separator); 
            var positionSubstring = indexFindSymbol + 1; 
            var lengthString = inString.Length;
            var lengthSubstring = lengthString - positionSubstring;
            var sum = ParseOneValueInt(inString.Substring(positionSubstring, lengthSubstring));
            
            if (indexFindSymbol == -1)
            {
                return ParseOneValueInt(inString);
            }

            if (inString[indexFindSymbol] == MinusSymbol)
            {
                return Sum(inString.Remove(indexFindSymbol)) - sum;
            }

            return Sum(inString.Remove(indexFindSymbol)) + sum;
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