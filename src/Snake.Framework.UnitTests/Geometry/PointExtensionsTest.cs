using NUnit.Framework;
using System;
using Snake.Framework.Geometry;

namespace Snake.Framework.UnitTests.Geometry
{
    [TestFixture]
    public class PointExtensionsTest
    {
        [Test]
        public void Truncate_FloatValues_TruncatedValues()
        {
            var target = new Point(0.4f, 1.9f).Truncate();
            Assert.AreEqual(0f, target.X);
			Assert.AreEqual(1f, target.Y);

			target = new Point(1.9f, 0.4f).Truncate();
			Assert.AreEqual(1f, target.X);
			Assert.AreEqual(0f, target.Y);
        }
    }
}
