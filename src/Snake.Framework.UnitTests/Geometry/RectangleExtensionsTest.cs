using NUnit.Framework;
using Snake.Framework.Geometry;

namespace Snake.Framework.UnitTests.Geometry
{
	[TestFixture]
	public class RectangleExtensionsTest
	{

		[Test]
		public void Contains_PointOutside_False()
		{
			var target = new Rectangle(5, 10, 15, 20);
            Assert.IsFalse(target.Contains(5, 9));
			Assert.IsFalse(target.Contains(4, 10));
			Assert.IsFalse(target.Contains(15, 21));
			Assert.IsFalse(target.Contains(16, 20));
		}

		[Test]
		public void Contains_PointInside_True()
		{
			var target = new Rectangle(5, 10, 15, 20);

			for (int i = 0; i < 100; i++)
			{
                Assert.IsTrue(target.Contains(target.RandomPoint()));
			}
		}

        [Test]
        public void LeftTopPoint_NoArgs_Point()
		{
			var target = new Rectangle(10, 20, 30, 40);
            Assert.AreEqual(new Point(10, 20), target.LeftTopPoint());
		}

		[Test]
		public void RightTopPoint_NoArgs_Point()
		{
			var target = new Rectangle(10, 20, 30, 40);
			Assert.AreEqual(new Point(29, 20), target.RightTopPoint());
		}

		[Test]
		public void RightCenterPoint_NoArgs_Point()
		{
			var target = new Rectangle(10, 20, 30, 40);
			Assert.AreEqual(new Point(29, 30), target.RightCenterPoint());
		}

		[Test]
		public void RightBottomPoint_NoArgs_Point()
		{
			var target = new Rectangle(10, 20, 30, 40);
			Assert.AreEqual(new Point(29, 39), target.RightBottomPoint());
		}

		[Test]
		public void LeftBottomPoint_NoArgs_Point()
		{
			var target = new Rectangle(10, 20, 30, 40);
            Assert.AreEqual(new Point(10, 39), target.LeftBottomPoint());
		}

		[Test]
		public void LeftCenterPoint_NoArgs_Point()
		{
			var target = new Rectangle(10, 20, 30, 40);
			Assert.AreEqual(new Point(10, 30), target.LeftCenterPoint());
		}

		[Test]
		public void IsXBorder_X_Border()
		{
			var target = new Rectangle(10, 20, 30, 40);
            Assert.IsFalse(target.IsXBorder(1));
            Assert.IsFalse(target.IsXBorder(9));
			Assert.IsTrue(target.IsXBorder(10));
            Assert.IsTrue(target.IsXBorder(29));
		}

		[Test]
		public void IsYBorder_Y_Border()
		{
			var target = new Rectangle(10, 20, 30, 40);
			Assert.IsFalse(target.IsYBorder(1));
			Assert.IsFalse(target.IsYBorder(19));
			Assert.IsTrue(target.IsYBorder(20));
			Assert.IsTrue(target.IsYBorder(39));
		}

		[Test]
		public void IsBorder_XY_Border()
		{
			var target = new Rectangle(10, 20, 30, 40);
			Assert.IsFalse(target.IsBorder(1, 1));
			Assert.IsFalse(target.IsBorder(9, 19));
			Assert.IsTrue(target.IsBorder(10, 20));
			Assert.IsTrue(target.IsBorder(29, 39));
		}
	}
}
