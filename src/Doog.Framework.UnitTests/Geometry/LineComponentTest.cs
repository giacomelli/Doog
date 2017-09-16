using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using Doog.Framework.Geometry;
using Doog.Framework.Graphics;

namespace Doog.Framework.UnitTests.Geometry
{
    [TestFixture]
    public class LineComponentTest
    {
		[Test]
		public void Constructor_X1Y1AndX2Y2_PointAAndPointB()
		{
			var ctx = MockRepository.GenerateMock<IWorldContext>();
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
            var ctx = MockRepository.GenerateMock<IWorldContext>();
            var drawCtx = MockRepository.GenerateMock<IDrawContext>();
            var canvas = MockRepository.GenerateMock<ICanvas>();
            drawCtx.Expect(d => d.Canvas).Return(canvas);

            var target = new LineComponent(new Point(10, 20), new Point(15, 25), ctx);
			canvas.Expect(c => c.Draw(target, '#'));

			target.Draw(drawCtx);

            canvas.VerifyAllExpectations();
        }
	}
}
