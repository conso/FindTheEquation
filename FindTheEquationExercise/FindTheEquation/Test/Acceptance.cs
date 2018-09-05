using System.Linq;
using FindTheEquation.App;
using NUnit.Framework;

namespace FindTheEquation.Test
{
    [TestFixture]
    public class Acceptance
    {
        private EquationFinderController _equationFinderController;
        private string[] _outcome;

        [Test]
        public void Scenario_50()
        {
            Given_The_Digits("123456789");

            When_Finding_Equations_For(50);

            Then_Outcome_Should_Contain("1 - 2 + 34 + 5 + 6 + 7 + 8 - 9 = 50");
        }

        private void Given_The_Digits(string setupDigits)
        {
            _equationFinderController = new EquationFinderController(setupDigits);
        }

        private void When_Finding_Equations_For(int inputValue)
        {
            _outcome = _equationFinderController.FindEquationsFor(inputValue);
        }

        private void Then_Outcome_Should_Contain(string expectedOutcome)
        {
            Assert.That(_outcome.Contains(expectedOutcome));
        }
    }
}
