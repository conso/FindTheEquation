namespace FindTheEquation.App
{
    public class EquationFinderController
    {
        private readonly EquationFinder _equationFinder;

        public EquationFinderController(string setupDigits)
        {
            var definedOperations = new[] {"+", "-", "j"};
            IFindAllPermutations permutator = new Permutator(setupDigits, definedOperations);
            ICalculateExpressions expressionCalculator = new ExpressionCalculator();
            
            _equationFinder = new EquationFinder(permutator, expressionCalculator);
        }

        public string[] FindEquationsFor(int inputValue)
        {
            return _equationFinder.FindAllFor(inputValue);
        }
    }
}