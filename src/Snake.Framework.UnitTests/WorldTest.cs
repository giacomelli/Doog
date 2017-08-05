using NUnit.Framework;
using Rhino.Mocks;
using Snake.Framework.Behaviors;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Physics;

namespace Snake.Framework.UnitTests.Geometry
{
    [TestFixture]
    public class WorldTest
    {
		private IGraphicSystem graphicSystem;
		private IPhysicSystem physicSystem;
		private World target;

        [SetUp]
        public void InitializeTest()
        {
			graphicSystem = MockRepository.GenerateMock<IGraphicSystem>();
			physicSystem = MockRepository.GenerateMock<IPhysicSystem>();
			target = new World(graphicSystem, physicSystem);
        }

		[Test]
		public void AddComponent_IUpdatable_Updated()
		{
            var updatable1 = MockRepository.GenerateMock<IUpdatable>();
			updatable1.Expect(u => u.Update(null)).IgnoreArguments().Repeat.Once();
            updatable1.Expect(u => u.Enabled).Return(true) ;

			var updatable2 = MockRepository.GenerateMock<IUpdatable>();
			updatable2.Expect(u => u.Update(null)).IgnoreArguments().Repeat.Times(0);

			physicSystem.Expect(g => g.Update()).Repeat.Once();

			target.AddComponent(updatable1);
			Assert.AreEqual(1, target.Components.Count);
			
            target.AddComponent(updatable2);
			Assert.AreEqual(2, target.Components.Count);

			target.Update();
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

			target.Update();
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

			target.Update();
			target.Draw();

			collidable1.VerifyAllExpectations();
			graphicSystem.VerifyAllExpectations();
			physicSystem.VerifyAllExpectations();
		}
    }
}
