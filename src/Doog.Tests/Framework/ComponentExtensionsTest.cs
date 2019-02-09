using System.Linq;
using NUnit.Framework;
using NSubstitute;

namespace Doog.UnitTests
{
    [TestFixture]
    public class ComponentExtensionsTest
    {
        private IUpdatable c1;
        private IDrawable c2;
        private IUpdatable c3;
        private IComponent[] target;

        [SetUp]
        public void InitializeTest()
        {
			c1 = Substitute.For<IUpdatable>();
		    c2 = Substitute.For<IDrawable>();
		    c3 = Substitute.For<IUpdatable>();
         
			target = new IComponent[] { c1, c2, c3 };
        }

        [Test]
        public void Get_Type_OnlyComponentsOfType()
        {
            var actual1 = target.Get<IUpdatable>();
            Assert.AreEqual(2, actual1.Count());
            Assert.AreSame(c1, actual1.First());
            Assert.AreSame(c3, actual1.Last());

			var actual2 = target.Get<IDrawable>();
			Assert.AreEqual(1, actual2.Count());
			Assert.AreSame(c2, actual2.First());
        }

		[Test]
		public void GetWithTag_Tag_OnlyComponentsWithTag()
		{
			c1.Tag.Returns("Tag1");
			c2.Tag.Returns("Tag2");
			c3.Tag.Returns("Tag1");

			var actual1 = target.GetWithTag("Tag1");
			Assert.AreEqual(2, actual1.Count());
			Assert.AreSame(c1, actual1.First());
			Assert.AreSame(c3, actual1.Last());

            var actual2 = target.GetWithTag("Tag2");
			Assert.AreEqual(1, actual2.Count());
			Assert.AreSame(c2, actual2.First());

			var actual3 = target.GetWithTag("Tag2", "Tag1");
			Assert.AreEqual(3, actual3.Count());
			Assert.AreSame(c1, actual3.First());
            Assert.AreSame(c2, actual3.Skip(1).First());
            Assert.AreSame(c3, actual3.Last());
		}

		[Test]
		public void GetWithoutTag_Tag_OnlyComponentsWithoutTag()
		{
            c1.Tag.Returns("Tag1");
            c2.Tag.Returns("Tag2");
            c3.Tag.Returns("Tag1");

            var actual1 = target.GetWithoutTag("Tag2");
			Assert.AreEqual(2, actual1.Count());
			Assert.AreSame(c1, actual1.First());
			Assert.AreSame(c3, actual1.Last());

			var actual2 = target.GetWithoutTag("Tag1");
			Assert.AreEqual(1, actual2.Count());
			Assert.AreSame(c2, actual2.First());

			var actual3 = target.GetWithoutTag("Tag1", "Tag3");
			Assert.AreEqual(1, actual3.Count());
			Assert.AreSame(c2, actual3.First());

			var actual4 = target.GetWithoutTag("Tag1", "Tag2");
			Assert.AreEqual(0, actual4.Count());
		}

		[Test]
		public void EnablleAll_NoArgs_AllComponentsEnabled()
		{
            target.EnableAll();
            Assert.IsTrue(c1.Enabled);
            Assert.IsTrue(c2.Enabled);
            Assert.IsTrue(c3.Enabled);
        }

		[Test]
		public void DisablleAll_NoArgs_AllComponentsDisabled()
		{
			target.DisableAll();
            Assert.IsFalse(c1.Enabled);
            Assert.IsFalse(c2.Enabled);
            Assert.IsFalse(c3.Enabled);
        }

		[Test]
		public void GetOne_Type_FirtsOne()
		{
            Assert.AreSame(c2, target.GetOne<IDrawable>());
            Assert.AreSame(c1, target.GetOne<IUpdatable>());
            Assert.IsNull(target.GetOne<Transform>());
		}
    }
}