using System;
using NUnit.Framework;
using Rhino.Mocks;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Snake.Framework.Logging;

namespace Snake.Framework.UnitTests.Animations
{
    [TestFixture]
    public class AnimationPipelineTest
    {
        private IAnimation<Transform> firstAnimation;
        private IAnimation<Transform> secondAnimation;
        private AnimationPipeline<Transform> target;

        [SetUp]
        public void InitializeTest()
        {
            var ctx = MockRepository.GenerateMock<IWorldContext>();
            ctx.Expect(t => t.LogSystem).Return(MockRepository.GenerateMock<ILogSystem>());
           
            firstAnimation = MockRepository.GenerateMock<IAnimation<Transform>>();
            firstAnimation.Expect(t => t.Owner).Return(new Transform(ctx));
            target = AnimationPipeline<Transform>.Create(firstAnimation);
            Assert.AreEqual(1, target.Length);

            secondAnimation = MockRepository.GenerateMock<IAnimation<Transform>>();
            target.Add(secondAnimation);
			Assert.AreEqual(2, target.Length);

            Assert.AreEqual(AnimationState.NotPlayed, target.State);
		}

        [Test]
        public void Once_Finished_Destroyed()
        {
            firstAnimation.Expect(t => t.Play());
            secondAnimation.Expect(t => t.Play());
            secondAnimation.Expect(t => t.Pause());

            target.Once();

            Assert.AreEqual(PipelineKind.Once, target.Kind);

            firstAnimation.Raise(f => f.Ended += null, firstAnimation, EventArgs.Empty);
			secondAnimation.Raise(f => f.Ended += null, secondAnimation, EventArgs.Empty);

            Assert.AreEqual(0, target.Length);
            Assert.AreEqual(AnimationState.Stopped, target.State);

            firstAnimation.VerifyAllExpectations();
            secondAnimation.VerifyAllExpectations();
		}
    }
}
