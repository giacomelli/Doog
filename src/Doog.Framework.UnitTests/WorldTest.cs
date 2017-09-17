using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace Doog.Framework.UnitTests
{
    [TestFixture]
	public class WorldTest
	{
		private IGraphicSystem graphicSystem;
		private IPhysicSystem physicSystem;
		private World target;
        private bool exited;

		[SetUp]
		public void InitializeTest()
		{
            exited = false;
			graphicSystem = MockRepository.GenerateMock<IGraphicSystem>();
			physicSystem = MockRepository.GenerateMock<IPhysicSystem>();
			var textSystem = MockRepository.GenerateMock<ITextSystem>();
            var inputSystem = MockRepository.GenerateMock<IInputSystem>();
			textSystem.Expect(t => t.GetFont(null)).IgnoreArguments().Return(MockRepository.GenerateMock<IFont>());
            textSystem.Expect(t => t.Context).Return(MockRepository.GenerateMock<IWorldContext>());
            var logSystem = MockRepository.GenerateMock<ILogSystem>();
            target = new World();
            target.Initialize(graphicSystem, physicSystem, textSystem, inputSystem, () => exited = true);
		}

		[Test]
		public void AddComponent_IUpdatable_Updated()
		{
			var updatable1 = MockRepository.GenerateMock<IUpdatable>();
			updatable1.Expect(u => u.Update()).Repeat.Once();
			updatable1.Expect(u => u.Enabled).Return(true);

			var updatable2 = MockRepository.GenerateMock<IUpdatable>();
            updatable2.Expect(u => u.Update()).Repeat.Times(0);

			physicSystem.Expect(g => g.Update()).Repeat.Once();

			target.AddComponent(updatable1);
			Assert.AreEqual(1, target.Components.Count);

			target.AddComponent(updatable2);
			Assert.AreEqual(2, target.Components.Count);

			target.Update(DateTime.Now);
			target.Draw();

			updatable1.VerifyAllExpectations();
			graphicSystem.VerifyAllExpectations();
			physicSystem.VerifyAllExpectations();
		}

		[Test]
		public void AddComponent_IDrawable_Drawn()
		{
			var drawable1 = MockRepository.GenerateMock<IDrawable>();
			drawable1.Expect(u => u.Draw(null)).IgnoreArguments().Repeat.Once();
			drawable1.Expect(u => u.Enabled).Return(true);

			var updatable2 = MockRepository.GenerateMock<IDrawable>();
			updatable2.Expect(u => u.Draw(null)).IgnoreArguments().Repeat.Times(0);

			physicSystem.Expect(g => g.Update()).Repeat.Once();

			target.AddComponent(drawable1);
			Assert.AreEqual(1, target.Components.Count);

			target.AddComponent(updatable2);
			Assert.AreEqual(2, target.Components.Count);

			target.Update(DateTime.Now);
			target.Draw();

			drawable1.VerifyAllExpectations();
			graphicSystem.VerifyAllExpectations();
			physicSystem.VerifyAllExpectations();
		}

		[Test]
		public void AddComponent_ICollidable_AddedToPhysicsSystem()
		{
			var collidable1 = MockRepository.GenerateMock<ICollidable>();
			var collidable2 = MockRepository.GenerateMock<ICollidable>();

			physicSystem.Expect(g => g.Update()).Repeat.Once();
			physicSystem.Expect(g => g.AddCollidable(null)).IgnoreArguments().Repeat.Times(2);

			target.AddComponent(collidable1);
			Assert.AreEqual(1, target.Components.Count);

			target.AddComponent(collidable2);
			Assert.AreEqual(2, target.Components.Count);

			target.Update(DateTime.Now);
			target.Draw();

			collidable1.VerifyAllExpectations();
			graphicSystem.VerifyAllExpectations();
			physicSystem.VerifyAllExpectations();
		}

		[Test]
		public void RemoveComponent_Component_Disabled()
		{
			var collidable1 = MockRepository.GenerateMock<ICollidable>();
			collidable1.Expect(c => c.Enabled).SetPropertyWithArgument(false);

			var collidable2 = MockRepository.GenerateMock<ICollidable>();

			target.AddComponent(collidable1);
			target.AddComponent(collidable2);

			target.RemoveComponent(collidable1);

			collidable1.VerifyAllExpectations();
			collidable2.VerifyAllExpectations();
		}

		[Test]
		public void OpenScene_FirstScene_OnlyNewSceneComponents()
		{
			var oldComponent1 = MockRepository.GenerateMock<IUpdatable>();
			var oldComponent2 = MockRepository.GenerateMock<IDrawable>();
			var oldComponent3 = MockRepository.GenerateMock<ICollidable>();

			target.AddComponent(oldComponent1);
			target.AddComponent(oldComponent2);
			target.AddComponent(oldComponent3);

			var scene = MockRepository.GenerateMock<IScene>();
			var newComponent1 = MockRepository.GenerateMock<IUpdatable>();
			newComponent1.Expect(c => c.Enabled).Return(true);
			newComponent1.Expect(c => c.Update());

			var newComponent2 = MockRepository.GenerateMock<IDrawable>();
			newComponent2.Expect(c => c.Enabled).Return(true);
			newComponent2.Expect(c => c.Draw(null)).IgnoreArguments();

			var newComponent3 = MockRepository.GenerateMock<ICollidable>();

			scene.Expect(s => s.Initialize()).WhenCalled((m) =>
			{
				target.RemoveAllComponents();
				target.AddComponent(newComponent1);
				target.AddComponent(newComponent2);
				target.AddComponent(newComponent3);
			});
			scene.Expect(s => s.Update());
			scene.Expect(s => s.Draw(null)).IgnoreArguments();

            // Game not started yet.

            var now = DateTime.Now;
            Assert.AreEqual(0, target.Time.SinceGameStart);
            Assert.AreEqual(0, target.Time.SinceSceneStart);

            // NullScene will be opened and game started.
			target.Update(now);
			Assert.AreEqual(0, target.Time.SinceGameStart);
			Assert.AreEqual(0, target.Time.SinceSceneStart);

            // It's been 5 seconds since game and scene started.
			target.Update(now.AddSeconds(5));
			Assert.AreEqual(5, target.Time.SinceGameStart);
			Assert.AreEqual(5, target.Time.SinceSceneStart);

       		target.OpenScene(scene);
			Assert.AreEqual(3, target.Components.Count);

			physicSystem.Expect(p => p.Update());
            target.Update(now.AddSeconds(10));
			target.Draw();

			// New scene was opened, it's been 10 seconds since game startedd and 0 since new scene started.
			Assert.AreEqual(10, target.Time.SinceGameStart);
			Assert.AreEqual(0, target.Time.SinceSceneStart);

			// It's been 20 seconds since game startedd and 10 since new scene started.
			target.Update(now.AddSeconds(20));
			Assert.AreEqual(20, target.Time.SinceGameStart);
			Assert.AreEqual(10, target.Time.SinceSceneStart);


			oldComponent1.VerifyAllExpectations();
			oldComponent2.VerifyAllExpectations();
			oldComponent3.VerifyAllExpectations();

			newComponent1.VerifyAllExpectations();
			newComponent2.VerifyAllExpectations();
			newComponent3.VerifyAllExpectations();
			physicSystem.VerifyAllExpectations();
		}

		[Test]
		public void OpenScene_FromIUpdatable_OpenScenesIsDeferedToBeginOfNextUpdateCycle()
		{
			var oldComponent1 = MockRepository.GenerateMock<IUpdatable>();
			oldComponent1.Expect(c => c.Enabled).Return(true);
			oldComponent1.Expect(c => c.Update());

			var oldComponent2 = MockRepository.GenerateMock<IUpdatable>();
			oldComponent2.Expect(c => c.Enabled).Return(true);
		
			var scene = MockRepository.GenerateMock<IScene>();

			oldComponent2.Expect(c => c.Update()).WhenCalled(m =>
			{
				target.OpenScene(scene);
			});

			var oldComponent3 = MockRepository.GenerateMock<IUpdatable>();
			oldComponent3.Expect(c => c.Enabled).Return(true);
			oldComponent3.Expect(c => c.Update());

			target.AddComponent(oldComponent1);
			target.AddComponent(oldComponent2);
			target.AddComponent(oldComponent3);

			target.Update(DateTime.Now);
			Assert.AreEqual(typeof(NullScene), target.CurrentScene.GetType());
	
			// Now scene should be opened.
			scene.Expect(s => s.Initialize());
			target.Update(DateTime.Now);
			Assert.AreSame(scene, target.CurrentScene);
			scene.VerifyAllExpectations();

			oldComponent1.VerifyAllExpectations();
			oldComponent2.VerifyAllExpectations();
			oldComponent3.VerifyAllExpectations();
		}

        [Test]
        public void Exit_Called_Exit()
        {
            Assert.IsFalse(exited);
            target.Exit();
            target.Dispose();
            Assert.IsTrue(exited);
        }
	}
}
