using System.Collections.Generic;
using NUnit.Framework;
using Doog;

namespace Doog.UnitTests.Geometry
{
    [TestFixture]
    public class CircleExtensionsTest
    {
        [Test]
        public void Iterate_RadiusStepNonPositive_Exception()
        {
            var ex = Assert.Catch(delegate { new Circle(1, 2, 0).Iterate((x, y) => { }, 0); });
            StringAssert.Contains("radiusStep should be a non-zero positive value.", ex.Message);
        }

		[Test]
		public void Iterate_DegreesStepSizeNonPositive_Exception()
		{
			var ex = Assert.Catch(delegate { new Circle(1, 2, 0).Iterate((x, y) => { }, 1, 0); });
			StringAssert.Contains("degreesStepSize should be a non-zero positive value.", ex.Message);
		}

        [Test]
        public void Iterate_RadiusStepAndDegreeStepSize_StepsCall()
        {
            var count = 0;
            var target = new Circle(new Point(1, 1), 1);
            target.Iterate((x, y) => {
                count++;
            }, 1, 1);
            Assert.AreEqual(360, count);


			count = 0;
			target = new Circle(new Point(10, 20), 1);
			target.Iterate((x, y) =>
			{
				count++;
			}, 1, 1);
			Assert.AreEqual(360, count);

			count = 0;
			target = new Circle(new Point(10, 20), 2);
			target.Iterate((x, y) =>
			{
				count++;
			}, 1, 1);
			Assert.AreEqual(720, count);

			count = 0;
			target = new Circle(new Point(10, 20), 2);
			target.Iterate((x, y) =>
			{
				count++;
			}, 2, 1);
			Assert.AreEqual(360, count);

			count = 0;
			target = new Circle(new Point(10, 20), 2);
			target.Iterate((x, y) =>
			{
				count++;
			}, 2, 2);
			Assert.AreEqual(180, count);

			count = 0;
			target = new Circle(new Point(10, 20), 2);
			target.Iterate((x, y) =>
			{
				count++;
			}, 2, 80);
			Assert.AreEqual(5, count);
        }
	}
}
