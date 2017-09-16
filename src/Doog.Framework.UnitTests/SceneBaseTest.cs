using NUnit.Framework;
using Rhino.Mocks;

namespace Doog.Framework.UnitTests
{
    [TestFixture]
    public class SceneBaseTest
    {
        [Test]
        public void Initialize_Default_Methods()
        {
            var context = MockRepository.GenerateMock<IWorldContext>();
            var target = MockRepository.GeneratePartialMock<SceneBase>(context);
            target.Initialize();
            target.Update();
            target.Draw(null);
        }
    }
}
