﻿using NUnit.Framework;
using Snake.Framework.Animations;

namespace Snake.Framework.UnitTests.Animations
{
    [TestFixture]
    public class LinearEasingTest
    {
        [Test]
        public void Calculate_FromLowerThanTo_Value()
        {
            var target = new LinearEasing();
            Assert.AreEqual(10, target.Calculate(10, 110, 0));
			Assert.AreEqual(20, target.Calculate(10, 110, 0.1f));
            Assert.AreEqual(60, target.Calculate(10, 110, 0.5f));
			Assert.AreEqual(110, target.Calculate(10, 110, 1f));
        }

		[Test]
		public void Calculate_FromGreaterThanTo_Value()
		{
			var target = new LinearEasing();
			Assert.AreEqual(110, target.Calculate(110, 10, 0));
			Assert.AreEqual(100, target.Calculate(110, 10, 0.1f));
			Assert.AreEqual(60, target.Calculate(110, 10, 0.5f));
			Assert.AreEqual(10, target.Calculate(110, 10, 1f));

			Assert.AreEqual(90, target.Calculate(90, -10, 0));
			Assert.AreEqual(80, target.Calculate(90, -10, 0.1f));
			Assert.AreEqual(40, target.Calculate(90, -10, 0.5f));
			Assert.AreEqual(-10, target.Calculate(90, -10, 1f));

            Assert.AreEqual(-100, target.Calculate(90, -100, 1f));
		}
    }
}
