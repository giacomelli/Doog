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
            try
            {
                using (var output = new StringWriter())
                {
                    Console.SetOut(output);

                    var target = new GraphicSystem();
                    target.Initialize();

                    target.Draw(5, 10, '1');
                    target.Render();

                    target.Draw(5, 10, '2');
                    target.Render();
                }
            }
            catch(IOException)
            {
                // Is runnning in a no console environment?
            }
        }
    }
}
