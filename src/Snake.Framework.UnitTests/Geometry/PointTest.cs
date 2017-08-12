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
    }
}
