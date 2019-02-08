using NUnit.Framework;
using NSubstitute;

namespace Doog.UnitTests.Input
{
    [TestFixture]
    public class InputSystemExtensionsTest
    {
        [Test]
        public void TestCase()
        {
            var d1Called = false;
            var d2Called = false;

            var input = Substitute.For<IInputSystem>();
            input.IsKeyDown(Keys.D1).Returns(true);
			input.IsKeyDown(Keys.D2).Returns(false);

            input.IsKeyDown(Keys.D1, () => d1Called = true)
                 .IsKeyDown(Keys.D2, () => d2Called = true);

            Assert.IsTrue(d1Called);
            Assert.IsFalse(d2Called);
         }
    }
}
