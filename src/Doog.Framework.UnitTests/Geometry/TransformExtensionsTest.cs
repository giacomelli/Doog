﻿using NUnit.Framework;
using Rhino.Mocks;
using Doog.Framework;

namespace Doog.Framework.UnitTests.Geometry
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

		[Test]
		public void CentralizePivotX_NoArgs_Center()
		{
			var target = new Transform(1, 2, MockRepository.GenerateMock<IWorldContext>());
            target.CentralizePivotX();

			Assert.AreEqual(new Point(0.5f, 0), target.Pivot);
		}

		[Test]
		public void CentralizePivotY_NoArgs_Center()
		{
			var target = new Transform(1, 2, MockRepository.GenerateMock<IWorldContext>());
			target.CentralizePivotY();

			Assert.AreEqual(new Point(0, 0.5f), target.Pivot);
		}
	}
}
