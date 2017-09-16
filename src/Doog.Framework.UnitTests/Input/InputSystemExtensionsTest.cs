using NUnit.Framework;
using System;
using Rhino.Mocks;
using Doog.Framework.Input;

namespace Doog.Framework.UnitTests.Input
{
    [TestFixture]
    public class InputSystemExtensionsTest
    {
        [Test]
        public void TestCase()
        {
            var d1Called = false;
            var d2Called = false;

            var input = MockRepository.GenerateMock<IInputSystem>();
            input.Expect(i => i.IsKeyDown(Keys.D1)).Return(true);
			input.Expect(i => i.IsKeyDown(Keys.D2)).Return(false);

            input.IsKeyDown(Keys.D1, () => d1Called = true)
                 .IsKeyDown(Keys.D2, () => d2Called = true);

            Assert.IsTrue(d1Called);
            Assert.IsFalse(d2Called);

            input.VerifyAllExpectations();
        }
    }
}
