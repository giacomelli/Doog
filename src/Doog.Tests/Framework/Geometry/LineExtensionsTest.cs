using System.Collections.Generic;
using NUnit.Framework;
using Doog;

namespace Doog.Tests.Framework.Geometry
{
    [TestFixture]
    public class LineExtensionsTest
    {
        [Test]
        public void Iterate_Line_StepsCall()
        {
   
            for (float angle = 0; angle <= 360; angle++)
            {
                var line1 = new Line(Point.Zero, Circle.GetPoint(Point.Zero, 100, angle));
                var calledCount = 0;
                line1.Iterate((x, y) => calledCount++);
                Assert.GreaterOrEqual(calledCount, 50);

				var line2 = new Line(Circle.GetPoint(Point.Zero, 100, angle), Point.Zero);
				calledCount = 0;
				line2.Iterate((x, y) => calledCount++);
				Assert.GreaterOrEqual(calledCount, 50);
            }
        }
	}
}
