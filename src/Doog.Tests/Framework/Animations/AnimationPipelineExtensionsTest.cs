using NUnit.Framework;
using NSubstitute;

namespace Doog.UnitTests.Animations
{
    [TestFixture]
    public class AnimationPipelineExtensionsTest
    {
   		[Test]
		public void GetLast_Animations_LastOne()
		{
            var anim1 = Substitute.For<IAnimation<Transform>>();
            var actual = Substitute.For<IAnimationPipeline<Transform>>();
         	actual.Get(1).Returns(anim1);
            actual.Length.Returns(2);

            Assert.AreSame(anim1, actual.GetLast());
		}

		[Test]
		public void OnlyForward_Animations_LastIsOnlyForward()
		{
			var anim1 = Substitute.For<IAnimation<Transform>>();
           
			var actual = Substitute.For<IAnimationPipeline<Transform>>();
            actual.Get(1).Returns(anim1);
            actual.Length.Returns(2);

            actual.OnlyForward();

            Assert.AreEqual(anim1.Direction, AnimationDirection.Forward);
        }

		[Test]
		public void OnlyBackward_Animations_LastIsOnlyBackward()
		{
			var anim1 = Substitute.For<IAnimation<Transform>>();
		
			var actual = Substitute.For<IAnimationPipeline<Transform>>();
            actual.Get(1).Returns(anim1);
            actual.Length.Returns(2);

            actual.OnlyBackward();

            Assert.AreEqual(anim1.Direction, AnimationDirection.Backward);
        }
    }
}
