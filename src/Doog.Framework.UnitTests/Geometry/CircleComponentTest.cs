using NUnit.Framework;
using Rhino.Mocks;

namespace Doog.Framework.UnitTests.Geometry
{
    [TestFixture]
    public class CircleComponentTest
    {
        [Test]
        public void Draw_Context_CircleDrawn()
        {
            var ctx = MockRepository.GenerateMock<IWorldContext>();
            var drawCtx = MockRepository.GenerateMock<IDrawContext>();
            var canvas = MockRepository.GenerateMock<ICanvas>();
            drawCtx.Expect(d => d.Canvas).Return(canvas);

            var target = new CircleComponent(new Point(10, 20), 4, ctx);
			canvas.Expect(c => c.Draw(target, true, '#'));


            var circle = target as ICircle;

            Assert.AreEqual(10, circle.Left);
            Assert.AreEqual(20, circle.Top);
			Assert.AreEqual(18, circle.Right);
            Assert.AreEqual(28, circle.Bottom);
			target.Draw(drawCtx);

            canvas.VerifyAllExpectations();
        }
	}
}
