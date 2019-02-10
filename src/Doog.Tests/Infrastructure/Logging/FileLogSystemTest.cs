using System;
using System.IO;
using NSubstitute;
using NUnit.Framework;

namespace Doog.Tests.Infrastructure.Logging
{
    [TestFixture]
    public class FileLogSystemTest
    {
        [Test]
        public void Write_Message_File()
        {
            var filename = Path.GetTempFileName();
            var context = Substitute.For<IWorldContext>();
            var time = new Time();
            time.Update(new DateTime(2019, 2, 10, 13, 24, 45));
            context.Time.Returns(time);

            using (var target = new FileLogSystem(filename, context))
            {
                target.Debug("test {0}", 1);
                target.Info("test {0}", 2);
                target.Warn("test {0}", 3);
                target.Error("test 4");
            }

            var actual = File.ReadAllText(filename);
            StringAssert.Contains("DEBUG (13:24:45): test 1", actual);
            StringAssert.Contains("INFO (13:24:45): test 2", actual);
            StringAssert.Contains("WARN (13:24:45): test 3", actual);
            StringAssert.Contains("ERROR (13:24:45): test 4", actual);
        }
    }
}
