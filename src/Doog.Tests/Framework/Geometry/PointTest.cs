using System.Collections.Generic;
using NUnit.Framework;
using Doog;

namespace Doog.Tests.Framework.Geometry
{
    [TestFixture]
    public class PointTest
    {
        [Test]
        public void DistanceFrom_Other_EucludianDistance()
        {
            var target = new Point(-1, 1);
            var other = new Point(3, 4);

            Assert.AreEqual(5, target.DistanceFrom(other));
        }

		[Test]
		public void Lerp_LowerToGreater_Value()
		{
			var from = new Point(1, 2);
			var to = new Point(3, 4);

			Assert.AreEqual(new Point(1, 2), Point.Lerp(from, to, 0));
            Assert.AreEqual(new Point(2, 3), Point.Lerp(from, to, 0.5f));
            Assert.AreEqual(new Point(3, 4), Point.Lerp(from, to, 1f));

			from = new Point(1, 2);
			to = new Point(-3, -4);

			Assert.AreEqual(new Point(1, 2), Point.Lerp(from, to, 0));
			Assert.AreEqual(new Point(-1, -1), Point.Lerp(from, to, 0.5f));
			Assert.AreEqual(new Point(-3, -4), Point.Lerp(from, to, 1f));
		}

        [Test]
        public void Dot_Points_Dot()
        {
            Assert.AreEqual(11, Point.Dot(new Point(1, 2), new Point (3, 4)));
        }

		[Test]
		public void PlusOperator_AB_PlusValues()
		{
			var a = new Point(-1, 1);
			var b = new Point(3, 4);

            Assert.AreEqual(new Point(2, 5), a + b);
		}

		[Test]
		public void MinusOperator_AB_MinusValues()
		{
			var a = new Point(-1, 1);
			var b = new Point(3, 4);

			Assert.AreEqual(new Point(-4, -3), a - b);
		}

		[Test]
		public void PlusOperator_AFloat_PlusValues()
		{
			var a = new Point(-1, 1);
            var b = 3f;

			Assert.AreEqual(new Point(2, 4), a + b);
		}

		[Test]
		public void MinusOperator_AFoat_MinusValues()
		{
			var a = new Point(-1, 1);
            var b = 3f;

			Assert.AreEqual(new Point(-4, -2), a - b);
		}

		[Test]
		public void TimesOperator_AFoat_TimesValues()
		{
			var a = new Point(-1, 2);
			var b = 3f;

			Assert.AreEqual(new Point(-3, 6), a * b);
		}

		[Test]
		public void DivisionOperator_AFoat_TimesValues()
		{
			var a = new Point(-3, 6);
			var b = 3f;

			Assert.AreEqual(new Point(-1, 2), a / b);
		}


		[Test]
        public void DiffOperator_Equals_False()
		{
			var a = new Point(1, 1);
			var b = new Point(1, 1);

			Assert.IsFalse(a != b);
		}

        [Test]
        public void DiffOperator_Diff_True()
		{
			var a = new Point(1, 1);
			var b = new Point(2, 1);

			Assert.IsTrue(a != b);
		}

		[Test]
		public void Equals_OtherNotAPoint_False()
		{
            var target = new Point(1, 2);

            Assert.IsFalse(target.Equals(1));
            Assert.IsFalse(target.Equals("1"));
		}

        [Test]
        public void Equals_DiffXOrY_False()
		{
			var target = new Point(1, 2);

            Assert.IsFalse(target.Equals(new Point(2, 1)));
			Assert.IsFalse(target.Equals(new Point(1, 1)));
		}

		[Test]
		public void Equals_EqualsXandY_True()
		{
			var target = new Point(1, 2);

			Assert.IsTrue(target.Equals(new Point(1, 2)));
		}

		[Test]
		public void GetHashCode_DiffPoints_DiffHashCode()
		{
            var hashes = new List<int>();

            for (int x = 0; x < 10; x++)
            {
				for (int y = 11; y < 21; y++)
				{
                    hashes.Add(new Point(x, y).GetHashCode());
				}   
            }

            CollectionAssert.AllItemsAreUnique(hashes);
		}

        [Test]
        public void ToString_NoArgs_XAndy()
        {
            var target = new Point(1, 2);

            Assert.AreEqual("X=1, Y=2", target.ToString());
        }

        [Test]
        public void Transform_Matrix_XAndYTranformed()
        {
            var target = new Point(10, 20);
            var matrix = new Matrix(1, 2, 3, 
                                    4, 5, 6, 
                                    7, 8, 9);

            var actual = target.Transform(matrix);

            Assert.AreEqual(53, actual.X);
            Assert.AreEqual(146, actual.Y);
        }
    }
}
