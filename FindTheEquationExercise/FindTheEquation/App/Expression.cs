namespace FindTheEquation.App
{
   public class Expression
    {
        private readonly string _expression;
        private int _value;

        public Expression(string expression)
        {
            _expression = expression.Replace("j", string.Empty);
            CalculateValue();
        }

        public int Value()
        {
            return _value;
        }

        public string Format()
        {
            var formatted = _expression.Replace("-", " - ");
            formatted = formatted.Replace("+", " + ");
            return formatted + " = " + _value;
        }

        private void CalculateValue()
        {
            string current = "";
            foreach (char c in _expression)
            {
                switch (c)
                {
                    case '+':
                        _value += int.Parse(current);
                        current = "";
                        continue;
                    case '-':
                        _value += int.Parse(current);
                        current = "-";
                        continue;
                    default:
                        current += c;
                        break;
                }
            }
            _value += int.Parse(current);
        }
    }
}