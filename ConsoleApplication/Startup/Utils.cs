namespace Startup
{
    public static class Utils
    {
        // NB! Не изменять этот метод.
        public static bool TryParseIntStrict(string value, out int parsedValue)
        {
            parsedValue = 0;            
            return value.Contains(" ") ? false : int.TryParse(value, out parsedValue);
        }
    }
}