using NUnit.Framework;

namespace Doog.Tests.Framework
{
    [TestFixture]
    public class RandomExtensionsTest
    {
        [Test]
        public void Float_MaxValue_Rand()
        {
            for (int i = 0; i < 100; i++)
            {
                var actual = 2f.Rand();
                Assert.IsTrue(actual >= 0 && actual <= 2f);
            }
        }

		[Test]
		public void Float_MaxValueAndMinValue_Rand()
		{
			for (int i = 0; i < 100; i++)
			{
				var actual = 2f.Rand(1f);
				Assert.IsTrue(actual >= 1f && actual <= 2f);
			}
		}

		[Test]
		public void Array_Items_Rand()
		{
            var items = new int[] { 1, 2, 3 };

            for (int i = 0; i < 100; i++)
			{
                var actual = items.Rand();
				Assert.IsTrue(actual >= 1 && actual <= 3);
			}
		}
    }
}
