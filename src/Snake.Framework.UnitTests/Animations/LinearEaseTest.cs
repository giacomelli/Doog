using NUnit.Framework;
using Snake.Framework.Animations;

namespace Snake.Framework.UnitTests.Animations
{
    [TestFixture]
    public class LinearEaseTest
    {
        [Test]
        public void Calculate_FromLowerThanTo_Value()
        {
            Assert.AreEqual(10, LinearEase.Default.Calculate(10, 110, 0));
			Assert.AreEqual(20, LinearEase.Default.Calculate(10, 110, 0.1f));
            Assert.AreEqual(60, LinearEase.Default.Calculate(10, 110, 0.5f));
			Assert.AreEqual(110, LinearEase.Default.Calculate(10, 110, 1f));
        }

		[Test]
		public void Calculate_FromGreaterThanTo_Value()
		{
			Assert.AreEqual(110, LinearEase.Default.Calculate(110, 10, 0));
			Assert.AreEqual(100, LinearEase.Default.Calculate(110, 10, 0.1f));
			Assert.AreEqual(60, LinearEase.Default.Calculate(110, 10, 0.5f));
			Assert.AreEqual(10, LinearEase.Default.Calculate(110, 10, 1f));
		}
    }
}
