using System.Collections.Generic;
using System.Linq;

namespace FindTheEquation.App
{
    public class EquationFinder
    {
        private readonly IFindAllPermutations _permutator;
        private readonly ICalculateExpressions _expressionCalculator;

        public EquationFinder(IFindAllPermutations permutator, ICalculateExpressions expressionCalculator)
        {
            _permutator = permutator;
            _expressionCalculator = expressionCalculator;
        }

        public string[] FindAllFor(int inputValue)
        {
            var allExpressions = _permutator.FindAll();
            var calculatedExpressions = _expressionCalculator.Calculate(allExpressions);
            var correctExpressions = FindMatch(inputValue, calculatedExpressions);
            return Format(correctExpressions);
        }

        private KeyValuePair<string, int>[] FindMatch(int inputValue, KeyValuePair<string, int>[] calculatedExpressions)
        {
            return calculatedExpressions.Where(ce => ce.Value == inputValue).ToArray();
        }

        private string[] Format(KeyValuePair<string, int>[] expressions)
        {
            return expressions.Select(expression => string.Join(" = ", expression.Key, expression.Value)).ToArray();
        }
    }
}