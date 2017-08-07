using NUnit.Framework;
using Snake.Framework.Geometry;

namespace Snake.Framework.UnitTests.Geometry
{
	[TestFixture]
	public class IntRectangleExtensionsTest
	{
		[Test]
		public void Contains_PointOutside_False()
		{
			var target = new IntRectangle(0, 1, 10, 11);

			for (int i = 0; i < 10; i++)
			{
				target.Contains(target.RandomIntPoint());
			}
		}
	}
}
