using System;
using NUnit.Framework;
using NSubstitute;

namespace Doog.Tests.Framework
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
			graphicSystem = Substitute.For<IGraphicSystem>();
			physicSystem = Substitute.For<IPhysicSystem>();
			var textSystem = Substitute.For<ITextSystem>();
            var inputSystem = Substitute.For<IInputSystem>();
			textSystem.GetFont(null).ReturnsForAnyArgs(Substitute.For<IFont>());
            textSystem.Context.Returns(Substitute.For<IWorldContext>());
            var logSystem = Substitute.For<ILogSystem>();
            target = new World();
            target.Initialize(graphicSystem, physicSystem, textSystem, inputSystem, () => exited = true);
		}

		[Test]
		public void AddComponent_IUpdatable_Updated()
		{
			var updatable1 = Substitute.For<IUpdatable>();
            updatable1.Enabled.Returns(true);

            var updatable2 = Substitute.For<IUpdatable>();
          
			target.AddComponent(updatable1);
			Assert.AreEqual(1, target.Components.Count);

			target.AddComponent(updatable2);
			Assert.AreEqual(2, target.Components.Count);

			target.Update(DateTime.Now);
			target.Draw();

            updatable1.Received(1).Update();
            updatable2.Received(0).Update();
            physicSystem.Received(1).Update();
        }

        [Test]
		public void AddComponent_IDrawable_Drawn()
		{
			var drawable1 = Substitute.For<IDrawable>();
			drawable1.Enabled.Returns(true);

			var updatable2 = Substitute.For<IDrawable>();
			
			target.AddComponent(drawable1);
			Assert.AreEqual(1, target.Components.Count);

			target.AddComponent(updatable2);
			Assert.AreEqual(2, target.Components.Count);

			target.Update(DateTime.Now);
			target.Draw();

            drawable1.ReceivedWithAnyArgs(1).Draw(null);
            updatable2.ReceivedWithAnyArgs(0).Draw(null);
            physicSystem.Received(1).Update();
        }

        [Test]
		public void AddComponent_ICollidable_AddedToPhysicsSystem()
		{
			var collidable1 = Substitute.For<ICollidable>();
			var collidable2 = Substitute.For<ICollidable>();
			
			target.AddComponent(collidable1);
			Assert.AreEqual(1, target.Components.Count);

			target.AddComponent(collidable2);
			Assert.AreEqual(2, target.Components.Count);

			target.Update(DateTime.Now);
			target.Draw();

            physicSystem.Received(1).Update();
            physicSystem.ReceivedWithAnyArgs(2).AddCollidable(null);
        }

        [Test]
		public void RemoveComponent_Component_Disabled()
		{
			var collidable1 = Substitute.For<ICollidable>();
            collidable1.Enabled = true;
            var collidable2 = Substitute.For<ICollidable>();
            collidable2.Enabled = true;

			target.AddComponent(collidable1);
			target.AddComponent(collidable2);

			target.RemoveComponent(collidable1);

            Assert.IsFalse(collidable1.Enabled);
            Assert.IsTrue(collidable2.Enabled);
        }

        [Test]
		public void OpenScene_FirstScene_OnlyNewSceneComponents()
		{
			var oldComponent1 = Substitute.For<IUpdatable>();
			var oldComponent2 = Substitute.For<IDrawable>();
			var oldComponent3 = Substitute.For<ICollidable>();

			target.AddComponent(oldComponent1);
			target.AddComponent(oldComponent2);
			target.AddComponent(oldComponent3);

			var scene = Substitute.For<IScene>();
			var newComponent1 = Substitute.For<IUpdatable>();
            newComponent1.Enabled = true;

            var newComponent2 = Substitute.For<IDrawable>();
            newComponent2.Enabled = true;

			var newComponent3 = Substitute.For<ICollidable>();

			scene.When(s => s.Initialize()).Do((c) =>
			{
				target.RemoveAllComponents();
				target.AddComponent(newComponent1);
				target.AddComponent(newComponent2);
				target.AddComponent(newComponent3);
			});
		
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

		    target.Update(now.AddSeconds(10));
			target.Draw();

			// New scene was opened, it's been 10 seconds since game startedd and 0 since new scene started.
			Assert.AreEqual(10, target.Time.SinceGameStart);
			Assert.AreEqual(0, target.Time.SinceSceneStart);

			// It's been 20 seconds since game started and 10 since new scene started.
			target.Update(now.AddSeconds(20));
			Assert.AreEqual(20, target.Time.SinceGameStart);
			Assert.AreEqual(10, target.Time.SinceSceneStart);

            // Verifications.
            newComponent1.Received().Update();
            newComponent2.ReceivedWithAnyArgs().Draw(null);
            newComponent3.DidNotReceiveWithAnyArgs().OnCollision(null);
            scene.Received().Update();
            scene.ReceivedWithAnyArgs().Draw(null);
            physicSystem.Received().Update();
        }

        [Test]
		public void OpenScene_FromIUpdatable_OpenScenesIsDeferedToBeginOfNextUpdateCycle()
		{
			var oldComponent1 = Substitute.For<IUpdatable>();
            oldComponent1.Enabled = true;

			var oldComponent2 = Substitute.For<IUpdatable>();
            oldComponent2.Enabled = true;

            var scene = Substitute.For<IScene>();
        
			oldComponent2.When(c => c.Update()).Do(m =>
			{
				target.OpenScene(scene);
			});

			var oldComponent3 = Substitute.For<IUpdatable>();
			oldComponent3.Enabled = true;
		
			target.AddComponent(oldComponent1);
			target.AddComponent(oldComponent2);
			target.AddComponent(oldComponent3);

			target.Update(DateTime.Now);
			Assert.AreEqual(typeof(NullScene), target.CurrentScene.GetType());
	
			// Now scene should be opened.
			target.Update(DateTime.Now);
            scene.Received().Initialize();
            Assert.AreSame(scene, target.CurrentScene);
			
            oldComponent1.Received().Update();
            oldComponent3.Received().Update();
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
