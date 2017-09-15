using NUnit.Framework;
using Rhino.Mocks;
using Snake.Framework.Behaviors.Commands;

namespace Snake.Framework.UnitTests.Behaviors.Commands
{
    [TestFixture]
    public class CommandBaseTest
    {
        [Test]
        public void Execute_Object_TTargetOverrideCalled()
        {
            var target = MockRepository.GenerateMock<CommandBase<int>>();
            target.Execute(1);
            target.VerifyAllExpectations();
        }
    }
}
