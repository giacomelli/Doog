﻿using NUnit.Framework;
using Rhino.Mocks;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Snake.Framework.Logging;

namespace Snake.Framework.UnitTests.Animations
{
    [TestFixture]
    public class PointAnimationTest
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
