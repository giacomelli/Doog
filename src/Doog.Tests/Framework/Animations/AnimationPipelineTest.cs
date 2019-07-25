using System;
using NUnit.Framework;
using NSubstitute;

namespace Doog.Tests.Framework.Animations
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
            var ctx = Substitute.For<IWorldContext>();
            ctx.LogSystem.Returns(Substitute.For<ILogSystem>());

            firstAnimationDirection = AnimationDirection.Any;
            secondAnimationDirection = AnimationDirection.Any;

            firstAnimation = Substitute.For<IAnimation<Transform>, IComponent>();
            var t = new Transform(ctx);
            firstAnimation.Owner.Returns(t);
            firstAnimation.State.Returns(AnimationState.NotPlayed);
            firstAnimation.Direction.Returns(c => firstAnimationDirection);
            target = AnimationPipeline<Transform>.Create(firstAnimation);
            Assert.AreEqual(1, target.Length);

            secondAnimation = Substitute.For<IAnimation<Transform>>();
            secondAnimation.Direction.Returns(c => secondAnimationDirection);
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
            var controller = target.Once();

            Assert.AreEqual(PipelineKind.Once, target.Kind);

            firstAnimation.Ended += Raise.Event();
            secondAnimation.Ended += Raise.Event();
            
            Assert.AreEqual(0, target.Length);
            Assert.AreEqual(AnimationState.Stopped, target.State);

            Assert.AreEqual(AnimationState.Stopped, controller.State);

            firstAnimation.Received().Play();
            secondAnimation.Received().Play();
            secondAnimation.Received().Pause();
        }

        [Test]
		public void Once_OnlyBackwardsAnimations_Destroyed()
		{
            firstAnimationDirection = AnimationDirection.Backward;
            secondAnimationDirection = AnimationDirection.Backward;

			var controller = target.Once();
			Assert.AreEqual(0, target.Length);
			
			Assert.AreEqual(AnimationState.Stopped, controller.State);

            secondAnimation.Received().Pause();
        }

        [Test]
        public void Loop_TimesAndFinished_Destroyed()
        {
            var controller = target.Loop(2);

            Assert.AreEqual(PipelineKind.Loop, target.Kind);
            Assert.AreSame(firstAnimation, target.Get(0));
            Assert.AreSame(secondAnimation, target.Get(1));

            // First time
            firstAnimation.Ended += Raise.Event();
            secondAnimation.Ended += Raise.Event();
            Assert.AreEqual(2, target.Length);
            Assert.AreSame(firstAnimation, target.Get(0));
            Assert.AreSame(secondAnimation, target.Get(1));

            // Second time
            firstAnimation.Ended += Raise.Event();
            secondAnimation.Ended += Raise.Event();
            Assert.AreEqual(0, target.Length);

            Assert.AreEqual(AnimationState.Stopped, controller.State);

            firstAnimation.Received(2).Play();
            secondAnimation.Received(2).Play();
            secondAnimation.Received().Pause();
        }

        [Test]
        public void PingPong_TimesAndFinished_Destroyed()
        {
            var controller = target.PingPong(2);

            Assert.AreEqual(PipelineKind.PingPong, target.Kind);
            Assert.AreSame(firstAnimation, target.Get(0));
            Assert.AreSame(secondAnimation, target.Get(1));

            //=============== PING 1 ===============/
            firstAnimation.Ended += Raise.Event();
            secondAnimation.Ended += Raise.Event();
            Assert.AreEqual(2, target.Length);

            // Animations are in reversed orer?
            Assert.AreSame(secondAnimation, target.Get(0));
            Assert.AreSame(firstAnimation, target.Get(1));


            //=============== PONG 1 ===============/
            secondAnimation.Ended += Raise.Event();
            firstAnimation.Ended += Raise.Event();

            // Animations are in normal order?
            Assert.AreSame(firstAnimation, target.Get(0));
            Assert.AreSame(secondAnimation, target.Get(1));


            //=============== PING 2 ===============/
            firstAnimation.Ended += Raise.Event();
            secondAnimation.Ended += Raise.Event();

            // Animations are in reversed order?
            Assert.AreSame(secondAnimation, target.Get(0));
            Assert.AreSame(firstAnimation, target.Get(1));


            //=============== PONG 2 ===============/
            secondAnimation.Ended += Raise.Event();
            firstAnimation.Ended += Raise.Event();

            Assert.AreEqual(0, target.Length);

            Assert.AreEqual(AnimationState.Stopped, controller.State);

            firstAnimation.Received(4).Play();
            secondAnimation.Received(4).Play();
            firstAnimation.Received().Pause();
        }

        [Test]
        public void PingPong_WithAnimationsOnlyForwardAndOnlyBackward_DirectionsRespected()
        {
            firstAnimationDirection = AnimationDirection.Backward;
            secondAnimationDirection = AnimationDirection.Forward;

            var controller = target.PingPong(1);

            Assert.AreEqual(PipelineKind.PingPong, target.Kind);
            Assert.AreSame(firstAnimation, target.Get(0));
            Assert.AreSame(secondAnimation, target.Get(1));

            //=============== PING 1 ===============/
            secondAnimation.Ended += Raise.Event();
            Assert.AreEqual(2, target.Length);

            // Animations are in reversed orer?
            Assert.AreSame(secondAnimation, target.Get(0));
            Assert.AreSame(firstAnimation, target.Get(1));


            //=============== PONG 1 ===============/
            firstAnimation.Ended += Raise.Event();

            Assert.AreEqual(0, target.Length);

            Assert.AreEqual(AnimationState.Stopped, controller.State);

            firstAnimation.Received(1).Play();
            secondAnimation.Received(1).Play();
            firstAnimation.Received().Pause();
        }

        [Test]
        public void Pause_CurrentAnimation_Paused()
        {
        	target.Once();
            target.Pause();
            firstAnimation.Ended += Raise.Event();
            target.Pause();
            target.Pause();

            firstAnimation.Received().Pause();
            secondAnimation.Received(2).Pause();
        }

        [Test]
        public void Resume_CurrentAnimation_Resumed()
        {
            target.Once();
            target.Resume();
            firstAnimation.Ended += Raise.Event();
            target.Resume();
            target.Resume();

            firstAnimation.Received(1).Resume();
            secondAnimation.Received(2).Resume();
        }
    }
}
