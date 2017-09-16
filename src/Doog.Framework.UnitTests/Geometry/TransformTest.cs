using System;
using NUnit.Framework;
using Rhino.Mocks;
using Doog.Framework;

namespace Doog.Framework.UnitTests.Geometry
{
	[TestFixture]
	public class TransformTest
	{
		[Test]
		public void IncrementPosition_XAndY_PositionChanged()
		{
			var target = new Transform(0, 0, MockRepository.GenerateMock<IWorldContext>());

			target.IncrementPosition(1, -1);
			Assert.AreEqual(1, target.Position.X);
			Assert.AreEqual(-1, target.Position.Y);

			target.IncrementPosition(-5, 5);
			Assert.AreEqual(-4, target.Position.X);
			Assert.AreEqual(4, target.Position.Y);
		}

		[Test]
		public void Intersect_PositionOrSizeChanged_IntersectChanged()
		{
            var ctx = MockRepository.GenerateMock<IWorldContext>();
			var target = new Transform(ctx);

			Assert.IsTrue(target.Intersect(new Transform(ctx)));

            target.Position = new Point(1, 1);
			Assert.IsFalse(target.Intersect(new Transform(ctx)));

			target.Position = new Point(-1, -1);
			Assert.IsFalse(target.Intersect(new Transform(ctx)));

			target.Position = new Point(0, 0);
			Assert.IsTrue(target.Intersect(new Transform(ctx)));

			target.Position = new Point(0, 0);
			target.Scale = new Point(2, 2);
			Assert.IsTrue(target.Intersect(new Transform(ctx)));
			Assert.AreEqual(2, target.Scale.X);
			Assert.AreEqual(2, target.Scale.Y);
		}

		[Test]
		public void SetX_X_NewPosition()
		{
			var target = new Transform(0, 0, MockRepository.GenerateMock<IWorldContext>());

            var oldPosition = target.Position;
			target.SetX(1);
            Assert.AreEqual(new Point(1, 0), target.Position);
            Assert.AreNotSame(oldPosition, target.Position);
		}

		[Test]
		public void SetY_Y_NewPosition()
		{
			var target = new Transform(0, 0, MockRepository.GenerateMock<IWorldContext>());

			var oldPosition = target.Position;
			target.SetY(1);
			Assert.AreEqual(new Point(0, 1), target.Position);
			Assert.AreNotSame(oldPosition, target.Position);
		}

        [Test]
        public void Scale_DiffValues_Scaled()
        {
            var target = new Transform(5, 10, MockRepository.GenerateMock<IWorldContext>());
            Assert.AreEqual(Point.Zero, target.Scale);
            Assert.AreEqual(new Rectangle(5, 10, 0, 0), target.BoundingBox);

            target.Scale = Point.One;
            Assert.AreEqual(new Rectangle(5, 10, 1, 1), target.BoundingBox);

            target.Scale = Point.Two;
            Assert.AreEqual(new Rectangle(5, 10, 2, 2), target.BoundingBox);

            target.Scale = Point.Three;
            Assert.AreEqual(new Rectangle(5, 10, 3, 3), target.BoundingBox);

            target.Scale = Point.One;
            Assert.AreEqual(new Rectangle(5, 10, 1, 1), target.BoundingBox);
        }

        [Test]
        public void Rotation_360_KeepScaleAndBoxSize()
        {
            var target = new Transform(5, 10,  MockRepository.GenerateMock<IWorldContext>());
            target.Scale = Point.Ten;           
            var expectedBoundingBox = new Rectangle(5, 10, 10, 10);
            Assert.AreEqual(expectedBoundingBox, target.BoundingBox);
            Assert.AreEqual(Point.Ten, target.Scale);

            for (int angle = 0; angle <= 360; angle++)
            {
                target.Rotation = angle;
             
                Assert.AreEqual(Point.Ten, target.Scale);
                Assert.AreEqual(target.Scale.X, Math.Round(target.BoundingBox.Width, 2));
                Assert.AreEqual(target.Scale.Y, Math.Round(target.BoundingBox.Height, 2));
                Assert.AreEqual(target.Rotation, angle);
            }

            for (int angle = 360; angle >= 0; angle--)
            {
                target.Rotation = angle;

                Assert.AreEqual(Point.Ten, target.Scale);
                Assert.AreEqual(target.Scale.X, Math.Round(target.BoundingBox.Width, 2));
                Assert.AreEqual(target.Scale.Y, Math.Round(target.BoundingBox.Height, 2));
                Assert.AreEqual(target.Rotation, angle);
            }
        }
    }
}
