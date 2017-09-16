using NUnit.Framework;
using Rhino.Mocks;

namespace Doog.Framework.UnitTests.Animations
{
    [TestFixture]
    public class AnimationPipelineExtensionsTest
    {
   		[Test]
		public void GetLast_Animations_LastOne()
		{
            var anim1 = MockRepository.GenerateMock<IAnimation<Transform>>();
            var actual = MockRepository.GenerateMock<IAnimationPipeline<Transform>>();
         	actual.Expect(t => t.Get(1)).Return(anim1);
            actual.Expect(t => t.Length).Return(2);

            Assert.AreSame(anim1, actual.GetLast());
		}

		[Test]
		public void OnlyForward_Animations_LastIsOnlyForward()
		{
			var anim1 = MockRepository.GenerateMock<IAnimation<Transform>>();
            anim1.Expect(t => t.Direction).SetPropertyWithArgument(AnimationDirection.Forward);

			var actual = MockRepository.GenerateMock<IAnimationPipeline<Transform>>();
			actual.Expect(t => t.Get(1)).Return(anim1);
			actual.Expect(t => t.Length).Return(2);

            actual.OnlyForward();

            anim1.VerifyAllExpectations();
		}

		[Test]
		public void OnlyBackward_Animations_LastIsOnlyBackward()
		{
			var anim1 = MockRepository.GenerateMock<IAnimation<Transform>>();
			anim1.Expect(t => t.Direction).SetPropertyWithArgument(AnimationDirection.Backward);

			var actual = MockRepository.GenerateMock<IAnimationPipeline<Transform>>();
			actual.Expect(t => t.Get(1)).Return(anim1);
			actual.Expect(t => t.Length).Return(2);

			actual.OnlyBackward();

			anim1.VerifyAllExpectations();
		}
    }
}
