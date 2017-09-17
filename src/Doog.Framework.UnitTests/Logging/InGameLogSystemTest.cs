using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;

namespace Doog.Framework.UnitTests.Logging
{
    [TestFixture]
    public class InGameLogSystemTest
    {
        [Test]
        public void Draw_ManyLevels_MessagesDrawn()
        {
            var ctx = MockRepository.GenerateMock<IWorldContext>();
            ctx.Expect(c => c.Time).Return(MockRepository.GenerateMock<ITime>());
            var textSystem = MockRepository.GenerateMock<ITextSystem>();
            var drawContext = MockRepository.GenerateMock<IDrawContext>();
            drawContext.Expect(t => t.Canvas).Return(MockRepository.GenerateMock<ICanvas>());
            drawContext.Expect(c => c.TextSystem).Return(textSystem);

            textSystem.Expect(t => t.Draw(1, 3, "INFO (00:00:00): x2", "Debug")).Return(textSystem);
            textSystem.Expect(t => t.Draw(1, 4, "WARN (00:00:00): x3", "Debug")).Return(textSystem);
            textSystem.Expect(t => t.Draw(1, 5, "ERROR (00:00:00): x4", "Debug")).Return(textSystem);

            var target = new InGameLogSystem(new Rectangle(0, 1, 10, 4), ctx);
            target.Debug("x1", 1);
            target.Info("x2", 1);
            target.Warn("x3", 1);
            target.Error("x4", 1);

            target.Draw(drawContext);

            textSystem.VerifyAllExpectations();
        }

        [Test]
        public void AddChildren_Any_Exception()
        {
			var ctx = MockRepository.GenerateMock<IWorldContext>();
            var target = new InGameLogSystem(new Rectangle(0, 1, 10, 4), ctx);
           
            Assert.AreEqual(0, target.GetChildren().Count());

            Assert.Catch<System.NotImplementedException>(delegate
            {
                target.AddChild(MockRepository.GenerateMock<IComponent>());
            });
        }
    }
}
