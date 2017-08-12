using NUnit.Framework;
using System;
using System.Threading;

namespace Snake.Framework.UnitTests
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
            Assert.AreEqual(0, target.SinceGameStart.TotalSeconds);
            Assert.AreEqual(0, target.SinceSceneStart.TotalSeconds);

            // Game started.
            target.MarkAsGameStarted(now);
          	target.Update(now.AddSeconds(15));
			Assert.GreaterOrEqual(target.SinceGameStart.TotalSeconds, 5);
            Assert.GreaterOrEqual(target.SinceSceneStart.TotalSeconds, 0);
        }

		[Test]
		public void MarkAsSceneStarted_NoArgs_SceneTimesStarted()
		{
			var target = new Time();
            var now = DateTime.Now; 

            // First scene
			target.MarkAsGameStarted(now);
			target.Update(now.AddSeconds(5));
			Assert.GreaterOrEqual(target.SinceGameStart.TotalSeconds, 5);
			Assert.GreaterOrEqual(target.SinceSceneStart.TotalSeconds, 0);

            // Second scene.
            target.MarkAsSceneStarted(now);
			target.Update(now.AddSeconds(10));
			Assert.GreaterOrEqual(target.SinceGameStart.TotalSeconds, 10);
			Assert.GreaterOrEqual(target.SinceSceneStart.TotalSeconds, 5);
		}
    }
}
