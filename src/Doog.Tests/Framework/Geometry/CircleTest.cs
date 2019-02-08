using NUnit.Framework;
using Doog;

namespace Doog.UnitTests.Geometry
{
    [TestFixture]
    public class CircleTsst
    {
        [Test]
        public void Construcor_Arguments_Properties()
        {
            var target = new Circle(new Point(10, 20), 4);
		
            Assert.AreEqual(10, target.Left);
            Assert.AreEqual(20, target.Top);
			Assert.AreEqual(18, target.Right);
            Assert.AreEqual(28, target.Bottom);
	    }

		[Test]
		public void GetPoint_PositionRadiusAndAngle_Point()
		{
            var position = new Point(10, 20);
            var actual = Circle.GetPoint(position, 30, 0);
            Assert.AreEqual(new Point(40, 20), actual);

			actual = Circle.GetPoint(position, 30, 90);
			Assert.AreEqual(new Point(10, 50), actual);

			actual = Circle.GetPoint(position, 30, 180);
            Assert.AreEqual(new Point(-20, 20), actual);

			actual = Circle.GetPoint(position, 30, 270);
			Assert.AreEqual(new Point(10, -10), actual);

			actual = Circle.GetPoint(position, 30, -90);
			Assert.AreEqual(new Point(10, -10), actual);

			actual = Circle.GetPoint(position, 30, 360);
			Assert.AreEqual(new Point(40, 20), actual);

			actual = Circle.GetPoint(position, 30, 450);
			Assert.AreEqual(new Point(10, 50), actual);
		}
	}
}
