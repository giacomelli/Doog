using System;
using NUnit.Framework;
using NSubstitute;

namespace Doog.Tests.Framework.Logging
{
    [TestFixture]
    public class LogSystemBaseTest
    {
        [Test]
        public void AllMethods_Args_Writing()
        {
            var ctx = Substitute.For<IWorldContext>();
            var time = Substitute.For<ITime>();
            var now = DateTime.Now;
            time.Now.Returns(now);
            ctx.Time.Returns(time);

            var target = new StubLogSystem(ctx);
			Assert.IsTrue(((ISceneSurvivable)target).CanSurvive(null, null));
            target.Debug("a: {0}", 1);
            target.Info("b: {0}", 2);
            target.Warn("c: {0}", 3);
			target.Error("d: {0}", 4);

            Assert.AreEqual(
                $"DEBUG ({now:HH:mm:ss}): a: 1INFO ({now:HH:mm:ss}): b: 2WARN ({now:HH:mm:ss}): c: 3ERROR ({now:HH:mm:ss}): d: 4", 
                target.ToString());
        }
    }
}
