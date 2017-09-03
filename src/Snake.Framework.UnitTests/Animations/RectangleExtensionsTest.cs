﻿using NUnit.Framework;
using Rhino.Mocks;
using Snake.Framework.Animations;
using Snake.Framework.Behaviors;
using Snake.Framework.Geometry;
using Snake.Framework.Logging;

namespace Snake.Framework.UnitTests.Animations
{
    [TestFixture]
    public class RectangleExtensionsTest
    {
        private IWorldContext ctx;
        private RectangleComponent owner;
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

            owner = new RectangleComponent(5, 10, ctx);
            owner.Transform.Scale = new Point(20, 70);
        }

		[Test]
		public void Iterate_RectangleComponentFilledPingPong_Pipeline()
		{
            Point actualPoint = Point.Zero;
            owner.Filled = true;
            var actual = owner.Iterate(5, Easing.Linear, (x,y) => actualPoint = new Point(x, y));

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(RectangleIterateAnimation<RectangleComponent>), actual.Get(0).GetType());

			actual.Iterate(5, Easing.Linear, (x, y) => actualPoint = new Point(x, y));
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(RectangleIterateAnimation<RectangleComponent>), actual.Get(1).GetType());

			actual.PingPong();
			Assert.AreEqual(PipelineKind.PingPong, actual.Kind);

			for (float time = 0f; time < 5.1f; time += 0.01f)
			{
				sinceSceneStart = time;
				((IUpdatable)actual.Get(0)).Update();
			}

			for (float time = 5.1f; time < 10.1f; time += 0.01f)
			{
				sinceSceneStart = time;
				((IUpdatable)actual.Get(1)).Update();
			}

			for (float time = 10.1f; time < 15.1f; time += 0.01f)
			{
				sinceSceneStart = time;
				((IUpdatable)actual.Get(1)).Update();
			}

			for (float time = 15.1f; time < 20.1f; time += 0.01f)
			{
				sinceSceneStart = time;
				((IUpdatable)actual.Get(0)).Update();
			}
    	}

		[Test]
		public void Iterate_RectangleComponentFilledLoop_Pipeline()
		{
			Point actualPoint = Point.Zero;
			owner.Filled = true;
			var actual = owner.Iterate(5, Easing.Linear, (x, y) => actualPoint = new Point(x, y));

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(RectangleIterateAnimation<RectangleComponent>), actual.Get(0).GetType());

			actual.Iterate(5, Easing.Linear, (x, y) => actualPoint = new Point(x, y));
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(RectangleIterateAnimation<RectangleComponent>), actual.Get(1).GetType());

			actual.Loop();
			Assert.AreEqual(PipelineKind.Loop, actual.Kind);

			for (float time = 0f; time < 5.1f; time += 0.01f)
			{
				sinceSceneStart = time;
				((IUpdatable)actual.Get(0)).Update();
			}

			for (float time = 5.1f; time < 10.1f; time += 0.01f)
			{
				sinceSceneStart = time;
				((IUpdatable)actual.Get(1)).Update();
			}

			for (float time = 10.1f; time < 15.1f; time += 0.01f)
			{
				sinceSceneStart = time;
				((IUpdatable)actual.Get(1)).Update();
			}

			for (float time = 15.1f; time < 20.1f; time += 0.01f)
			{
				sinceSceneStart = time;
				((IUpdatable)actual.Get(0)).Update();
			}
		}

		[Test]
		public void Iterate_RectangleComponentNotFilled_Pipeline()
		{
			Point actualPoint = Point.Zero;
            owner.Filled = false;
			var actual = owner.Iterate(5, Easing.Linear, (x, y) => actualPoint = new Point(x, y));

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(RectangleIterateAnimation<RectangleComponent>), actual.Get(0).GetType());

			actual.Iterate(5, Easing.Linear, (x, y) => actualPoint = new Point(x, y));
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(RectangleIterateAnimation<RectangleComponent>), actual.Get(1).GetType());

			actual.PingPong();
			Assert.AreEqual(PipelineKind.PingPong, actual.Kind);

            for (float time = 0f; time <= 5.1f; time += 0.01f)
            {
                sinceSceneStart = time;
                ((IUpdatable)actual.Get(0)).Update();
            }

			for (float time = 5.1f; time <= 10.1f; time += 0.01f)
			{
				sinceSceneStart = time;
				((IUpdatable)actual.Get(1)).Update();
			}

          	for (float time = 10.1f; time <= 15.1f; time += 0.01f)
			{
				sinceSceneStart = time;
				((IUpdatable)actual.Get(0)).Update();
			}

			for (float time = 15.1f; time <= 20.1f; time += 0.01f)
			{
				sinceSceneStart = time;
				((IUpdatable)actual.Get(1)).Update();
			}

			for (float time = 20.1f; time <= 25.1f; time += 0.01f)
			{
				sinceSceneStart = time;
				((IUpdatable)actual.Get(0)).Update();
			}

			for (float time = 25.1f; time <= 30.1f; time += 0.01f)
			{
				sinceSceneStart = time;
				((IUpdatable)actual.Get(1)).Update();
			}
		}

		[Test]
		public void Iterate_RectangleFilled_Pipeline()
		{
			Point actualPoint = Point.Zero;
			var actual = owner.Iterate(owner.Transform.BoundingBox, true,  5, Easing.Linear, (x, y) => actualPoint = new Point(x, y));

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(RectangleIterateAnimation<RectangleComponent>), actual.Get(0).GetType());

			actual.Iterate(owner.Transform.BoundingBox, true, 5, Easing.Linear, (x, y) => actualPoint = new Point(x, y));
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(RectangleIterateAnimation<RectangleComponent>), actual.Get(1).GetType());

			actual.PingPong();
			Assert.AreEqual(PipelineKind.PingPong, actual.Kind);

			sinceSceneStart = 2.5f;
			((IUpdatable)actual.Get(0)).Update();

			sinceSceneStart = 5.1f;
			((IUpdatable)actual.Get(0)).Update();

			sinceSceneStart += 5.1f;
			((IUpdatable)actual.Get(1)).Update();
		}

		[Test]
		public void Iterate_RectangleNotFilled_Pipeline()
		{
			Point actualPoint = Point.Zero;
			var actual = owner.Iterate(owner.Transform.BoundingBox, false, 5, Easing.Linear, (x, y) => actualPoint = new Point(x, y));

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(RectangleIterateAnimation<RectangleComponent>), actual.Get(0).GetType());

			actual.Iterate(owner.Transform.BoundingBox, false, 5, Easing.Linear, (x, y) => actualPoint = new Point(x, y));
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(RectangleIterateAnimation<RectangleComponent>), actual.Get(1).GetType());

			actual.PingPong();
			Assert.AreEqual(PipelineKind.PingPong, actual.Kind);

			sinceSceneStart = 2.5f;
			((IUpdatable)actual.Get(0)).Update();

			sinceSceneStart = 5.1f;
			((IUpdatable)actual.Get(0)).Update();

			sinceSceneStart += 5.1f;
			((IUpdatable)actual.Get(1)).Update();
		}

        [Test]
        public void Iterate_TransformableFilled_Pipeline()
		{
			Point actualPoint = Point.Zero;
			owner.Filled = true;
            var actual = ((ITransformable) owner).Iterate(true, 5, Easing.Linear, (x, y) => actualPoint = new Point(x, y));

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(RectangleIterateAnimation<ITransformable>), actual.Get(0).GetType());

			((IAnimationPipeline<ITransformable>)actual).Iterate(true, 5, Easing.Linear, (x, y) => actualPoint = new Point(x, y));
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(RectangleIterateAnimation<ITransformable>), actual.Get(1).GetType());

			actual.PingPong();
			Assert.AreEqual(PipelineKind.PingPong, actual.Kind);

			sinceSceneStart = 2.5f;
			((IUpdatable)actual.Get(0)).Update();

			sinceSceneStart = 5.1f;
			((IUpdatable)actual.Get(0)).Update();

			sinceSceneStart += 5.1f;
			((IUpdatable)actual.Get(1)).Update();
		}

		[Test]
		public void Iterate_TransformableNotFilled_Pipeline()
		{
			Point actualPoint = Point.Zero;
			owner.Filled = true;
			var actual = ((ITransformable)owner).Iterate(false, 5, Easing.Linear, (x, y) => actualPoint = new Point(x, y));

			Assert.AreSame(owner, actual.Owner);
			Assert.AreEqual(1, actual.Length);
			Assert.AreEqual(PipelineKind.Once, actual.Kind);
			Assert.AreEqual(PipelineDirection.Forward, actual.Direction);
			Assert.AreEqual(typeof(RectangleIterateAnimation<ITransformable>), actual.Get(0).GetType());

			((IAnimationPipeline<ITransformable>)actual).Iterate(false, 5, Easing.Linear, (x, y) => actualPoint = new Point(x, y));
			Assert.AreEqual(2, actual.Length);
			Assert.AreEqual(typeof(RectangleIterateAnimation<ITransformable>), actual.Get(1).GetType());

			actual.PingPong();
			Assert.AreEqual(PipelineKind.PingPong, actual.Kind);

			sinceSceneStart = 2.5f;
			((IUpdatable)actual.Get(0)).Update();

			sinceSceneStart = 5.1f;
			((IUpdatable)actual.Get(0)).Update();

			sinceSceneStart += 5.1f;
			((IUpdatable)actual.Get(1)).Update();
		}
	}
}
