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

        // TODO VS: Проанализируй мою реализацию и сравни со своей,  чтобы у тебя было больше  идей, как что-то можно делать.
        public static int MySum(string inString)
        {
            char[] separator = { PlusSymbol, MinusSymbol };
            var parts = inString.Split(separator, 2);
            var firstPartValue = ParseOneValueInt(parts[0]);

            if (parts.Length == 1)
            {
                return firstPartValue;
            }

            var sign = inString[parts[0].Length];
            var isPlus = sign == PlusSymbol;
            return isPlus ? firstPartValue + MySum(parts[1]) : firstPartValue - MySum(parts[1]);
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