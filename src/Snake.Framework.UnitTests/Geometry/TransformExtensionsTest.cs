using NUnit.Framework;
using Rhino.Mocks;
using Snake.Framework.Geometry;

namespace Snake.Framework.UnitTests.Geometry
{
	[TestFixture]
	public class TransformExtensionsTest
	{
		[Test]
		public void CentralizePivot_NoArgs_Center()
		{
			var target = new Transform(1, 2, MockRepository.GenerateMock<IWorldContext>());
            target.CentralizePivot();

            Assert.AreEqual(Point.HalfOne, target.Pivot);
		}

	}
}
