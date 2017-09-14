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
			var target = new Rectangle(5, 10, 10, 10);
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
			Assert.AreEqual(new Point(40, 20), target.RightTopPoint());
		}

		[Test]
		public void RightCenterPoint_NoArgs_Point()
		{
			var target = new Rectangle(10, 20, 30, 40);
			Assert.AreEqual(new Point(40, 40), target.RightCenterPoint());
		}

		[Test]
		public void RightBottomPoint_NoArgs_Point()
		{
			var target = new Rectangle(10, 20, 30, 40);
			Assert.AreEqual(new Point(40, 60), target.RightBottomPoint());
		}

		[Test]
		public void LeftBottomPoint_NoArgs_Point()
		{
			var target = new Rectangle(10, 20, 30, 40);
            Assert.AreEqual(new Point(10, 60), target.LeftBottomPoint());
		}

		[Test]
		public void LeftCenterPoint_NoArgs_Point()
		{
			var target = new Rectangle(10, 20, 30, 40);
			Assert.AreEqual(new Point(10, 40), target.LeftCenterPoint());
		}

		[Test]
		public void BottomCenterPoint_NoArgs_Point()
		{
			var target = new Rectangle(10, 20, 30, 40);
			Assert.AreEqual(new Point(25, 60), target.BottomCenterPoint());
		}

		[Test]
		public void TopCenterPoint_NoArgs_Point()
		{
			var target = new Rectangle(10, 20, 30, 40);
			Assert.AreEqual(new Point(25, 20), target.TopCenterPoint());
		}

		[Test]
		public void IsXBorder_X_Border()
		{
			var target = new Rectangle(10, 20, 30, 40);
            Assert.IsFalse(target.IsXBorder(1));
            Assert.IsFalse(target.IsXBorder(9));
			Assert.IsTrue(target.IsXBorder(10));
            Assert.IsTrue(target.IsXBorder(40));

			target = new Rectangle(1, 2, 0, 0);
			Assert.IsFalse(target.IsXBorder(0));
			Assert.IsFalse(target.IsXBorder(2));
			Assert.IsTrue(target.IsXBorder(1));
		}

		[Test]
		public void IsYBorder_Y_Border()
		{
			var target = new Rectangle(10, 20, 30, 40);
			Assert.IsFalse(target.IsYBorder(1));
			Assert.IsFalse(target.IsYBorder(19));
			Assert.IsTrue(target.IsYBorder(20));
			Assert.IsTrue(target.IsYBorder(60));

			target = new Rectangle(2, 1, 0, 0);
			Assert.IsFalse(target.IsYBorder(0));
			Assert.IsFalse(target.IsYBorder(2));
			Assert.IsTrue(target.IsYBorder(1));
		}

		[Test]
		public void IsBorder_XY_Border()
		{
			var target = new Rectangle(10, 20, 30, 40);
			Assert.IsFalse(target.IsBorder(1, 1));
			Assert.IsFalse(target.IsBorder(9, 19));
			Assert.IsTrue(target.IsBorder(10, 20));
			Assert.IsTrue(target.IsBorder(40, 60));
		}

        [Test]
        public void Iterate_FilledFalse_OnlyBorders()
        {
            var actualPoints = new List<Point>();
            var target = new Rectangle(10, 20, 5, 5);
            target.Iterate(false, (x, y) =>
            {
                actualPoints.Add(new Point(x, y));
            });

            var expectedPoints = new Point[]
            {
                // Top line
                new Point(10, 20), new Point(11, 20), new Point(12, 20), new Point(13, 20), new Point(14, 20), new Point(15, 20),

                // Right line
                new Point(15, 20), new Point(15, 21), new Point(15, 22), new Point(15, 23), new Point(15, 24), new Point(15, 25),

                // bottom line
                new Point(15, 25), new Point(14, 25), new Point(13, 25), new Point(12, 25), new Point(11, 25), new Point(10, 25),

                // Right line
                new Point(10, 25), new Point(10, 24), new Point(10, 23), new Point(10, 22), new Point(10, 21), new Point(10, 20)
            };

            CollectionAssert.AreEqual(expectedPoints, actualPoints.ToArray());
        }

        [Test]
        public void Iterate_FilledTrue_EveryPoint()
        {
            var actualPoints = new List<Point>();
            var target = new Rectangle(10, 20, 5, 5);
            target.Iterate(true, (x, y) =>
            {
                actualPoints.Add(new Point(x, y));
            });

            Assert.AreEqual(216, actualPoints.Count);
        }

        [Test]
        public void Iterate_FilledFalseHeightZero_OnlyTopLine()
        {
            var actualPoints = new List<Point>();
            var target = new Rectangle(1, 1, 2, 0);
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
        public void Iterate_FilledTrueHeightZero_OnlyTopLine()
        {
            var actualPoints = new List<Point>();
            var target = new Rectangle(1, 1, 2, 0);
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
        public void Iterate_FilledFalseWidthZero_OnlyLeftLine()
        {
            var actualPoints = new List<Point>();
            var target = new Rectangle(1, 1, 0, 2);
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
        public void Iterate_FilledTrueWidthZero_OnlyLeftLine()
        {
            var actualPoints = new List<Point>();
            var target = new Rectangle(1, 1, 0, 2);
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
