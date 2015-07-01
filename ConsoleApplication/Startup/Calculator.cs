using System.Collections.Generic;

namespace Startup
{
    public class Calculator 
    {
        private const char PlusSymbol = '+';
        private const char MinusSymbol = '-';

        // TODO VS: Неиспользуемый метод.  ты его с какой-то целью оставил? и название Sum1  в любом случае плохое, т.к. неинформативное.
        // ---- VS: хотя бы назвал SumOld
        // TODO VS: Ну и вообще,  удали весь неиспользуемый код
        public static int Sum1(string inString)
        {
            if (inString == null)
            {
                inString = string.Empty;
            }
            
            var massInt = ParseStringToInt(SplitArguments(inString));
            var massSign = MassSign(inString); 
            var sum = massInt[0];
            
            for (var i = 0; i < massInt.Length; i++) 
            {
                switch (massSign[i])
                {
                    case PlusSymbol:
                        sum = sum + massInt[i + 1];
                        break;
                    case MinusSymbol:
                        sum = sum - massInt[i + 1];
                        break;
                }
            }

            return sum;
        }

        public static int Sum(string inString)
        {
            inString = inString ?? string.Empty;
            var findSymbol = new[] { PlusSymbol, MinusSymbol }; // TODO VS: что должно значить название переменной findSymbol? раньше было более понятное separator
            var numberStringItem = inString.IndexOfAny(findSymbol); // TODO VS: неинформативное имя переменной numberStringItem
            var z = numberStringItem + 1; // TODO VS: z это совсем плохое имя, не говорит о смысле переменной ничего 

            // TODO VS: если это закомментировано для  рабочих целей - то пока нормально. но вообще комментированный код оставлять не надо
            // ---- VS: он только засоряет все остальное. если код не нужен - его надо удалить.
            //if (numberStringItem == 0)
            //{
            //    z = numberStringItem;
            //}
           
            if (numberStringItem == -1)
            {
                return ParseOneValueInt(inString);
            }

            if (inString[numberStringItem] == PlusSymbol)
            {
                var sum = ParseOneValueInt(inString.Substring(0, numberStringItem)); // TODO VS: дублирующийся код
                return sum + Sum(inString.Remove(0, z));
            }
            else
            {
                var sum = ParseOneValueInt(inString.Substring(0, numberStringItem));
                return sum - Sum(inString.Remove(0, z));
            }
        }

        private static string[] SplitArguments(string inString)
        {
            char[] separator = { PlusSymbol, MinusSymbol };
            var massString = inString.Split(separator);
            return massString;
        }

        private static char[] MassSign(string inString)
        {
            var numberSign = FindNumberSignPlusOne(inString);
            var massSign = new char[numberSign];
            var massSignNumber = 0;

            foreach (var symbol in inString)
            {
                if (symbol == MinusSymbol)
                {
                    massSign[massSignNumber] = MinusSymbol;
                    massSignNumber = massSignNumber + 1;
                }

                if (symbol == PlusSymbol)
                {
                    massSign[massSignNumber] = PlusSymbol;
                    massSignNumber = massSignNumber + 1;
                }
            }

            return massSign;
        }
        
        private static int FindNumberSignPlusOne(string inString)  //не нашел ничего уменее как свести массивы к одной длинне таким вот способом.
            // VS: ну тоже подход, нашел ведь его.  доведи до ума, потом будет тебе другая идея.
        {
            var i = 0; 
            var numberIndex = -1; 
            var amountSymbol = 0;
            var findSymbols = new[] { PlusSymbol, MinusSymbol }; 

            while (i != -1)
            {
                i = inString.IndexOfAny(findSymbols, numberIndex + 1);
                numberIndex = i;
                amountSymbol++;
            }

            return amountSymbol;
        }

        private static int[] ParseStringToInt(IList<string> inString) 
        {
            var intParse = new int[inString.Count];

            for (var i = 0; i < inString.Count; i++) 
            {
                intParse[i] = ParseOneValueInt(inString[i]); 
            }

            return intParse;
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