using NSubstitute;
using NUnit.Framework;

namespace Doog.Framework.UnitTests.Animations
{
    [TestFixture]
    public class AnimationBaseTest
    {
        [Test]
        public void Update_PlayStartedTimeGreaterThanSinceSceneStart_DoNotUpdate()
        {
            var sinceSceneStart = 0f;
            var ctx = Substitute.For<IWorldContext>();
            ctx.LogSystem.Returns(Substitute.For<ILogSystem>());

            var time = Substitute.For<ITime>();
            time.SinceSceneStart.Returns (c => sinceSceneStart);
            ctx.Time.Returns(time);

            var owner = new Transform(ctx);
            float currentValue = 0;
            var target = new FloatAnimation<Transform>(owner, 1, 3, 5, v => currentValue = v);

            var hasStarted = false;
            var hasEnded = false;
            target.Started += (sender, e) => hasStarted = true;
			target.Ended += (sender, e) => hasEnded = true;

            target.Play();
            sinceSceneStart = 0;
            target.Update();
            Assert.AreEqual(1, currentValue);
            Assert.IsTrue(hasStarted);
            Assert.IsFalse(hasEnded);

            sinceSceneStart = 2.5f;
			target.Update();
			Assert.AreEqual(2, currentValue);

			sinceSceneStart = -1f;
			target.Update();
			Assert.AreEqual(2, currentValue);

            sinceSceneStart = 2.5f;
            target.Enabled = false;
			sinceSceneStart = 5f;
			target.Update();
			Assert.AreEqual(2, currentValue);
			Assert.IsFalse(hasEnded);

            sinceSceneStart = 3f;
			target.Enabled = true;
			sinceSceneStart = 5.51f;
			target.Update();
			Assert.AreEqual(3, currentValue);

            Assert.AreEqual(AnimationState.Stopped, target.State);
    		Assert.IsTrue(hasEnded);
		}

        [Test]
        public void ToString_OwnerFromTo_String()
        {
            var ctx = Substitute.For<IWorldContext>();
            var owner = new Transform(ctx);
            var target = new FloatAnimation<Transform>(owner, 1, 3, 5, v => {});
            Assert.AreEqual("FloatAnimation<Transform>(1..3 in 5s)", target.ToString());
        }

		[Test]
		public void Reverse_FromTo_ToFrom()
		{
			var sinceSceneStart = 0f;
			var ctx = Substitute.For<IWorldContext>();
            ctx.LogSystem.Returns(Substitute.For<ILogSystem>());

            var time = Substitute.For<ITime>();
            time.SinceSceneStart.Returns(c => sinceSceneStart);
            ctx.Time.Returns(time);

            var owner = new Transform(ctx);
			float currentValue = 0;
            var target = new FloatAnimation<Transform>(owner, 1, 3, 5, v => currentValue = v);

			var hasStarted = false;
			var hasEnded = false;
			target.Started += (sender, e) => hasStarted = true;
			target.Ended += (sender, e) => hasEnded = true;

            target.Reverse();
			target.Play();
			sinceSceneStart = 0;
			target.Update();
			Assert.AreEqual(3, currentValue);
			Assert.IsTrue(hasStarted);
			Assert.IsFalse(hasEnded);

			sinceSceneStart = 2.5f;
			target.Update();
			Assert.AreEqual(2, currentValue);

            sinceSceneStart = 5f;
			target.Update();
			Assert.AreEqual(1, currentValue);

			sinceSceneStart = 5.51f;
			target.Update();
			Assert.AreEqual(1, currentValue);

			Assert.AreEqual(AnimationState.Stopped, target.State);
			Assert.IsTrue(hasEnded);
		}
    }
}
