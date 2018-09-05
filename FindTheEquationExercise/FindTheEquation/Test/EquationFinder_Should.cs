using System.Collections.Generic;
using FindTheEquation.App;
using NSubstitute;
using NUnit.Framework;

namespace FindTheEquation.Test
{
    [TestFixture]
    public class EquationFinder_Should
    {
        private IFindAllPermutations _permutator;
        private ICalculateExpressions _expressionCalculator;

        [SetUp]
        public void SetupTest()
        {
            _permutator = Substitute.For<IFindAllPermutations>();
            _expressionCalculator = Substitute.For<ICalculateExpressions>();
        }

        [Test]
        public void FindAllPermutations()
        {
            var equationFinder = new EquationFinder(_permutator,_expressionCalculator);

            equationFinder.FindAllFor(50);

            _permutator.Received(1).FindAll();
        }

        [Test]
        public void CalculateAllPermutationsValues()
        {
            string[] fakePermutations = new string[1];
            _permutator.FindAll().Returns(fakePermutations);
            var equationFinder = new EquationFinder(_permutator, _expressionCalculator);

            equationFinder.FindAllFor(50);

            _expressionCalculator.Received(1).Calculate(fakePermutations);
        }

        [Test]
        public void ReturnFormattedEquationsMatchingInputValue()
        {
            var testExpressions = new[]
            {
                new KeyValuePair<string, int>("1 + 2", 3),
                new KeyValuePair<string, int>("1 - 2", -1),
                new KeyValuePair<string, int>("12", 12)
            };
            _expressionCalculator.Calculate(Arg.Any<string[]>()).Returns(testExpressions);
            var equationFinder = new EquationFinder(_permutator, _expressionCalculator);

            var outcome = equationFinder.FindAllFor(3);

            Assert.That(outcome, Is.EqualTo(new[] {"1 + 2 = 3"}));
        }
    }
}
