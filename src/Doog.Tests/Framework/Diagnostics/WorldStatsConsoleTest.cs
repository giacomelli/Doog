using NUnit.Framework;
using System;
using NSubstitute;

namespace Doog.UnitTests.Diagnostics
{
    [TestFixture]
    public class WorldStatsConsoleTest
    {
        [Test]
        public void Draw_Context_TextsDrawn()
        {
			var ctx = Substitute.For<IWorldContext>();
			ctx.Components.Returns(new IComponent[]
			{
				Substitute.For<IComponent>(),
				Substitute.For<IComponent>()
			});

            var ts = Substitute.For<ITextSystem>();
            var drawCtx = Substitute.For<IDrawContext>();
            drawCtx.TextSystem.Returns(ts);

            var time = new Time();
            time.MarkAsGameStarted(DateTime.Now);
            time.MarkAsSceneStarted(DateTime.Now);
            ctx.Time.Returns(time);

			var target = WorldStatsConsole.Create(10, 20, ctx);
           
            target.Draw(drawCtx);
            Assert.IsTrue(target.CanSurvive(null, null));

            ts.ReceivedWithAnyArgs().Draw(0, 0, null);
        }
    }
}