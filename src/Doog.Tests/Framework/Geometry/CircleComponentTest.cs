using NUnit.Framework;
using NSubstitute;

namespace Doog.Tests.Framework.Geometry
{
    [TestFixture]
    public class CircleComponentTest
    {
        [Test]
        public void Draw_Context_CircleDrawn()
        {
            var ctx = Substitute.For<IWorldContext>();
            var drawCtx = Substitute.For<IDrawContext>();
            var canvas = Substitute.For<ICanvas>();
            drawCtx.Canvas.Returns(canvas);

            var target = new CircleComponent(new Point(10, 20), 4, ctx);
		    var circle = target as ICircle;

            Assert.AreEqual(10, circle.Left);
            Assert.AreEqual(20, circle.Top);
			Assert.AreEqual(18, circle.Right);
            Assert.AreEqual(28, circle.Bottom);
			target.Draw(drawCtx);

            canvas.Received().Draw(target, true, '#');
        }
	}
}
