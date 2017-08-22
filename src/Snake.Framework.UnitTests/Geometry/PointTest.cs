using NUnit.Framework;
using Snake.Framework.Geometry;

namespace Snake.Framework.UnitTests.Geometry
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
    }
}
