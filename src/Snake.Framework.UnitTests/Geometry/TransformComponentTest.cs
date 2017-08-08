using NUnit.Framework;
using Snake.Framework.Geometry;

namespace Snake.Framework.UnitTests.Geometry
{
	[TestFixture]
	public class TransformComponentTest
	{
		[Test]
		public void IncrementPosition_XAndY_PositionChanged()
		{
			var target = new TransformComponent(0, 0);

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
			var target = new TransformComponent();

			Assert.IsTrue(target.Intersect(new TransformComponent()));

			target.IncrementPosition(1, 0);
			Assert.IsFalse(target.Intersect(new TransformComponent()));

			target.IncrementPosition(-1, 1);
			Assert.IsFalse(target.Intersect(new TransformComponent()));

			target.IncrementPosition(0, -1);
			Assert.IsTrue(target.Intersect(new TransformComponent()));

			target.IncrementPosition(-1, -1);
			target.Size = IntPoint.One;
			Assert.IsTrue(target.Intersect(new TransformComponent()));
			Assert.AreEqual(1, target.Size.X);
			Assert.AreEqual(1, target.Size.Y);
		}
	}
}
