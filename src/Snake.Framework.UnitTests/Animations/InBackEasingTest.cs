﻿using NUnit.Framework;
using Snake.Framework.Animations;

namespace Snake.Framework.UnitTests.Animations
{
    [TestFixture]
    public class InBackEasingTest
    {
        [Test]
        public void Calculate_FromTo_Value()
        {
            var target = new InBackEasing();
            Assert.AreEqual(10, target.Calculate(10, 110, 0));
			Assert.AreEqual(8.56857777f, target.Calculate(10, 110, 0.1f));
            Assert.AreEqual(1.2302494f, target.Calculate(10, 110, 0.5f));
			Assert.AreEqual(110, target.Calculate(10, 110, 1f));
        }
    }
}
