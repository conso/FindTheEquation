using FindTheEquation.App;
using NUnit.Framework;

namespace FindTheEquation.Test
{
    public class Expression_Should
    {
        private Expression _expression;

        [TestCase("1j2+3-4j5", ExpectedResult = -30)]
        [TestCase("1j2-3+4-5", ExpectedResult = 8)]
        public int CalculateItsValue(string expression)
        {
            _expression = new Expression(expression);

            return  _expression.Value();
        }

        [TestCase("1j2+3-4j5", ExpectedResult = "12 + 3 - 45 = -30")]
        [TestCase("1j2-3+4-5", ExpectedResult = "12 - 3 + 4 - 5 = 8")]
        public string FormatItsText(string expression)
        {
            _expression = new Expression(expression);

            return  _expression.Format();
        }
    }
}
