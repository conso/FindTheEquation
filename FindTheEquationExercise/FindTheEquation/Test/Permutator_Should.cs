using System;
using System.Linq;
using FindTheEquation.App;
using NUnit.Framework;

namespace FindTheEquation.Test
{
    [TestFixture]
    public class Permutator_Should
    {
        private IFindAllPermutations _permutator;

        [TestCase("1234", "+-j", ExpectedResult = 27)]
        [TestCase("123", "+-j", ExpectedResult = 9)]
        [TestCase("123", "+-", ExpectedResult = 4)]
        [TestCase("123", "+", ExpectedResult = 1)]
        [TestCase("12", "+-", ExpectedResult = 2)]
        [TestCase("12", "+", ExpectedResult = 1)]
        public int FindAllPossibleEquations(string setupDigits, string definedOperations)
        {
            _permutator = new Permutator(setupDigits, ArrayOf(definedOperations));

            var result = _permutator.FindAll();

            Display(result);
            return result.Length;
        }

        private static string[] ArrayOf(string definedOperations)
        {
            return definedOperations.ToCharArray().Select(x=>x.ToString()).ToArray();
        }

        private void Display(string[] result)
        {
            foreach (string expression in result)
            {
                TestContext.WriteLine(expression);
            }
        }
    }
}
