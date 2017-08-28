﻿using NUnit.Framework;
using Snake.Framework.Animations;

namespace Snake.Framework.UnitTests.Animations
{
    [TestFixture]
    public class BackEasingsTest
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
    }
}
