using NUnit.Framework;
using NSubstitute; 

namespace Doog.UnitTests.Behaviors.Commands
{
    [TestFixture]
    public class CommandBaseTest
    {
        [Test]
        public void Execute_Object_TTargetOverrideCalled()
        {
            var target = Substitute.ForPartsOf<CommandBase<int>>();
            target.Execute(1);
        }
    }
}
