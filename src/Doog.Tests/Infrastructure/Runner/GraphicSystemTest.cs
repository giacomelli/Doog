using System;
using System.IO;
using NUnit.Framework;

namespace Doog.Tests.Infrastructure.Runner
{
    [TestFixture]
    public class GraphicSystemTest
    {
        [Test]
        public void Render_NoArgs_Rendered()
        {
            // Is runnning in a no console environment?
            if (Console.WindowHeight == 0)
                return;

            using (var output = new StringWriter())
            {
                Console.SetOut(output);

                var target = new GraphicSystem();
                target.Initialize();

                target.Draw(5, 10, '1');
                target.Render();

                target.Draw(5, 10, '2');
                target.Render();

                Assert.AreEqual("12", output.ToString());
            }
        }
    }
}
