using System.Collections.Generic;
using System.Linq;

namespace FindTheEquation.App
{
    public class Permutator: IFindAllPermutations
    {
        private readonly string[] _definedOperations;
        private readonly DigitsIterator _digitsIterator;
        private List<string> _outcome;

        public Permutator(string setupDigits, string[] definedOperations)
        {
            _digitsIterator = new DigitsIterator(setupDigits);
            _definedOperations = definedOperations;
        }

        public string[] FindAll()
        {
            _outcome = new List<string>();
            var current = new List<string>{string.Empty};
            AddNextDigit(current);
            return _outcome.ToArray();
        }

        private void AddNextDigit(List<string> current)
        {
            _digitsIterator.Next();
            current = AddCurrentDigitToList(current);

            if (_digitsIterator.Completed)
            {
                _outcome = current;
                return;
            }
               
            AddOperator(current);
        }

        private List<string> AddCurrentDigitToList(List<string> current)
        {
            return current.Select(x => x + _digitsIterator.Current).ToList();
        }

        private void AddOperator(List<string> current)
        {
            var newList = new List<string>();
            foreach (var operation in _definedOperations)
            {
                AddCurrentOperatorToList(current, newList, operation);
            }
            AddNextDigit(newList);
        }

        private static void AddCurrentOperatorToList(List<string> current, List<string> newList, string operation)
        {
            newList.AddRange(current.Select(x => x + operation).ToList());
        }
    }
}