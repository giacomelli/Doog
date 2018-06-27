using NUnit.Framework;
using NSubstitute;

namespace Doog.Framework.UnitTests.Animations
{
    [TestFixture]
    public class AnimationPipelineControllerTest
    {
        [TearDown]
        public void TearDown()
        {
			AnimationPipelineController.Clear();
		}

		[Test]
		public void Empty_Null_Pattern()
		{
			AnimationPipelineController.Empty.Pause();
            AnimationPipelineController.Empty.Resume();
            AnimationPipelineController.Empty.Destroy();
            Assert.AreEqual(AnimationState.NotPlayed, AnimationPipelineController.Empty.State);
		}

        [Test]
        public void PauseAll_Animations_Paused()
        {
            var c1 = Substitute.For<IAnimationPipelineController> ();
            var c2 = Substitute.For<IAnimationPipelineController>();
			
            AnimationPipelineController.AddController(c1);
            AnimationPipelineController.AddController(c2);

            AnimationPipelineController.PauseAll();

            c1.Received().Pause();
            c2.Received().Pause();
        }

		[Test]
		public void ResumeAll_Animations_Resumed()
		{
        	var c1 = Substitute.For<IAnimationPipelineController>();
			var c2 = Substitute.For<IAnimationPipelineController>();
	
			AnimationPipelineController.AddController(c1);
			AnimationPipelineController.AddController(c2);

			AnimationPipelineController.ResumeAll();

            c1.Received().Resume();
            c2.Received().Resume();
		}

		[Test]
		public void DestroyAll_Animations_Resumed()
		{
			var c1 = Substitute.For<IAnimationPipelineController>();
			var c2 = Substitute.For<IAnimationPipelineController>();
		
			AnimationPipelineController.AddController(c1);
			AnimationPipelineController.AddController(c2);

			AnimationPipelineController.DestroyAll();

            c1.Received().Destroy();
            c2.Received().Destroy();
        }

        [Test]
        public void Pause_Pipeline_Paused()
        {
            var animation = Substitute.For<IAnimation<Transform>>();
            var pipeline = AnimationPipeline<Transform>.Create(animation);

            var target = new AnimationPipelineController<Transform>(pipeline);
            target.Pause();

            animation.Received().Pause();
        }

		[Test]
		public void Resume_Pipeline_Resumed()
		{
            var animation = Substitute.For<IAnimation<Transform>>();
            var pipeline = AnimationPipeline<Transform>.Create(animation);
		
			var target = new AnimationPipelineController<Transform>(pipeline);
			target.Resume();

            animation.Received().Resume();
        }

		[Test]
		public void Destroy_Pipeline_Destroyed()
		{
            var ctx = Substitute.For<IWorldContext>();
            ctx.LogSystem.Returns(Substitute.For<ILogSystem>());
            var animation = new FloatAnimation<Transform>(new Transform(ctx), 0, 1, 1, v => { });
         
			var pipeline = AnimationPipeline<Transform>.Create(animation);

			var target = new AnimationPipelineController<Transform>(pipeline);
			target.Destroy();

            Assert.AreEqual(AnimationState.Stopped, pipeline.State);

            target.Pause();
            target.Resume();
         }
    }
}