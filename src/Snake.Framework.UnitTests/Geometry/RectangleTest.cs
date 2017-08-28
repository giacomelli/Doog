using System.Collections.Generic;
using NUnit.Framework;
using Snake.Framework.Geometry;

namespace Snake.Framework.UnitTests.Geometry
{
    [TestFixture]
    public class RectangleTest
    {
        [Test]
        public void Contains_PointOutside_False()
        {
            var target = new Rectangle(0, 1, 10, 11);

            Assert.IsFalse(target.Contains(-1, 1));
            Assert.IsFalse(target.Contains(0, 0));
            Assert.IsFalse(target.Contains(11, 1));
            Assert.IsFalse(target.Contains(10, 12));
        }

        [Test]
        public void Contains_PoinInside_True()
        {
            var target = new Rectangle(0, 1, 10, 11);

            Assert.IsTrue(target.Contains(0, 1));
            Assert.IsTrue(target.Contains(1, 2));
            Assert.IsTrue(target.Contains(10, 11));
            Assert.IsTrue(target.Contains(0, 11));

            for (int x = (int)target.Left; x < target.Right; x++)
            {
                for (int y = (int)target.Top; y < target.Bottom; y++)
                {
                    Assert.IsTrue(target.Contains(x, y), "{0}, {1}", x, y);
                }
            }
        }

        [Test]
        public void Intersect_NonInterserction_False()
        {
            var target = new Rectangle(5, 10, 15, 20);
            Assert.IsFalse(target.Intersect(new Rectangle(3, 8, 4, 9)));
            Assert.IsFalse(target.Intersect(new Rectangle(1, 21, 10, 23)));

            target = new Rectangle(0, 0, 1, 1);
            Assert.IsFalse(target.Intersect(new Rectangle(1, 1, 1, 1)));
            Assert.IsFalse(target.Intersect(new Rectangle(0, 0, 0, 0)));

            target = new Rectangle(0, 0, 1, 1);
            Assert.IsFalse(target.Intersect(new Rectangle(1, 1, 1, 1)));
            Assert.IsFalse(target.Intersect(new Rectangle(0, 0, 0, 0)));

            target = new Rectangle(1, 1, 2, 2);
            Assert.IsFalse(target.Intersect(new Rectangle(0, 0, 1, 1)));

			target = new Rectangle(1, 22, 2, 23);
			Assert.IsFalse(target.Intersect(new Rectangle(1, 10, 2, 11)));

            // Width and Height zero
			target = new Rectangle(1, 1, 1, 1);
			Assert.IsFalse(target.Intersect(new Rectangle(1, 1, 1, 1)));
        }

		[Test]
		public void Intersect_Intersection_True()
		{
			var target = new Rectangle(5, 10, 15, 20);
			Assert.IsTrue(target.Intersect(new Rectangle(3, 8, 6, 11)));
			Assert.IsTrue(target.Intersect(new Rectangle(6, 11, 7, 12)));

			target = new Rectangle(1, 1, 10, 10);
			Assert.IsTrue(target.Intersect(new Rectangle(1, 1, 10, 10)));
		}

		[Test]
		public void GetCenter_NoArgs_CenterPoint()
		{
			var target = new Rectangle(0, 0, 15, 20);
			var actual = target.GetCenter();
			Assert.AreEqual(7.5f, actual.X);
			Assert.AreEqual(10, actual.Y);

			target = new Rectangle(5, 10, 15, 20);
			actual = target.GetCenter();
			Assert.AreEqual(10, actual.X);
			Assert.AreEqual(15, actual.Y);
		}

		[Test]
		public void Scale_Scale_NewRectangleScaled()
		{
			var target = new Rectangle(5, 10, 15, 20);
			var actual = target.Scale(2);
			Assert.AreEqual(5, actual.Left);
			Assert.AreEqual(10, actual.Top);
			Assert.AreEqual(30, actual.Right);
			Assert.AreEqual(40, actual.Bottom);

			actual = target.Scale(0.5f);
			Assert.AreEqual(5, actual.Left);
			Assert.AreEqual(10, actual.Top);
			Assert.AreEqual(7.5, actual.Right);
			Assert.AreEqual(10, actual.Bottom);
		}

		[Test]
		public void Width_LetfRight_Diff()
		{
			var target = new Rectangle(5, 10, 55, 20);
            Assert.AreEqual(50, target.Width);
		}

		[Test]
		public void Height_TopBottom_Diff()
		{
			var target = new Rectangle(5, 10, 55, 20);
			Assert.AreEqual(10, target.Height);
		}

		[Test]
		public void Equals_NotRectangle_False()
		{
			var target = new Rectangle(5, 10, 55, 20);
			Assert.IsFalse(target.Equals(1));
            Assert.IsFalse(target.Equals("1"));
		}

		[Test]
		public void Equals_NotEquals_False()
		{
			var target = new Rectangle(5, 10, 55, 20);
            Assert.IsFalse(target.Equals(new Rectangle(1, 10, 55, 20)));
			Assert.IsFalse(target.Equals(new Rectangle(5, 1, 55, 20)));
            Assert.IsFalse(target.Equals(new Rectangle(5, 10, 1, 20)));
            Assert.IsFalse(target.Equals(new Rectangle(5, 10, 55, 1)));
		}

		[Test]
		public void Equals_Equals_True()
		{
			var target = new Rectangle(5, 10, 55, 20);
			Assert.IsTrue(target.Equals(new Rectangle(5, 10, 55, 20)));
		}

		[Test]
		public void GetHashCode_DiffRectangles_DiffHashCode()
		{
			var hashes = new List<int>();

            for (int x = 0; x < 10; x++)
            {
				for (int y = 11; y < 20; y++)
				{
                    hashes.Add(new Rectangle(x, y, x + 10, y + 20).GetHashCode());
				}
            }

            CollectionAssert.AllItemsAreUnique(hashes);
		}

        [Test]
        public void DiffOperator_Equals_False()
        {
            var a = new Rectangle(5, 10, 55, 20);
            var b = new Rectangle(5, 10, 55, 20);

            Assert.IsFalse(a != b);
        }

        [Test]
        public void DiffOperator_Diff_True()
		{
			var a = new Rectangle(5, 10, 55, 20);
			var b = new Rectangle(5, 10, 55, 21);

			Assert.IsTrue(a != b);
		}

		[Test]
		public void MultiplyOperator_Float_WidthAndHeightMultiplied()
		{
            var actual = new Rectangle(5, 10, 55, 20) * 10f;

            Assert.AreEqual(new Rectangle(5, 10, 550, 200), actual);
		}

		[Test]
		public void SumOperator_Rectangle_Sum()
		{
			var actual = new Rectangle(5, 10, 55, 20) + new Rectangle(1, 2, 3, 4);

			Assert.AreEqual(new Rectangle(6, 12, 58, 24), actual);
		}
	}
}
