using NUnit.Framework;
using NSubstitute;
using System.Linq;

namespace Doog.Tests.Framework
{
    [TestFixture]
    public class ComponentBaseTest
    {
        [Test]
        public void Enabled_Changed_CallOnMethods()
        {
            var wc = Substitute.For<IWorldContext>();
            var logSystem = Substitute.For<ILogSystem>();
            wc.LogSystem.Returns(logSystem);

            var target = new StubComponent(wc, false)
            {
                Enabled = false
            };

            if (!target.Enabled)
            {
                Assert.IsFalse(target.Enabled);
                target.Enabled = true;
            }

            logSystem.ReceivedWithAnyArgs(2).Debug(null);
        }

        [Test]
		public void AddChild_Child_Added()
		{
			var wc = Substitute.For<IWorldContext>();
           
			var target = Substitute.For<ComponentBase>(wc, true);
            target.AddChild(Substitute.For<IComponent>());
            target.AddChild(Substitute.For<IComponent>());

            Assert.AreEqual(2, target.GetChildren().Count());

            wc.ReceivedWithAnyArgs().AddComponent(null);
        }
    }
}
