using NUnit.Framework;
using Rhino.Mocks;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Snake.Framework.Logging;

namespace Snake.Framework.UnitTests.Animations
{
    [TestFixture]
    public class FloatAnimationTest
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
