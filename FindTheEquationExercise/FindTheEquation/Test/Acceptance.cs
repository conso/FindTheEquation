using NUnit.Framework;

namespace FindTheEquation.Test
{
    [TestFixture]
    public class Acceptance
    {
        [Test]
        public void Scenario_50()
        {
            Given_The_Digits("123456789");

            When_Finding_Equations_For(50);

            Then_Outcome_Should_Contain("1 - 2 + 34 + 5 + 6 + 7 + 8 - 9 = 50");
        }

        private void Given_The_Digits(string setupDigits)
        {
            throw new System.NotImplementedException();
        }

        private void When_Finding_Equations_For(int inputValue)
        {
            throw new System.NotImplementedException();
        }

        private void Then_Outcome_Should_Contain(string expectedOutcome)
        {
            throw new System.NotImplementedException();
        }
    }
}
