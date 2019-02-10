using System;
using NUnit.Framework;

namespace Doog.Tests.Framework.Animations.Easings
{
    [TestFixture]
    public class EasingTest
    {
        [Test]
        public void Calculate_InBack_Value()
        {
            foreach(var easing in Easing.All)
            {
				Assert.AreEqual(10, easing.Calculate(10, 110, 0));
				Assert.AreEqual(110, easing.Calculate(10, 110, 1f));

                for (var time = 0f; time <= 1f; time += 0.1f)
                {
                    easing.Calculate(time);
                }
            }
        }

		[Test]
		public void Random_All_Rand()
		{
            var actual = Easing.Random();

            CollectionAssert.Contains(Easing.All, actual);
		}

        [Test]
        public void Constants_HalfPI_Value()
        {
            Assert.AreEqual(1.57079637f, EasingConstants.HalfPI);
        }
    }
}
