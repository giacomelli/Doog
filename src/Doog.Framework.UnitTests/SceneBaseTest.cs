using NUnit.Framework;
using NSubstitute;

namespace Doog.Framework.UnitTests
{
    [TestFixture]
    public class SceneBaseTest
    {
        [Test]
        public void Initialize_Default_Methods()
        {
            var context = Substitute.For<IWorldContext>();
            var target = Substitute.For<SceneBase>(context);
            target.Initialize();
            target.Update();
            target.Draw(null);
        }
    }
}
