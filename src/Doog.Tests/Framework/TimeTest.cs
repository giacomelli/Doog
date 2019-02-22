using NUnit.Framework;
using System;

namespace Doog.Tests.Framework
{
    [TestFixture]
    public class TimeTest
    {
        [Test]
        public void MarkAsGameStarted_NoArgs_GameAndSceneTimesStarted()
        {
            var target = new Time();
            var now = DateTime.Now;

			// Game not started yet.
		    target.Update(now.AddSeconds(10));
            Assert.AreEqual(0, target.SinceGameStart);
            Assert.AreEqual(0, target.SinceSceneStart);

            // Game started.
            target.MarkAsGameStarted(now);
          	target.Update(now.AddSeconds(15));
			Assert.GreaterOrEqual(target.SinceGameStart, 5);
            Assert.GreaterOrEqual(target.SinceSceneStart, 0);
        }

		[Test]
		public void MarkAsSceneStarted_NoArgs_SceneTimesStarted()
		{
			var target = new Time();
            var now = DateTime.Now; 

            // First scene
			target.MarkAsGameStarted(now);
			target.Update(now.AddSeconds(5));
			Assert.GreaterOrEqual(target.SinceGameStart, 5);
			Assert.GreaterOrEqual(target.SinceSceneStart, 0);

            // Second scene.
            target.MarkAsSceneStarted(now);
			target.Update(now.AddSeconds(10));
			Assert.GreaterOrEqual(target.SinceGameStart, 10);
			Assert.GreaterOrEqual(target.SinceSceneStart, 5);
		}
    }
}
