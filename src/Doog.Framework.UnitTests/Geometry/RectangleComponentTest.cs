using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using Doog.Framework.Geometry;
using Doog.Framework.Graphics;

namespace Doog.Framework.UnitTests.Geometry
{
    [TestFixture]
    public class RectangleComponentTest
    {
		[Test]
		public void Constructor_OtherRectangleComponent_CopyProperties()
		{
			var ctx = MockRepository.GenerateMock<IWorldContext>();
			var drawCtx = MockRepository.GenerateMock<IDrawContext>();
			var canvas = MockRepository.GenerateMock<ICanvas>();
			drawCtx.Expect(d => d.Canvas).Return(canvas);

            var other = new RectangleComponent(new Point(10, 20), ctx);
			var target = new RectangleComponent(other);

            Assert.AreEqual(other.Transform.Position, target.Transform.Position);
			Assert.AreEqual(other.Transform.Scale, target.Transform.Scale);
			Assert.AreEqual(other.Context, target.Context);
		}

		[Test]
		public void Constructor_OtherRectangle_CopyProperties()
		{
			var ctx = MockRepository.GenerateMock<IWorldContext>();
			var drawCtx = MockRepository.GenerateMock<IDrawContext>();
			var canvas = MockRepository.GenerateMock<ICanvas>();
			drawCtx.Expect(d => d.Canvas).Return(canvas);

			var other = new Rectangle(10, 20, 30, 40);
			var target = new RectangleComponent(other, ctx);

			Assert.AreEqual(other.LeftTopPoint(), target.Transform.Position);
			Assert.AreEqual(other.Width, target.Transform.Scale.X);
            Assert.AreEqual(other.Height, target.Transform.Scale.Y);
			Assert.AreEqual(ctx, target.Context);
		}

		[Test]
		public void Constructor_PointAndScale_Properties()
		{
			var ctx = MockRepository.GenerateMock<IWorldContext>();
		
			var target = new RectangleComponent(new Point(1, 2), 3, ctx);

			Assert.AreEqual(new Point(1, 2), target.Transform.Position);
			Assert.AreEqual(3, target.Transform.Scale.X);
			Assert.AreEqual(3, target.Transform.Scale.Y);
			Assert.AreEqual(ctx, target.Context);
		}

		[Test]
		public void Constructor_XYAndScale_Properties()
		{
			var ctx = MockRepository.GenerateMock<IWorldContext>();

			var target = new RectangleComponent(1, 2, 3, ctx);

			Assert.AreEqual(new Point(1, 2), target.Transform.Position);
			Assert.AreEqual(3, target.Transform.Scale.X);
			Assert.AreEqual(3, target.Transform.Scale.Y);
			Assert.AreEqual(ctx, target.Context);
		}

        [Test]
        public void Draw_Context_CircleDrawn()
        {
            var ctx = MockRepository.GenerateMock<IWorldContext>();
            var drawCtx = MockRepository.GenerateMock<IDrawContext>();
            var canvas = MockRepository.GenerateMock<ICanvas>();
            drawCtx.Expect(d => d.Canvas).Return(canvas);

            var target = new RectangleComponent(new Point(10, 20), ctx);
			canvas.Expect(c => c.Draw(target.Transform.BoundingBox, true, '#'));

			target.Draw(drawCtx);

            canvas.VerifyAllExpectations();
        }
	}
}
