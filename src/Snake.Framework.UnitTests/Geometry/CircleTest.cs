using NUnit.Framework;
using Snake.Framework.Geometry;

namespace Snake.Framework.UnitTests.Geometry
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
	}
}
