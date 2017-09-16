using NUnit.Framework;
using Rhino.Mocks;

namespace Doog.Framework.UnitTests.Animations
{
    [TestFixture]
    public class DelayExtensionsTest
    {
        private IWorldContext ctx;
        private Transform owner;

        [SetUp]
        public void InitializeTest()
        {
			ctx = MockRepository.GenerateMock<IWorldContext>();
			ctx.Expect(t => t.LogSystem).Return(MockRepository.GenerateMock<ILogSystem>());
			ctx.Expect(t => t.Time).Return(MockRepository.GenerateMock<ITime>());

			owner = new Transform(ctx);   
        }

		[Test]
		public void Delay_Owner_Pipeline()
		{
			var actual = owner.Delay(5);

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(DelayAnimation<Transform>), actual.Get(0).GetType());

			actual.Delay(1);
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(DelayAnimation<Transform>), actual.Get(1).GetType());

			actual.PingPong();
			Assert.AreEqual(PipelineKind.PingPong, actual.Kind);

            ((IUpdatable)actual.Get(0)).Update();
		}
    }
}
