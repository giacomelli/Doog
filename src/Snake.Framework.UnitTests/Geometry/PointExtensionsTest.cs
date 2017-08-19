using NUnit.Framework;
using System;
using Snake.Framework.Geometry;

namespace Snake.Framework.UnitTests.Geometry
{
    [TestFixture]
    public class PointExtensionsTest
    {
        [Test]
        public void Round_FloatValues_RoundValues()
        {
            var target = new Point(0.4f, 1.9f).Round();
            Assert.AreEqual(0f, target.X);
			Assert.AreEqual(2f, target.Y);

			target = new Point(1.9f, 0.4f).Round();
			Assert.AreEqual(2f, target.X);
			Assert.AreEqual(0f, target.Y);

			target = new Point(-1.9f, -0.4f).Round();
			Assert.AreEqual(-2f, target.X);
			Assert.AreEqual(0f, target.Y);
        }
    }
}
