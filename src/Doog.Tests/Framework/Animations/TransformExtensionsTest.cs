using NUnit.Framework;
using NSubstitute;

namespace Doog.Tests.Framework.Animations
{
    [TestFixture]
    public class TransformExtensionsTest
    {
        private IWorldContext ctx;
        private Transform owner;
        private float sinceSceneStart;

        [SetUp]
        public void InitializeTest()
        {
			sinceSceneStart = 0;
			ctx = Substitute.For<IWorldContext>();
			ctx.LogSystem.Returns(Substitute.For<ILogSystem>());
			var time = Substitute.For<ITime>();
            time.SinceSceneStart.Returns(sinceSceneStart);
			ctx.Time.Returns(time);

			owner = new Transform(ctx);   
        }

		[Test]
		public void MoveTo_OwnerXY_Pipeline()
		{
			var actual = owner.MoveTo(1, 2, 5, Easing.Linear);

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(PositionAnimation), actual.Get(0).GetType());

			actual.MoveTo(1, 2, 5, Easing.Linear);
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(PositionAnimation), actual.Get(1).GetType());

			actual.PingPong();
			Assert.AreEqual(PipelineKind.PingPong, actual.Kind);

			sinceSceneStart = 5.1f;
			((IUpdatable)actual.Get(0)).Update();
            sinceSceneStart += 5.1f;
			((IUpdatable)actual.Get(1)).Update();
		}

		[Test]
		public void MoveTo_OwnerPoint_Pipeline()
		{
            var actual = owner.MoveTo(new Point(1, 2), 5, Easing.Linear);

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(PositionAnimation), actual.Get(0).GetType());

            actual.MoveTo(new Point(1, 2), 5, Easing.Linear);
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(PositionAnimation), actual.Get(1).GetType());

			actual.PingPong();
			Assert.AreEqual(PipelineKind.PingPong, actual.Kind);

			sinceSceneStart = 5.1f;
			((IUpdatable)actual.Get(0)).Update();
            sinceSceneStart += 5.1f;
			((IUpdatable)actual.Get(1)).Update();
		}

		[Test]
		public void ScaleTo_OwnerXY_Pipeline()
		{
			var actual = owner.ScaleTo(1, 2, 5, Easing.Linear);

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(PointAnimation<Transform>), actual.Get(0).GetType());

			actual.ScaleTo(1, 2, 5, Easing.Linear);
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(PointAnimation<Transform>), actual.Get(1).GetType());

			actual.PingPong();
			Assert.AreEqual(PipelineKind.PingPong, actual.Kind);

			sinceSceneStart = 5.1f;
			((IUpdatable)actual.Get(0)).Update();
            sinceSceneStart += 5.1f;
			((IUpdatable)actual.Get(1)).Update();

		}

		[Test]
		public void ScaleTo_OwnerPoint_Pipeline()
		{
            var actual = owner.ScaleTo(new Point(1, 2), 5, Easing.Linear);

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(PointAnimation<Transform>), actual.Get(0).GetType());

            actual.ScaleTo(new Point(1, 2), 5, Easing.Linear);
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(PointAnimation<Transform>), actual.Get(1).GetType());

			actual.PingPong();
			Assert.AreEqual(PipelineKind.PingPong, actual.Kind);

			sinceSceneStart = 5.1f;
			((IUpdatable)actual.Get(0)).Update();

            sinceSceneStart += 5.1f;
			((IUpdatable)actual.Get(1)).Update();
		}

		[Test]
		public void ScaleTo_OwnerScale_Pipeline()
		{
			var actual = owner.ScaleTo(2, 5, Easing.Linear);

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(PointAnimation<Transform>), actual.Get(0).GetType());

			actual.ScaleTo(3, 5, Easing.Linear);
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(PointAnimation<Transform>), actual.Get(1).GetType());

			actual.PingPong();
			Assert.AreEqual(PipelineKind.PingPong, actual.Kind);

			sinceSceneStart = 5.1f;
			((IUpdatable)actual.Get(0)).Update();

			sinceSceneStart += 5.1f;
			((IUpdatable)actual.Get(1)).Update();
		}

		[Test]
		public void RotateTo_OwnerRotation_Pipeline()
		{
			var actual = owner.RotateTo(2, 5, Easing.Linear);

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(FloatAnimation<Transform>), actual.Get(0).GetType());

			actual.RotateTo(3, 5, Easing.Linear);
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(FloatAnimation<Transform>), actual.Get(1).GetType());

			actual.PingPong();
			Assert.AreEqual(PipelineKind.PingPong, actual.Kind);

			sinceSceneStart = 5.1f;
			((IUpdatable)actual.Get(0)).Update();

			sinceSceneStart += 5.1f;
			((IUpdatable)actual.Get(1)).Update();
		}
    }
}
