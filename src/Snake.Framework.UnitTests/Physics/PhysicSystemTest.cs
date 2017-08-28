using NUnit.Framework;
using Rhino.Mocks;
using Snake.Framework.Geometry;
using Snake.Framework.Physics;

namespace Snake.Framework.UnitTests.Physics
{
    [TestFixture]
	public class PhysicSystemTest
	{
		[Test]
		public void AnyCollision_NoCollision_False()
		{
            var context = MockRepository.GenerateMock<IWorldContext>();
			var target = new PhysicSystem();
			var collidable1 = MockRepository.GenerateMock<ICollidable>();
			collidable1.Expect(c => c.Enabled).Return(true);
			collidable1.Expect(c => c.Transform).Return(new Transform(context) { Position = new Point(1, 1) });

			var collidable2 = MockRepository.GenerateMock<ICollidable>();
			collidable2.Expect(c => c.Enabled).Return(true);
			collidable2.Expect(c => c.Transform).Return(new Transform(context) { Position = new Point(2, 2) });

			Assert.IsFalse(target.AnyCollision(collidable1));

			target.AddCollidable(collidable1);
			Assert.IsFalse(target.AnyCollision(collidable1));

			target.AddCollidable(collidable2);
			Assert.IsFalse(target.AnyCollision(collidable1));
			Assert.IsFalse(target.AnyCollision(collidable2));

			collidable1.VerifyAllExpectations();
			collidable2.VerifyAllExpectations();
		}

		[Test]
		public void AnyCollision_Collisions_True()
		{
            var context = MockRepository.GenerateMock<IWorldContext>();
			var target = new PhysicSystem();
			var collidable1 = MockRepository.GenerateMock<ICollidable>();
			collidable1.Expect(c => c.Enabled).Return(true);
			collidable1.Expect(c => c.Transform).Return(new Transform(context) { Position = new Point(1, 1) });

			var collidable2 = MockRepository.GenerateMock<ICollidable>();
			collidable2.Expect(c => c.Enabled).Return(true);
			collidable2.Expect(c => c.Transform).Return(new Transform(context) { Position = new Point(1, 1) });

			var collidable3 = MockRepository.GenerateMock<ICollidable>();
			collidable3.Expect(c => c.Enabled).Return(true);
			collidable3.Expect(c => c.Transform).Return(new Transform(context) { Position = new Point(2, 2) });

			target.AddCollidable(collidable1);
			target.AddCollidable(collidable2);
			target.AddCollidable(collidable3);
			Assert.IsTrue(target.AnyCollision(collidable1));
			Assert.IsTrue(target.AnyCollision(collidable2));
			Assert.IsFalse(target.AnyCollision(collidable3));

            target.RemoveCollidable(collidable2);
			Assert.IsFalse(target.AnyCollision(collidable1));
			Assert.IsFalse(target.AnyCollision(collidable2));
			Assert.IsFalse(target.AnyCollision(collidable3));

			collidable1.VerifyAllExpectations();
			collidable2.VerifyAllExpectations();
			collidable3.VerifyAllExpectations();
		}

		[Test]
		public void GetCollisions_Collidables_Collisions()
		{
            var context = MockRepository.GenerateMock<IWorldContext>();
			var target = new PhysicSystem();
			var collidable1 = MockRepository.GenerateMock<ICollidable>();
			collidable1.Expect(c => c.Enabled).Return(true);
			collidable1.Expect(c => c.Transform).Return(new Transform(context) { Position = new Point(1, 1) });

			var collidable2 = MockRepository.GenerateMock<ICollidable>();
			collidable2.Expect(c => c.Enabled).Return(true);
			collidable2.Expect(c => c.Transform).Return(new Transform(context) { Position = new Point(1, 1) });

			var collidable3 = MockRepository.GenerateMock<ICollidable>();
			collidable3.Expect(c => c.Enabled).Return(true);
			collidable3.Expect(c => c.Transform).Return(new Transform(context) { Position = new Point(1, 1) });

			var collidable4 = MockRepository.GenerateMock<ICollidable>();
			collidable4.Expect(c => c.Enabled).Return(false);

			target.AddCollidable(collidable1);
			target.AddCollidable(collidable2);
			target.AddCollidable(collidable3);
			target.AddCollidable(collidable4);

			Assert.AreEqual(3, target.GetCollisions(collidable1).Count);
			Assert.AreEqual(3, target.GetCollisions(collidable2).Count);
			Assert.AreEqual(3, target.GetCollisions(collidable3).Count);

			collidable1.VerifyAllExpectations();
			collidable2.VerifyAllExpectations();
			collidable3.VerifyAllExpectations();
			collidable4.VerifyAllExpectations();
		}

		[Test]
		public void Update_Collisions_OnCollisionCalled()
		{
			var context = MockRepository.GenerateMock<IWorldContext>();
			var target = new PhysicSystem();
			var collidable1 = MockRepository.GenerateMock<ICollidable>();
			collidable1.Expect(c => c.Enabled).Return(true);
			collidable1.Expect(c => c.Transform).Return(new Transform(context) { Position = new Point(1, 1) });
			collidable1.Expect(c => c.OnCollision(null)).IgnoreArguments().Repeat.Times(2);

			var collidable2 = MockRepository.GenerateMock<ICollidable>();
			collidable2.Expect(c => c.Enabled).Return(true);
			collidable2.Expect(c => c.Transform).Return(new Transform(context) { Position = new Point(1, 1) });
			collidable2.Expect(c => c.OnCollision(null)).IgnoreArguments().Repeat.Times(2);

			var collidable3 = MockRepository.GenerateMock<ICollidable>();
			collidable3.Expect(c => c.Enabled).Return(true);
			collidable3.Expect(c => c.Transform).Return(new Transform(context) { Position = new Point(1, 1) });
			collidable3.Expect(c => c.OnCollision(null)).IgnoreArguments().Repeat.Times(2);

			var collidable4 = MockRepository.GenerateMock<ICollidable>();
			collidable4.Expect(c => c.Enabled).Return(false);
			collidable4.Expect(c => c.OnCollision(null)).IgnoreArguments().Repeat.Times(0);

			target.AddCollidable(collidable1);
			target.AddCollidable(collidable2);
			target.AddCollidable(collidable3);
			target.AddCollidable(collidable4);

			target.Update();

			collidable1.VerifyAllExpectations();
			collidable2.VerifyAllExpectations();
			collidable3.VerifyAllExpectations();
			collidable4.VerifyAllExpectations();
		}
	}
}
