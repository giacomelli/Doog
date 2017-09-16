using NUnit.Framework;
using System;
using Rhino.Mocks;

namespace Doog.Framework.UnitTests.Diagnostics
{
    [TestFixture]
    public class WorldStatsConsoleTest
    {
        [Test]
        public void Draw_Context_TextsDrawn()
        {
			var ctx = MockRepository.GenerateMock<IWorldContext>();
			ctx.Expect(c => c.Components).Return(new IComponent[]
			{
				MockRepository.GenerateMock<IComponent>(),
				MockRepository.GenerateMock<IComponent>()
			});

            var ts = MockRepository.GenerateMock<ITextSystem>();
            var drawCtx = MockRepository.GenerateMock<IDrawContext>();
            ts.Expect(x => x.Draw(0, 0, null)).IgnoreArguments().Return(ts);
			drawCtx.Expect(c => c.TextSystem).Return(ts);

            var time = new Time();
            time.MarkAsGameStarted(DateTime.Now);
            time.MarkAsSceneStarted(DateTime.Now);
            ctx.Expect(c => c.Time).Return(time);

			var target = WorldStatsConsole.Create(10, 20, ctx);
           
            target.Draw(drawCtx);
            Assert.IsTrue(target.CanSurvive(null, null));
        }
    }
}
