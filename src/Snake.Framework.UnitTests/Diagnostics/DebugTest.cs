using NUnit.Framework;
using System;
using Smocks;

namespace Snake.Framework.UnitTests.Diagnostics
{
    [TestFixture]
    public class DebugTest
    {
        [Test]
        public void Initialize_NoDebugArg_EnabledFalse()
        {
            Debug.Initialize("cmd.exe", "test");
            Assert.IsFalse(Debug.Enabled);		
        }

		[Test]
		public void Enabled_DebugArg_True()
		{
            Debug.Initialize("cmd.exe", "Debug");
            Assert.IsTrue(Debug.Enabled);
		}
    }
}
