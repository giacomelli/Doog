using System;
using NUnit.Framework;

namespace Doog.Tests
{
    [TestFixture]
    public class GraphicSystemTest
    {
        [Test]
        public void Render_NoArgs_Rendered()
        {
            var target = new GraphicSystem();
            target.Initialize();
  
            target.Draw(5, 10, '1');
            target.Render();

            target.Draw(5, 10, '2');
            target.Render();
        }
    }
}
