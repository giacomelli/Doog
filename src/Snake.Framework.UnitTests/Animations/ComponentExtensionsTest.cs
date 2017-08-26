﻿using NUnit.Framework;
using Rhino.Mocks;
using Snake.Framework.Animations;
using Snake.Framework.Behaviors;
using Snake.Framework.Geometry;
using Snake.Framework.Logging;

namespace Snake.Framework.UnitTests.Animations
{
    [TestFixture]
    public class ComponentExtensionsTest
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
        public void To_Owner_Pipeline()
        {
            var actual = owner.To(1, 2, 5, Easing.InBack, v => { });

            Assert.AreSame(owner, actual.Owner);
            Assert.AreEqual(1, actual.Length);
            Assert.AreEqual(PipelineKind.Once, actual.Kind);
            Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
            Assert.AreEqual(typeof(FloatAnimation<Transform>), actual.Get(0).GetType());

            actual.To(1, 2, 5, Easing.Linear, v => { });
            Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(FloatAnimation<Transform>), actual.Get(1).GetType());

            actual.PingPong();
            Assert.AreEqual(PipelineKind.PingPong, actual.Kind);
            ((IUpdatable)actual.Get(0)).Update();
        }

		[Test]
		public void Toogle_Owner_Pipeline()
		{
			var actual = owner.Toogle(true, 5, Easing.InBack, v => { });

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(FloatAnimation<Transform>), actual.Get(0).GetType());

			actual.Toogle(true, 5, Easing.InBack, v => { });
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(FloatAnimation<Transform>), actual.Get(1).GetType());

			actual.Loop();
			Assert.AreEqual(PipelineKind.Loop, actual.Kind);
            ((IUpdatable)actual.Get(0)).Update();
		}

		[Test]
		public void Enable_Owner_Pipeline()
		{
			var actual = owner.Enable(5, Easing.Linear);

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(FloatAnimation<Transform>), actual.Get(0).GetType());

			actual.Enable();
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(FloatAnimation<Transform>), actual.Get(1).GetType());

			actual.Loop();
			Assert.AreEqual(PipelineKind.Loop, actual.Kind);
            ((IUpdatable)actual.Get(0)).Update();
		}

		[Test]
		public void Disabe_Owner_Pipeline()
		{
			var actual = owner.Disable(5, Easing.Linear);

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(FloatAnimation<Transform>), actual.Get(0).GetType());

			actual.Disable();
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(FloatAnimation<Transform>), actual.Get(1).GetType());

			actual.Loop();
			Assert.AreEqual(PipelineKind.Loop, actual.Kind);
            ((IUpdatable)actual.Get(0)).Update();
		}
    }
}
