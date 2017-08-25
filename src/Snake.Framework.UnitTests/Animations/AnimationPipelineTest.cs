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
            firstAnimation.Expect(t => t.State).Return(AnimationState.NotPlayed);
            firstAnimation.Expect(t => t.Direction).Return(AnimationDirection.Any);
            target = AnimationPipeline<Transform>.Create(firstAnimation);
            Assert.AreEqual(1, target.Length);

            secondAnimation = MockRepository.GenerateMock<IAnimation<Transform>>();
            secondAnimation.Expect(t => t.Direction).Return(AnimationDirection.Any);
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

            var controller = target.Once();

            Assert.AreEqual(PipelineKind.Once, target.Kind);

            firstAnimation.Raise(f => f.Ended += null, firstAnimation, EventArgs.Empty);
			secondAnimation.Raise(f => f.Ended += null, secondAnimation, EventArgs.Empty);

            Assert.AreEqual(0, target.Length);
            Assert.AreEqual(AnimationState.Stopped, target.State);

            Assert.AreEqual(AnimationState.Stopped, controller.State);
            firstAnimation.VerifyAllExpectations();
            secondAnimation.VerifyAllExpectations();
		}

		[Test]
		public void Loop_TimesAndFinished_Destroyed()
		{
			firstAnimation.Expect(t => t.Play()).Repeat.Times(2);
            secondAnimation.Expect(t => t.Play()).Repeat.Times(2);
			secondAnimation.Expect(t => t.Pause());

			var controller = target.Loop(2);

			Assert.AreEqual(PipelineKind.Loop, target.Kind);
			Assert.AreSame(firstAnimation, target.Get(0));
			Assert.AreSame(secondAnimation, target.Get(1));

            // First time
      		firstAnimation.Raise(f => f.Ended += null, firstAnimation, EventArgs.Empty);
      		secondAnimation.Raise(f => f.Ended += null, secondAnimation, EventArgs.Empty);
      		Assert.AreEqual(2, target.Length);
            Assert.AreSame(firstAnimation, target.Get(0));
            Assert.AreSame(secondAnimation, target.Get(1));

			// Second time
			firstAnimation.Raise(f => f.Ended += null, firstAnimation, EventArgs.Empty);
			secondAnimation.Raise(f => f.Ended += null, secondAnimation, EventArgs.Empty);
			Assert.AreEqual(0, target.Length);

            Assert.AreEqual(AnimationState.Stopped, controller.State);
			firstAnimation.VerifyAllExpectations();
			secondAnimation.VerifyAllExpectations();
		}

		[Test]
		public void PingPong_TimesAndFinished_Destroyed()
		{
			firstAnimation.Expect(t => t.Play()).Repeat.Times(2);
			secondAnimation.Expect(t => t.Play()).Repeat.Times(2);
            firstAnimation.Expect(t => t.Pause());

			var controller = target.PingPong(2);

			Assert.AreEqual(PipelineKind.PingPong, target.Kind);
			Assert.AreSame(firstAnimation, target.Get(0));
			Assert.AreSame(secondAnimation, target.Get(1));

            //=============== PING 1 ===============/
			firstAnimation.Raise(f => f.Ended += null, firstAnimation, EventArgs.Empty);
			secondAnimation.Raise(f => f.Ended += null, secondAnimation, EventArgs.Empty);
			Assert.AreEqual(2, target.Length);

            // Animations are in reversed orer?
			Assert.AreSame(secondAnimation, target.Get(0));
			Assert.AreSame(firstAnimation, target.Get(1));


			//=============== PONG 1 ===============/
			secondAnimation.Raise(f => f.Ended += null, secondAnimation, EventArgs.Empty);
			firstAnimation.Raise(f => f.Ended += null, firstAnimation, EventArgs.Empty);

			// Animations are in normal order?
			Assert.AreSame(firstAnimation, target.Get(0));
			Assert.AreSame(secondAnimation, target.Get(1));


			//=============== PING 2 ===============/
    		firstAnimation.Raise(f => f.Ended += null, firstAnimation, EventArgs.Empty);
			secondAnimation.Raise(f => f.Ended += null, secondAnimation, EventArgs.Empty);
			
            // Animations are in reversed order?
			Assert.AreSame(secondAnimation, target.Get(0));
			Assert.AreSame(firstAnimation, target.Get(1));


			//=============== PONG 2 ===============/
			secondAnimation.Raise(f => f.Ended += null, secondAnimation, EventArgs.Empty);
			firstAnimation.Raise(f => f.Ended += null, firstAnimation, EventArgs.Empty);

			Assert.AreEqual(0, target.Length);

			Assert.AreEqual(AnimationState.Stopped, controller.State);
			firstAnimation.VerifyAllExpectations();
			secondAnimation.VerifyAllExpectations();
		}
    }
}
