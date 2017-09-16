using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace Doog.Framework.UnitTests.Logging
{
    [TestFixture]
    public class LogSystemBaseTest
    {
        [Test]
        public void AllMethods_Args_Writing()
        {
            var ctx = MockRepository.GenerateMock<IWorldContext>();
            var time = MockRepository.GenerateMock<ITime>();
            var now = DateTime.Now;
            time.Expect(t => t.Now).Return(now);
            ctx.Expect(t => t.Time).Return(time);

            var target = new StubLogSystem(ctx);
			Assert.IsTrue(((ISceneSurvivable)target).CanSurvive(null, null));
            target.Debug("a: {0}", 1);
            target.Info("b: {0}", 2);
            target.Warn("c: {0}", 3);
			target.Error("d: {0}", 4);

            Assert.AreEqual(
                @"DEBUG ({0:HH:mm:ss}): a: 1INFO ({0:HH:mm:ss}): b: 2WARN ({0:HH:mm:ss}): c: 3ERROR ({0:HH:mm:ss}): d: 4".With(now), 
                target.ToString());
        }
    }
}
