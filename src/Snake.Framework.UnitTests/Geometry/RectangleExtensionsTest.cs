using System.Collections.Generic;
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

			for (int i = 0; i < 10000; i++)
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
		public void BottomCenterPoint_NoArgs_Point()
		{
			var target = new Rectangle(10, 20, 30, 40);
			Assert.AreEqual(new Point(20, 39), target.BottomCenterPoint());
		}

		[Test]
		public void TopCenterPoint_NoArgs_Point()
		{
			var target = new Rectangle(10, 20, 30, 40);
			Assert.AreEqual(new Point(20, 20), target.TopCenterPoint());
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

        [Test]
        public void Iterate_FilledFalse_OnlyBorders()
        {
            var actualPoints = new List<Point>();
            var target = new Rectangle(10, 20, 15, 25);
            target.Iterate(false, (x, y) =>
            {
                actualPoints.Add(new Point(x, y));
            });

            var expectedPoints = new Point[]
            {
                // Top line
                new Point(10, 20), new Point(11, 20), new Point(12, 20), new Point(13, 20), new Point(14, 20),

                // Right line
                new Point(14, 21), new Point(14, 22), new Point(14, 23), 

                // bottom line
                new Point(14, 24), new Point(13, 24), new Point(12, 24), new Point(11, 24), new Point(10, 24),

                 // Right line
                new Point(10, 23), new Point(10, 22), new Point(10, 21)
            };

            CollectionAssert.AreEqual(expectedPoints, actualPoints.ToArray());
        }

        [Test]
        public void Iterate_FilledTrue_EveryPoint()
        {
            var actualPoints = new List<Point>();
            var target = new Rectangle(10, 20, 15, 25);
            target.Iterate(true, (x, y) =>
            {
                actualPoints.Add(new Point(x, y));
            });

            var expectedPoints = new Point[]
            {
                // First row
                new Point(10, 20), new Point(10, 21), new Point(10, 22), new Point(10, 23), new Point(10, 24),

                // Second row
                new Point(11, 20), new Point(11, 21), new Point(11, 22), new Point(11, 23), new Point(11, 24),

                // Third row
                new Point(12, 20), new Point(12, 21), new Point(12, 22), new Point(12, 23), new Point(12, 24),

                // Fourth row
                new Point(13, 20), new Point(13, 21), new Point(13, 22), new Point(13, 23), new Point(13, 24),

                // Fifth row
                new Point(14, 20), new Point(14, 21), new Point(14, 22), new Point(14, 23), new Point(14, 24)
            };

            CollectionAssert.AreEqual(expectedPoints, actualPoints.ToArray());
        }

        [Test]
        public void Iterate_FilledFalseYOne_OnlyTopLine()
        {
            var actualPoints = new List<Point>();
            var target = new Rectangle(1, 1, 4, 2);
            target.Iterate(false, (x, y) =>
            {
                actualPoints.Add(new Point(x, y));
            });

            var expectedPoints = new Point[]
            {
                // Top line
                new Point(1, 1), new Point(2, 1), new Point(3, 1)
            };

            CollectionAssert.AreEqual(expectedPoints, actualPoints.ToArray());
        }

        [Test]
        public void Iterate_FilledTrueYOne_OnlyTopLine()
        {
            var actualPoints = new List<Point>();
            var target = new Rectangle(1, 1, 4, 2);
            target.Iterate(true, (x, y) =>
            {
                actualPoints.Add(new Point(x, y));
            });

            var expectedPoints = new Point[]
            {
                // Top line
                new Point(1, 1), new Point(2, 1), new Point(3, 1)
            };

            CollectionAssert.AreEqual(expectedPoints, actualPoints.ToArray());
        }

        [Test]
        public void Iterate_FilledFalseXOne_OnlyLeftLine()
        {
            var actualPoints = new List<Point>();
            var target = new Rectangle(1, 1, 2, 4);
            target.Iterate(false, (x, y) =>
            {
                actualPoints.Add(new Point(x, y));
            });

            var expectedPoints = new Point[]
            {
                // Left line
                new Point(1, 1), new Point(1, 2), new Point(1, 3)
            };

            CollectionAssert.AreEqual(expectedPoints, actualPoints.ToArray());
        }

        [Test]
        public void Iterate_FilledTrueXOne_OnlyLeftLine()
        {
            var actualPoints = new List<Point>();
            var target = new Rectangle(1, 1, 2, 4);
            target.Iterate(true, (x, y) =>
            {
                actualPoints.Add(new Point(x, y));
            });

            var expectedPoints = new Point[]
            {
                // Left line
                new Point(1, 1), new Point(1, 2), new Point(1, 3)
            };

            CollectionAssert.AreEqual(expectedPoints, actualPoints.ToArray());
        }
    }
}
