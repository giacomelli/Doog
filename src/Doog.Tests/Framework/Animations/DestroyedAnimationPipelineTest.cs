using NUnit.Framework;
using NSubstitute;

namespace Doog.UnitTests.Animations
{
    [TestFixture]
    public class DestroyedAnimationPipelineTest
    {
        [Test]
        public void AllMethods_LogSystem_NoException()
        {
			var ctx = Substitute.For<IWorldContext>();
            var logSystem = Substitute.For<ILogSystem>();
			ctx.LogSystem.Returns(logSystem);

            var target = new DestroyedAnimationPipeline<Transform>(new Transform(ctx));
            Assert.AreEqual(AnimationState.Stopped, target.State);

            target.Once();
            target.Pause();
            target.Resume();
            target.Destroy();
            
            logSystem.ReceivedWithAnyArgs(5).Error(null, null);
        }
    }
}
