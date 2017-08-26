﻿using NUnit.Framework;
using Rhino.Mocks;
using Snake.Framework.Animations;
using Snake.Framework.Behaviors;
using Snake.Framework.Geometry;
using Snake.Framework.Logging;

namespace Snake.Framework.UnitTests.Animations
{
    [TestFixture]
    public class TransformExtensionsTest
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
		public void MoveTo_OwnerXY_Pipeline()
		{
			var actual = owner.MoveTo(1, 2, 3, Easing.Linear);

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(PositionAnimation), actual.Get(0).GetType());

			actual.MoveTo(1, 2, 3, Easing.Linear);
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(PositionAnimation), actual.Get(1).GetType());

			actual.PingPong();
			Assert.AreEqual(PipelineKind.PingPong, actual.Kind);
		}

		[Test]
		public void MoveTo_OwnerPoint_Pipeline()
		{
            var actual = owner.MoveTo(new Point(1, 2), 3, Easing.Linear);

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(PositionAnimation), actual.Get(0).GetType());

            actual.MoveTo(new Point(1, 2), 3, Easing.Linear);
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(PositionAnimation), actual.Get(1).GetType());

			actual.PingPong();
			Assert.AreEqual(PipelineKind.PingPong, actual.Kind);

           ((IUpdatable)actual.Get(0)).Update();
		}

		[Test]
		public void ScaleTo_OwnerXY_Pipeline()
		{
			var actual = owner.ScaleTo(1, 2, 3, Easing.Linear);

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(PointAnimation<Transform>), actual.Get(0).GetType());

			actual.ScaleTo(1, 2, 3, Easing.Linear);
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(PointAnimation<Transform>), actual.Get(1).GetType());

			actual.PingPong();
			Assert.AreEqual(PipelineKind.PingPong, actual.Kind);
			((IUpdatable)actual.Get(0)).Update();
		}

		[Test]
		public void ScaleTo_OwnerPoint_Pipeline()
		{
			var actual = owner.ScaleTo(1, 2, 3, Easing.Linear);

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(PointAnimation<Transform>), actual.Get(0).GetType());

			actual.ScaleTo(1, 2, 3, Easing.Linear);
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(PointAnimation<Transform>), actual.Get(1).GetType());

			actual.PingPong();
			Assert.AreEqual(PipelineKind.PingPong, actual.Kind);

            ((IUpdatable)actual.Get(0)).Update();
		}
    }
}
