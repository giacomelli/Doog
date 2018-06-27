using NUnit.Framework;
using NSubstitute;

namespace Doog.Framework.UnitTests.Animations
{
    [TestFixture]
    public class PointAnimationTest
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

            var owner = new Transform(1, 2, ctx);
            var currentPoint = Point.Zero;
            var target = new PointAnimation<Transform>(owner, (arg) => new Point(1, 2), new Point(3, 4), 5, v => currentPoint = v);

            target.Play();
            Assert.AreEqual(Point.Zero, currentPoint);

            target.Pause();
			target.Update();
			Assert.AreEqual(Point.Zero, currentPoint);

            target.Resume();
            sinceSceneStart -= 2.5f;
            target.Update();
			Assert.AreEqual(new Point(2, 3), currentPoint);

			target.Update();
			Assert.AreEqual(new Point(3, 4), currentPoint);
            Assert.AreEqual(AnimationState.Playing, target.State);

            target.Reset();
			target.Play();
			Assert.AreEqual(new Point(1, 2), currentPoint);
            Assert.AreEqual(AnimationState.Playing, target.State);

            target.Update();
            target.Update();
            target.Update();
            Assert.AreEqual(new Point(3, 4), currentPoint);
            Assert.AreEqual(AnimationState.Stopped, target.State);
        }
    }
}
