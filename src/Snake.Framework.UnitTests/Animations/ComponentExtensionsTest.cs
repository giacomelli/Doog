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
        private float sinceSceneStart;

        [SetUp]
        public void InitializeTest()
        {
            sinceSceneStart = 0;
			ctx = MockRepository.GenerateMock<IWorldContext>();
			ctx.Expect(t => t.LogSystem).Return(MockRepository.GenerateMock<ILogSystem>());
            var time = MockRepository.GenerateMock<ITime>();
            time.Expect(t => t.SinceSceneStart).WhenCalled(m => m.ReturnValue = sinceSceneStart).Return(0);
			ctx.Expect(t => t.Time).Return(time);

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
            sinceSceneStart = 5.1f;
            ((IUpdatable)actual.Get(0)).Update();
            sinceSceneStart += 5.1f;
            ((IUpdatable)actual.Get(1)).Update();
		}

		[Test]
		public void Enable_OwnerDelay_Pipeline()
		{
			var actual = owner.Enable(5);

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(DelayAnimation<Transform>), actual.Get(0).GetType());

			actual.Enable(5);
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(DelayAnimation<Transform>), actual.Get(1).GetType());

			actual.Enable();
			Assert.AreEqual(3, actual.Length);
			Assert.AreEqual(typeof(DelayAnimation<Transform>), actual.Get(2).GetType());

			actual.Loop();
			Assert.AreEqual(PipelineKind.Loop, actual.Kind);
            sinceSceneStart = 5.1f;
			((IUpdatable)actual.Get(0)).Update();

            sinceSceneStart += 5.1f;
          	((IUpdatable)actual.Get(1)).Update();

			sinceSceneStart += 5f;
          	((IUpdatable)actual.Get(2)).Update();
		}

		[Test]
		public void Enable_OwnerNoDelay_Pipeline()
		{
			var actual = owner.Enable();

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(DelayAnimation<Transform>), actual.Get(0).GetType());

			actual.Enable(5);
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(DelayAnimation<Transform>), actual.Get(1).GetType());

			actual.Enable();
			Assert.AreEqual(3, actual.Length);
			Assert.AreEqual(typeof(DelayAnimation<Transform>), actual.Get(2).GetType());

			actual.Loop();
			Assert.AreEqual(PipelineKind.Loop, actual.Kind);
			sinceSceneStart = 5.1f;
			((IUpdatable)actual.Get(0)).Update();

			sinceSceneStart += 5.1f;
			((IUpdatable)actual.Get(1)).Update();

			sinceSceneStart += 5f;
			((IUpdatable)actual.Get(2)).Update();
		}

		[Test]
		public void Disable_OwnerDelay_Pipeline()
		{
			var actual = owner.Disable(5);

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(DelayAnimation<Transform>), actual.Get(0).GetType());

			actual.Disable(5);
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(DelayAnimation<Transform>), actual.Get(1).GetType());

			actual.Disable();
			Assert.AreEqual(3, actual.Length);
			Assert.AreEqual(typeof(DelayAnimation<Transform>), actual.Get(2).GetType());

			actual.Loop();
			Assert.AreEqual(PipelineKind.Loop, actual.Kind);
			sinceSceneStart = 5.1f;
			((IUpdatable)actual.Get(0)).Update();
			
            sinceSceneStart += 5.1f;
			((IUpdatable)actual.Get(1)).Update();
			
            sinceSceneStart += 5.1f;
			((IUpdatable)actual.Get(2)).Update();
		}

		[Test]
		public void Disable_OwnerNoDelay_Pipeline()
		{
			var actual = owner.Disable();

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(DelayAnimation<Transform>), actual.Get(0).GetType());

			actual.Disable(5);
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(DelayAnimation<Transform>), actual.Get(1).GetType());

			actual.Disable();
			Assert.AreEqual(3, actual.Length);
			Assert.AreEqual(typeof(DelayAnimation<Transform>), actual.Get(2).GetType());

			actual.Loop();
			Assert.AreEqual(PipelineKind.Loop, actual.Kind);
			sinceSceneStart = 5.1f;
			((IUpdatable)actual.Get(0)).Update();

			sinceSceneStart += 5.1f;
			((IUpdatable)actual.Get(1)).Update();

			sinceSceneStart += 5.1f;
			((IUpdatable)actual.Get(2)).Update();
		}
    }

}
