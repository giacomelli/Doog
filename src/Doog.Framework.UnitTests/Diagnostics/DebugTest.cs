using NUnit.Framework;
using System;
using Smocks;

namespace Doog.Framework.UnitTests.Diagnostics
{
    [TestFixture]
    public class DebugTest
    {
        [Test]
        public void Initialize_NoDebugArg_EnabledFalse()
        {
            Debug.Initialize("cmd.exe", "debug");
            Assert.IsFalse(Debug.Enabled);		
        }

		[Test]
		public void Enabled_DebugArg_True()
		{
            Debug.Initialize("cmd.exe", "debug-enabled");
            Assert.IsTrue(Debug.Enabled);
		}
    }
}
