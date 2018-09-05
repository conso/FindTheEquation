using System.Linq;

namespace FindTheEquation.App
{
    public class EquationFinder
    {
        private readonly IFindAllPermutations _permutator;

        public EquationFinder(IFindAllPermutations permutator)
        {
            _permutator = permutator;
        }

        public string[] FindAllFor(int inputValue)
        {
            var allExpressions = _permutator.FindAll();
            var calculableExpressions = allExpressions.Select(x => new Expression(x)).ToList();
            return calculableExpressions.Where(e => e.Value() == inputValue).Select(e=>e.Format()).ToArray();
        }
    }
}