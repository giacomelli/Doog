using NUnit.Framework;
using System;
using Snake.Framework.Diagnostics;
using Rhino.Mocks;
using Snake.Framework.Texts;

namespace Snake.Framework.UnitTests.Diagnostics
{
    [TestFixture]
    public class WorldStatsConsoleTest
    {
        [Test]
        public void Update_World_TextsDrawn()
        {
			var ctx = MockRepository.GenerateMock<IWorldContext>();
			ctx.Expect(c => c.Components).Return(new IComponent[]
			{
				MockRepository.GenerateMock<IComponent>(),
				MockRepository.GenerateMock<IComponent>()
			});
			ctx.Expect(c => c.TextSystem).Return(MockRepository.GenerateMock<ITextSystem>());

			var target = WorldStatsConsole.Create(10, 20, ctx);
           
            target.Update();
            Assert.IsTrue(target.CanSurvive(null, null));
        }
    }
}
