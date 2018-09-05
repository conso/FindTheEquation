using FindTheEquation.App;
using NSubstitute;
using NUnit.Framework;

namespace FindTheEquation.Test
{
    [TestFixture]
    public class EquationFinder_Should
    {
        private IFindAllPermutations _permutator;

        [SetUp]
        public void SetupTest()
        {
            _permutator = Substitute.For<IFindAllPermutations>();
        }

        [Test]
        public void FindAllPermutations()
        {
            var equationFinder = new EquationFinder(_permutator);

            equationFinder.FindAllFor(50);

            _permutator.Received(1).FindAll();
        }
    }
}
