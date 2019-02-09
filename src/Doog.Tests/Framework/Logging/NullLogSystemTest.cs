using NUnit.Framework;
using Doog;

namespace Doog.UnitTests.Logging
{
    [TestFixture]
    public class NullLogSystemTest
    {
        [Test]
        public void AllMethods_Args_NullPattern()
        {
            var target = new NullLogSystem();
            target.Debug("x", 1);
            target.Info("x", 1);
            target.Warn("x", 1);
            target.Error("x", 1);
        }
    }
}
