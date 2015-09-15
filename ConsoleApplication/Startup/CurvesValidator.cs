using System.Collections.Generic;

namespace Startup
{
    public class CurvesValidator
    {
        private readonly Stack<bool> _curves = new Stack<bool>();
        private readonly Stack<bool> _braces = new Stack<bool>();
        private readonly Stack<bool> _brackets = new Stack<bool>();

        public bool Validate(string value)
        {
            foreach (var character in value)
            {
                var validationFailed = false;
                switch (character)
                {
                    case '(':
                        PushToStacks(true, false, false);
                        break;
                    case ')':
                        validationFailed = TryPopFromStacks(true, false, false);
                        break;
                    case '{':
                        PushToStacks(false, true, false);
                        break;
                    case '}':
                        validationFailed = TryPopFromStacks(false, true, false);
                        break;
                    case '[':
                        PushToStacks(false, false, true);
                        break;
                    case ']':
                        validationFailed = TryPopFromStacks(false, false, true);
                        break;
                }

                if (validationFailed)
                {
                    return false;
                }
            }

            return _curves.Count == 0;
        }

        private void PushToStacks(bool curves, bool braces, bool brackets)
        {
            _curves.Push(curves);
            _braces.Push(braces);
            _brackets.Push(brackets);
        }

        private bool TryPopFromStacks(bool curves, bool braces, bool brackets)
        {
            if (_curves.Count == 0)
            {
                return true;
            }

            if ((_curves.Peek() ^ curves) || (_braces.Peek() ^ braces) ^ (_brackets.Peek() ^ brackets))
            {
                return true;
            }

            _curves.Pop();
            _braces.Pop();
            _brackets.Pop();
            return false;
        }
    }
}
