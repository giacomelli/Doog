using NUnit.Framework;
using System;
using Rhino.Mocks;
using Snake.Framework.Logging;
using System.Linq;

namespace Snake.Framework.UnitTests
{
    [TestFixture]
    public class ComponentBaseTest
    {
        [Test]
        public void Enabled_Changed_CallOnMethods()
        {
            var wc = MockRepository.GenerateMock<IWorldContext>();
            var logSystem = MockRepository.GenerateMock<ILogSystem>();
            logSystem.Expect(c => c.Debug(null)).IgnoreArguments().Repeat.Times(2);
            wc.Expect(t => t.LogSystem).Return(logSystem);

            var target = MockRepository.GeneratePartialMock<ComponentBase>(wc, false); 

            target.Enabled = false;

            if (!target.Enabled)
            {
                target.Enabled = true;
            }

            logSystem.VerifyAllExpectations();
        }

		[Test]
		public void AddChild_Child_Added()
		{
			var wc = MockRepository.GenerateMock<IWorldContext>();
            wc.Expect(t => t.AddComponent(null)).IgnoreArguments();
			var target = MockRepository.GeneratePartialMock<ComponentBase>(wc, true);
            target.AddChild(MockRepository.GenerateMock<IComponent>());
            target.AddChild(MockRepository.GenerateMock<IComponent>());

            Assert.AreEqual(2, target.GetChildren().Count());

			wc.VerifyAllExpectations();
		}
    }
}
