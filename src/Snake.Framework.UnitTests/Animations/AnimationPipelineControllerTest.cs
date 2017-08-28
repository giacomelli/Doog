using NUnit.Framework;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Rhino.Mocks;
using Snake.Framework.Logging;

namespace Snake.Framework.UnitTests.Animations
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
            var c1 = MockRepository.GenerateMock<IAnimationPipelineController> ();
            c1.Expect(t => t.Pause());
           
            var c2 = MockRepository.GenerateMock<IAnimationPipelineController>();
			c2.Expect(t => t.Pause());

            AnimationPipelineController.AddController(c1);
            AnimationPipelineController.AddController(c2);

            AnimationPipelineController.PauseAll();

            c1.VerifyAllExpectations();
            c2.VerifyAllExpectations();
        }

		[Test]
		public void ResumeAll_Animations_Resumed()
		{
        	var c1 = MockRepository.GenerateMock<IAnimationPipelineController>();
			c1.Expect(t => t.Resume());

			var c2 = MockRepository.GenerateMock<IAnimationPipelineController>();
			c2.Expect(t => t.Resume());

			AnimationPipelineController.AddController(c1);
			AnimationPipelineController.AddController(c2);

			AnimationPipelineController.ResumeAll();

			c1.VerifyAllExpectations();
			c2.VerifyAllExpectations();
		}

		[Test]
		public void DestroyAll_Animations_Resumed()
		{
			var c1 = MockRepository.GenerateMock<IAnimationPipelineController>();
			c1.Expect(t => t.Destroy());
			var c2 = MockRepository.GenerateMock<IAnimationPipelineController>();
			c2.Expect(t => t.Destroy());

			AnimationPipelineController.AddController(c1);
			AnimationPipelineController.AddController(c2);

			AnimationPipelineController.DestroyAll();

			c1.VerifyAllExpectations();
			c2.VerifyAllExpectations();
		}

        [Test]
        public void Pause_Pipeline_Paused()
        {
            var animation = MockRepository.GenerateMock<IAnimation<Transform>>();
            animation.Expect(t => t.Pause());
            var pipeline = AnimationPipeline<Transform>.Create(animation);

            var target = new AnimationPipelineController<Transform>(pipeline);
            target.Pause();

            animation.VerifyAllExpectations();
        }

		[Test]
		public void Resume_Pipeline_Resumed()
		{
            var animation = MockRepository.GenerateMock<IAnimation<Transform>>();
            animation.Expect(t => t.Resume());
			var pipeline = AnimationPipeline<Transform>.Create(animation);
		
			var target = new AnimationPipelineController<Transform>(pipeline);
			target.Resume();

			animation.VerifyAllExpectations();
		}

		[Test]
		public void Destroy_Pipeline_Destroyed()
		{
            var ctx = MockRepository.GenerateMock<IWorldContext>();
            ctx.Expect(t => t.LogSystem).Return(MockRepository.GenerateMock<ILogSystem>());
            var animation = new FloatAnimation<Transform>(new Transform(ctx), 0, 1, 1, (x) => { });
         
			var pipeline = AnimationPipeline<Transform>.Create(animation);

			var target = new AnimationPipelineController<Transform>(pipeline);
			target.Destroy();

            Assert.AreEqual(AnimationState.Stopped, pipeline.State);

            target.Pause();
            target.Resume();
         }
    }
}
