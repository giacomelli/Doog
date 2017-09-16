using NUnit.Framework;
using Rhino.Mocks;
using Doog.Framework.Animations;
using Doog.Framework.Geometry;
using Doog.Framework.Logging;

namespace Doog.Framework.UnitTests.Animations
{
    [TestFixture]
    public class DestroyedAnimationPipelineTest
    {
        [Test]
        public void AllMethods_LogSystem_NoException()
        {
			var ctx = MockRepository.GenerateMock<IWorldContext>();
            var logSystem = MockRepository.GenerateMock<ILogSystem>();
            logSystem.Expect(t => t.Error(null, null)).IgnoreArguments().Repeat.Times(4);
			ctx.Expect(t => t.LogSystem).Return(logSystem);

            var target = new DestroyedAnimationPipeline<Transform>(new Transform(ctx));
            Assert.AreEqual(AnimationState.Stopped, target.State);

            target.Once();
            target.Pause();
            target.Resume();
            target.Destroy();
          
            logSystem.VerifyAllExpectations();
        }
    }
}
