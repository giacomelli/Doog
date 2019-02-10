using System.Linq;
using NUnit.Framework;
using NSubstitute;

namespace Doog.Tests.Framework.Logging
{
    [TestFixture]
    public class InGameLogSystemTest
    {
        [Test]
        public void Draw_ManyLevels_MessagesDrawn()
        {
            var ctx = Substitute.For<IWorldContext>();
            ctx.Time.Returns(Substitute.For<ITime>());
            var textSystem = Substitute.For<ITextSystem>();
            var drawContext = Substitute.For<IDrawContext>();
            drawContext.Canvas.Returns(Substitute.For<ICanvas>());
            drawContext.TextSystem.Returns(textSystem);

            var target = new InGameLogSystem(new Rectangle(0, 1, 10, 4), ctx);
            target.Debug("x1", 1);
            target.Info("x2", 1);
            target.Warn("x3", 1);
            target.Error("x4", 1);

            target.Draw(drawContext);

            textSystem.Received().Draw(1, 3, "INFO (00:00:00): x2", "Debug");
            textSystem.Received().Draw(1, 4, "WARN (00:00:00): x3", "Debug");
            textSystem.Received().Draw(1, 5, "ERROR (00:00:00): x4", "Debug");
        }

        [Test]
        public void AddChildren_Any_Exception()
        {
			var ctx = Substitute.For<IWorldContext>();
            var target = new InGameLogSystem(new Rectangle(0, 1, 10, 4), ctx);
           
            Assert.AreEqual(0, target.GetChildren().Count());

            Assert.Catch<System.NotImplementedException>(delegate
            {
                target.AddChild(Substitute.For<IComponent>());
            });
        }
    }
}
