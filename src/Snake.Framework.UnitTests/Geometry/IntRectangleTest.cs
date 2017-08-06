using NUnit.Framework;
using Snake.Framework.Geometry;

namespace Snake.Framework.UnitTests.Geometry
{
	[TestFixture]
	public class IntRectangleTest
	{
		[Test]
		public void Contains_PointOutside_False()
		{
			var target = new IntRectangle(0, 1, 10, 11);

			Assert.IsFalse(target.Contains(-1, 1));
			Assert.IsFalse(target.Contains(0, 0));
			Assert.IsFalse(target.Contains(11, 1));
			Assert.IsFalse(target.Contains(10, 12));
		}

		[Test]
		public void Contains_PoinInside_True()
		{
			var target = new IntRectangle(0, 1, 10, 11);

			Assert.IsTrue(target.Contains(0, 1));
			Assert.IsTrue(target.Contains(1, 2));
			Assert.IsTrue(target.Contains(10, 11));
			Assert.IsTrue(target.Contains(0, 11));

			for (int x = target.Left; x < target.Right; x++)
			{
				for (int y = target.Top; y < target.Bottom; y++)
				{
					Assert.IsTrue(target.Contains(x, y), "{0}, {1}", x, y);
				}
			}
		}

		[Test]
		public void Intersect_NonInterserction_False()
		{
			var target = new IntRectangle(5, 10, 15, 20);
			Assert.IsFalse(target.Intersect(new IntRectangle(3, 8, 4, 9)));
			Assert.IsFalse(target.Intersect(new IntRectangle(1, 21, 10, 23)));
		}

		[Test]
		public void Intersect_Intersection_True()
		{
			var target = new IntRectangle(5, 10, 15, 20);
			Assert.IsTrue(target.Intersect(new IntRectangle(3, 8, 5, 10)));
			Assert.IsTrue(target.Intersect(new IntRectangle(6, 11, 7, 12)));
		}

		[Test]
		public void GetCenter_NoArgs_CenterPoint()
		{
			var target = new IntRectangle(0, 0, 15, 20);
			var actual = target.GetCenter();
			Assert.AreEqual(7, actual.X);
			Assert.AreEqual(10, actual.Y);

			target = new IntRectangle(5, 10, 15, 20);
			actual = target.GetCenter();
			Assert.AreEqual(10, actual.X);
			Assert.AreEqual(15, actual.Y);
		}

		[Test]
		public void Scale_Scale_NewRectangleScaled()
		{
			var target = new IntRectangle(5, 10, 15, 20);
			var actual = target.Scale(2);
			Assert.AreEqual(5, actual.Left);
			Assert.AreEqual(10, actual.Top);
			Assert.AreEqual(30, actual.Right);
			Assert.AreEqual(40, actual.Bottom);

			actual = target.Scale(0.5f);
			Assert.AreEqual(5, actual.Left);
			Assert.AreEqual(10, actual.Top);
			Assert.AreEqual(8, actual.Right);
			Assert.AreEqual(10, actual.Bottom);
		}
	}
}
