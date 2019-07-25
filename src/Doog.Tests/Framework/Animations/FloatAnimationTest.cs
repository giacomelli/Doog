using NUnit.Framework;
using NSubstitute;

namespace Doog.Tests.Framework.Animations
{
    [TestFixture]
    public class FloatAnimationTest
    {
        [Test]
        public void Update_Time_UpdateValue()
        {
            var sinceSceneStart = 0f;
            var ctx = Substitute.For<IWorldContext>();
            ctx.LogSystem.Returns(Substitute.For<ILogSystem>());

            var time = Substitute.For<ITime>();
            time.SinceSceneStart.Returns(c =>
            {
                var r = sinceSceneStart;
                sinceSceneStart += 2.5f;

                return r;
            });
            ctx.Time.Returns(time);

            var owner = new Transform(ctx);
            float currentValue = 0;
            var target = new FloatAnimation<Transform>(owner, 1, 3, 5, v => currentValue = v);

            target.Play();
            Assert.AreEqual(0, currentValue);

            target.Pause();
            target.Update();
            Assert.AreEqual(0, currentValue);

            target.Resume();
            sinceSceneStart -= 2.5f;
            target.Update();
            Assert.AreEqual(2, currentValue);

            target.Update();
            Assert.AreEqual(3, currentValue);
            Assert.AreEqual(AnimationState.Playing, target.State);

            target.Reset();
            target.Play();
            Assert.AreEqual(1, currentValue);
            Assert.AreEqual(AnimationState.Playing, target.State);

            target.Update();
            target.Update();
            target.Update();
            Assert.AreEqual(3, currentValue);
            Assert.AreEqual(AnimationState.Stopped, target.State);
        }
    }
}
