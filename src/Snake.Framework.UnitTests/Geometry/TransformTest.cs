using NUnit.Framework;
using Rhino.Mocks;
using Snake.Framework.Geometry;

namespace Snake.Framework.UnitTests.Geometry
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
	}
}
