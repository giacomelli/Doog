using NUnit.Framework;
using NSubstitute;

namespace Doog.Tests.Framework.Physics
{
    [TestFixture]
	public class PhysicSystemTest
	{
		[Test]
		public void AnyCollision_NoCollision_False()
		{
            var context = Substitute.For<IWorldContext>();
			var target = new PhysicSystem();
			var collidable1 = Substitute.For<ICollidable>();
			collidable1.Enabled = true;
            var t = new Transform(context) { Position = new Point(1, 1) };
            collidable1.Transform.Returns(t);

			var collidable2 = Substitute.For<ICollidable>();
			collidable2.Enabled = true;
            t = new Transform(context) { Position = new Point(2, 2) };
            collidable2.Transform.Returns(t);

			Assert.IsFalse(target.AnyCollision(collidable1));

			target.AddCollidable(collidable1);
			Assert.IsFalse(target.AnyCollision(collidable1));

			target.AddCollidable(collidable2);
			Assert.IsFalse(target.AnyCollision(collidable1));
			Assert.IsFalse(target.AnyCollision(collidable2));
		}

		[Test]
		public void AnyCollision_Collisions_True()
		{
            var context = Substitute.For<IWorldContext>();
			var target = new PhysicSystem();
			var collidable1 = Substitute.For<ICollidable>();
			collidable1.Enabled = true;
            var t = new Transform(context) { Position = new Point(1, 1) };
            collidable1.Transform.Returns(t);

			var collidable2 = Substitute.For<ICollidable>();
			collidable2.Enabled = true;
            t = new Transform(context) { Position = new Point(1, 1) };
            collidable2.Transform.Returns(t);

			var collidable3 = Substitute.For<ICollidable>();
			collidable3.Enabled = true;
            t = new Transform(context) { Position = new Point(2, 2) };
            collidable3.Transform.Returns(t);

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
		}

		[Test]
		public void GetCollisions_Collidables_Collisions()
		{
            var context = Substitute.For<IWorldContext>();
			var target = new PhysicSystem();
			var collidable1 = Substitute.For<ICollidable>();
			collidable1.Enabled = true;
            var t = new Transform(context) { Position = new Point(1, 1) };
            collidable1.Transform.Returns(t);

			var collidable2 = Substitute.For<ICollidable>();
			collidable2.Enabled = true;
            t = new Transform(context) { Position = new Point(1, 1) };
            collidable2.Transform.Returns(t);

			var collidable3 = Substitute.For<ICollidable>();
			collidable3.Enabled = true;
            t = new Transform(context) { Position = new Point(1, 1) };
            collidable3.Transform.Returns(t);

			var collidable4 = Substitute.For<ICollidable>();
			collidable4.Enabled = false;

			target.AddCollidable(collidable1);
			target.AddCollidable(collidable2);
			target.AddCollidable(collidable3);
			target.AddCollidable(collidable4);

			Assert.AreEqual(3, target.GetCollisions(collidable1).Count);
			Assert.AreEqual(3, target.GetCollisions(collidable2).Count);
			Assert.AreEqual(3, target.GetCollisions(collidable3).Count);;
		}

		[Test]
		public void Update_Collisions_OnCollisionCalled()
		{
			var context = Substitute.For<IWorldContext>();
			var target = new PhysicSystem();
			var collidable1 = Substitute.For<ICollidable>();
			collidable1.Enabled = true;
            var t = new Transform(context) { Position = new Point(1, 1) };
            collidable1.Transform.Returns(t);
	
			var collidable2 = Substitute.For<ICollidable>();
			collidable2.Enabled = true;
            t = new Transform(context) { Position = new Point(1, 1) };
            collidable2.Transform.Returns(t);
		
			var collidable3 = Substitute.For<ICollidable>();
			collidable3.Enabled = true;
            t = new Transform(context) { Position = new Point(1, 1) };
            collidable3.Transform.Returns(t);
		
			var collidable4 = Substitute.For<ICollidable>();
			collidable4.Enabled = false;
        
			target.AddCollidable(collidable1);
			target.AddCollidable(collidable2);
			target.AddCollidable(collidable3);
			target.AddCollidable(collidable4);

			target.Update();

            collidable1.ReceivedWithAnyArgs(2).OnCollision(null);
            collidable2.ReceivedWithAnyArgs(2).OnCollision(null);
            collidable3.ReceivedWithAnyArgs(2).OnCollision(null);
            collidable4.DidNotReceiveWithAnyArgs().OnCollision(null);
        }
	}
}