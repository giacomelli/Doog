using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace Doog.Framework.UnitTests.Animations
{
    [TestFixture]
    public class AnimationPipelineTest
    {
        private IAnimation<Transform> firstAnimation;
        private IAnimation<Transform> secondAnimation;
        private AnimationPipeline<Transform> target;

        private AnimationDirection firstAnimationDirection;
        private AnimationDirection secondAnimationDirection;

        [SetUp]
        public void InitializeTest()
        {
            var ctx = MockRepository.GenerateMock<IWorldContext>();
            ctx.Expect(t => t.LogSystem).Return(MockRepository.GenerateMock<ILogSystem>());

            firstAnimationDirection = AnimationDirection.Any;
            secondAnimationDirection = AnimationDirection.Any;

            firstAnimation = MockRepository.GenerateMock<IAnimation<Transform>, IComponent>();
            firstAnimation.Expect(t => t.Owner).Return(new Transform(ctx));
            firstAnimation.Expect(t => t.State).Return(AnimationState.NotPlayed);
            firstAnimation.Expect(t => t.Direction).WhenCalled(m => m.ReturnValue = firstAnimationDirection).Return(firstAnimationDirection);
            target = AnimationPipeline<Transform>.Create(firstAnimation);
            Assert.AreEqual(1, target.Length);

            secondAnimation = MockRepository.GenerateMock<IAnimation<Transform>>();
            secondAnimation.Expect(t => t.Direction).WhenCalled(m => m.ReturnValue = secondAnimationDirection).Return(secondAnimationDirection);
            target.Add(secondAnimation);
            Assert.AreEqual(2, target.Length);

            Assert.AreEqual(AnimationState.NotPlayed, target.State);
        }

        [Test]
        public void Run_Twice_Exception()
        {
            target.Once();
            var actual = Assert.Catch<InvalidOperationException>(delegate
            {
                target.Once();
            });

            Assert.AreEqual(typeof(InvalidOperationException), actual.GetType());
            Assert.AreEqual("You can call Once/Loop/PingPong just once by pipeline.", actual.Message);

			actual = Assert.Catch<InvalidOperationException>(delegate
			{
				target.Loop();
			});

			Assert.AreEqual(typeof(InvalidOperationException), actual.GetType());
			Assert.AreEqual("You can call Once/Loop/PingPong just once by pipeline.", actual.Message);

			actual = Assert.Catch<InvalidOperationException>(delegate
			{
				target.PingPong();
			});

			Assert.AreEqual(typeof(InvalidOperationException), actual.GetType());
			Assert.AreEqual("You can call Once/Loop/PingPong just once by pipeline.", actual.Message);
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
		public void Once_OnlyBackwardsAnimations_Destroyed()
		{
            firstAnimationDirection = AnimationDirection.Backward;
            secondAnimationDirection = AnimationDirection.Backward;
			secondAnimation.Expect(t => t.Pause());

			var controller = target.Once();
			Assert.AreEqual(0, target.Length);
			
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

        [Test]
        public void PingPong_WithAnimationsOnlyForwardAndOnlyBackward_DirectionsRespected()
        {
            firstAnimation.Expect(t => t.Play()).Repeat.Times(1);
            firstAnimationDirection = AnimationDirection.Backward;
            secondAnimation.Expect(t => t.Play()).Repeat.Times(1);
            secondAnimationDirection = AnimationDirection.Forward;

            firstAnimation.Expect(t => t.Pause());

            var controller = target.PingPong(1);

            Assert.AreEqual(PipelineKind.PingPong, target.Kind);
            Assert.AreSame(firstAnimation, target.Get(0));
            Assert.AreSame(secondAnimation, target.Get(1));

            //=============== PING 1 ===============/
            secondAnimation.Raise(f => f.Ended += null, secondAnimation, EventArgs.Empty);
            Assert.AreEqual(2, target.Length);

            // Animations are in reversed orer?
            Assert.AreSame(secondAnimation, target.Get(0));
            Assert.AreSame(firstAnimation, target.Get(1));


            //=============== PONG 1 ===============/
            firstAnimation.Raise(f => f.Ended += null, firstAnimation, EventArgs.Empty);

            Assert.AreEqual(0, target.Length);

            Assert.AreEqual(AnimationState.Stopped, controller.State);
            firstAnimation.VerifyAllExpectations();
            secondAnimation.VerifyAllExpectations();
        }

        [Test]
        public void Pause_CurrentAnimation_Paused()
        {
            firstAnimation.Expect(t => t.Pause());
            secondAnimation.Expect(t => t.Pause()).Repeat.Times(2);

			target.Once();
            target.Pause();
            firstAnimation.Raise(f => f.Ended += null, firstAnimation, EventArgs.Empty);
            target.Pause();
            target.Pause();

            firstAnimation.VerifyAllExpectations();
            secondAnimation.VerifyAllExpectations();
        }

        [Test]
        public void Resume_CurrentAnimation_Resumed()
        {
            firstAnimation.Expect(t => t.Resume());
            secondAnimation.Expect(t => t.Resume()).Repeat.Times(2);

            target.Once();
            target.Resume();
            firstAnimation.Raise(f => f.Ended += null, firstAnimation, EventArgs.Empty);
            target.Resume();
            target.Resume();

            firstAnimation.VerifyAllExpectations();
            secondAnimation.VerifyAllExpectations();
        }
    }
}
