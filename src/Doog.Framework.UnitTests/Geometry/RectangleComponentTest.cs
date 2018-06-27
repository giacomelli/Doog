using NUnit.Framework;
using NSubstitute;

namespace Doog.Framework.UnitTests.Geometry
{
    [TestFixture]
    public class RectangleComponentTest
    {
		[Test]
		public void Constructor_OtherRectangleComponent_CopyProperties()
		{
			var ctx = Substitute.For<IWorldContext>();
			var drawCtx = Substitute.For<IDrawContext>();
			var canvas = Substitute.For<ICanvas>();
			drawCtx.Canvas.Returns(canvas);

            var other = new RectangleComponent(new Point(10, 20), ctx);
			var target = new RectangleComponent(other);

            Assert.AreEqual(other.Transform.Position, target.Transform.Position);
			Assert.AreEqual(other.Transform.Scale, target.Transform.Scale);
			Assert.AreEqual(other.Context, target.Context);
		}

		[Test]
		public void Constructor_OtherRectangle_CopyProperties()
		{
			var ctx = Substitute.For<IWorldContext>();
			var drawCtx = Substitute.For<IDrawContext>();
			var canvas = Substitute.For<ICanvas>();
            drawCtx.Canvas.Returns(canvas);

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
			var ctx = Substitute.For<IWorldContext>();
		
			var target = new RectangleComponent(new Point(1, 2), 3, ctx);

			Assert.AreEqual(new Point(1, 2), target.Transform.Position);
			Assert.AreEqual(3, target.Transform.Scale.X);
			Assert.AreEqual(3, target.Transform.Scale.Y);
			Assert.AreEqual(ctx, target.Context);
		}

		[Test]
		public void Constructor_XYAndScale_Properties()
		{
			var ctx = Substitute.For<IWorldContext>();

			var target = new RectangleComponent(1, 2, 3, ctx);

			Assert.AreEqual(new Point(1, 2), target.Transform.Position);
			Assert.AreEqual(3, target.Transform.Scale.X);
			Assert.AreEqual(3, target.Transform.Scale.Y);
			Assert.AreEqual(ctx, target.Context);
		}

        [Test]
        public void Draw_Context_CircleDrawn()
        {
            var ctx = Substitute.For<IWorldContext>();
            var drawCtx = Substitute.For<IDrawContext>();
            var canvas = Substitute.For<ICanvas>();
            drawCtx.Canvas.Returns(canvas);

            var target = new RectangleComponent(new Point(10, 20), ctx);
			target.Draw(drawCtx);

            canvas.Received().Draw(target.Transform.BoundingBox, true, '#');
        }
	}
}
