using NUnit.Framework;
using Snake.Framework.Geometry;

namespace Snake.Framework.UnitTests.Geometry
{
    [TestFixture]
    public class IntPointTest
    {
        [Test]
        public void DistanceFrom_Other_EucludianDistance()
        {
            var target = new IntPoint(-1, 1);
            var other = new IntPoint(3, 4);

            Assert.AreEqual(5, target.DistanceFrom(other));
        }
    }
}
