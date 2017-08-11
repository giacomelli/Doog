using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using Snake.Framework.Behaviors;
using Snake.Framework.Graphics;

namespace Snake.Framework.UnitTests
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
			c1 = MockRepository.GenerateMock<IUpdatable>();
		    c2 = MockRepository.GenerateMock<IDrawable>();
		    c3 = MockRepository.GenerateMock<IUpdatable>();
         
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
			c1.Expect(c => c.Tag).Return("Tag1");
			c2.Expect(c => c.Tag).Return("Tag2");
			c3.Expect(c => c.Tag).Return("Tag1");

			var actual1 = target.GetWithTag("Tag1");
			Assert.AreEqual(2, actual1.Count());
			Assert.AreSame(c1, actual1.First());
			Assert.AreSame(c3, actual1.Last());

            var actual2 = target.GetWithTag("Tag2");
			Assert.AreEqual(1, actual2.Count());
			Assert.AreSame(c2, actual2.First());
		}

		[Test]
		public void GetWithoutTag_Tag_OnlyComponentsWithoutTag()
		{
			c1.Expect(c => c.Tag).Return("Tag1");
			c2.Expect(c => c.Tag).Return("Tag2");
			c3.Expect(c => c.Tag).Return("Tag1");

			var actual1 = target.GetWithoutTag("Tag2");
			Assert.AreEqual(2, actual1.Count());
			Assert.AreSame(c1, actual1.First());
			Assert.AreSame(c3, actual1.Last());

			var actual2 = target.GetWithoutTag("Tag1");
			Assert.AreEqual(1, actual2.Count());
			Assert.AreSame(c2, actual2.First());
		}

		[Test]
		public void EnablleAll_NoArgs_AllComponentsEnabled()
		{
            c1.Expect(c => c.Enabled).SetPropertyWithArgument(true);
            c2.Expect(c => c.Enabled).SetPropertyWithArgument(true);
            c3.Expect(c => c.Enabled).SetPropertyWithArgument(true);

            target.EnableAll();
            c1.VerifyAllExpectations();
            c2.VerifyAllExpectations();
            c3.VerifyAllExpectations();
        }

		[Test]
		public void DisablleAll_NoArgs_AllComponentsDisabled()
		{
			c1.Expect(c => c.Enabled).SetPropertyWithArgument(false);
			c2.Expect(c => c.Enabled).SetPropertyWithArgument(false);
			c3.Expect(c => c.Enabled).SetPropertyWithArgument(false);

			target.DisableAll();
			c1.VerifyAllExpectations();
			c2.VerifyAllExpectations();
			c3.VerifyAllExpectations();
		}
    }
}