using System.Collections.Generic;
using NUnit.Framework;
using Doog;

namespace Doog.Tests.Framework.Geometry
{
    [TestFixture]
    public class LineTest
    {
		[Test]
		public void Equals_NotLine_False()
		{
			var target = new Line(5, 10, 55, 20);
			Assert.IsFalse(target.Equals(1));
            Assert.IsFalse(target.Equals("1"));
		}

		[Test]
		public void Equals_NotEquals_False()
		{
			var target = new Line(5, 10, 55, 20);
            Assert.IsFalse(target.Equals(new Line(1, 10, 55, 20)));
			Assert.IsFalse(target.Equals(new Line(5, 1, 55, 20)));
            Assert.IsFalse(target.Equals(new Line(5, 10, 1, 20)));
            Assert.IsFalse(target.Equals(new Rectangle(5, 10, 55, 1)));
		}

		[Test]
		public void Equals_Equals_True()
		{
			var target = new Line(5, 10, 55, 20);
			Assert.IsTrue(target.Equals(new Line(5, 10, 55, 20)));
		}

		[Test]
		public void GetHashCode_DiffLines_DiffHashCode()
		{
			var hashes = new List<int>();

            for (int x = 0; x < 10; x++)
            {
				for (int y = 11; y < 20; y++)
				{
                    hashes.Add(new Line(x, y, x + 10, y + 20).GetHashCode());
				}
            }

            CollectionAssert.AllItemsAreUnique(hashes);
		}

        [Test]
        public void DiffOperator_Equals_False()
        {
            var a = new Line(5, 10, 55, 20);
            var b = new Line(5, 10, 55, 20);

            Assert.IsFalse(a != b);
        }

        [Test]
        public void DiffOperator_Diff_True()
		{
			var a = new Line(5, 10, 55, 20);
			var b = new Line(5, 10, 55, 21);

			Assert.IsTrue(a != b);
		}
	}
}
