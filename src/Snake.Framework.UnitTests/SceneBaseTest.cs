using NUnit.Framework;
using Rhino.Mocks;

namespace Snake.Framework.UnitTests
{
    [TestFixture]
    public class SceneBaseTest
    {
        [Test]
        public void Initialize_Default_Methods()
        {
            var target = MockRepository.GeneratePartialMock<SceneBase>();
            target.Initialize(null);
            target.Update(null);
            target.Draw(null);
        }
    }
}
