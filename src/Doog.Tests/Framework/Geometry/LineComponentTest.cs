using NUnit.Framework;
using NSubstitute;

namespace Doog.Tests.Framework.Geometry
{
    [TestFixture]
    public class LineComponentTest
    {
		[Test]
		public void Constructor_X1Y1AndX2Y2_PointAAndPointB()
		{
			var ctx = Substitute.For<IWorldContext>();
			var target = new LineComponent(1, 2, 3, 4, ctx);

            Assert.AreEqual(new Point(1, 2), target.PointA);
            Assert.AreEqual(new Point(3, 4), target.PointB);
			Assert.AreEqual(ctx, target.Context);

            target.PointA = Point.Ten;
            Assert.AreEqual(Point.Ten, target.Transform.Position);
		}

        [Test]
        public void Draw_Context_LineDrawn()
        {
            var ctx = Substitute.For<IWorldContext>();
            var drawCtx = Substitute.For<IDrawContext>();
            var canvas = Substitute.For<ICanvas>();
            drawCtx.Canvas.Returns(canvas);

            var target = new LineComponent(new Point(10, 20), new Point(15, 25), ctx);
			target.Draw(drawCtx);

            canvas.Received().Draw(target, '#'.White());
        }
    }
}
