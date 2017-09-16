using NUnit.Framework;
using Rhino.Mocks;
using Doog.Framework.Animations;
using Doog.Framework.Geometry;
using Doog.Framework.Logging;

namespace Doog.Framework.UnitTests.Animations
{
    [TestFixture]
    public class PositionAnimationTest
    {
        [Test]
        public void Update_Time_UpdateValue()
        {
            var sinceSceneStart = 0f;
            var ctx = MockRepository.GenerateMock<IWorldContext>();
            ctx.Expect(t => t.LogSystem).Return(MockRepository.GenerateMock<ILogSystem>());

            var time = MockRepository.GenerateMock<ITime>();
            time.Expect(t => t.SinceSceneStart).WhenCalled(m =>
            {
                m.ReturnValue = sinceSceneStart;
                sinceSceneStart += 2.5f;
            }).Return(0);
            ctx.Expect(t => t.Time).Return(time);

            var owner = new Transform(1, 2, ctx);
            var target = new PositionAnimation(owner, new Point(3, 4), 5);

            target.Play();
            Assert.AreEqual(new Point(1, 2), owner.Position);

            target.Pause();
			target.Update();
			Assert.AreEqual(new Point(1, 2), owner.Position);

            target.Resume();
            sinceSceneStart -= 2.5f;
            target.Update();
			Assert.AreEqual(new Point(2, 3), owner.Position);

			target.Update();
			Assert.AreEqual(new Point(3, 4), owner.Position);
            Assert.AreEqual(AnimationState.Playing, target.State);

            target.Reset();
			target.Play();
			Assert.AreEqual(new Point(1, 2), owner.Position);
            Assert.AreEqual(AnimationState.Playing, target.State);

            target.Update();
            target.Update();
            target.Update();
            Assert.AreEqual(new Point(3, 4), owner.Position);
            Assert.AreEqual(AnimationState.Stopped, target.State);
        }
    }
}
