using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

namespace Snake.Framework.UnitTests.Geometry
{
    [TestFixture]
    public class CircleComponentTest
    {
        [Test]
        public void Draw_Context_CircleDrawn()
        {
            var ctx = MockRepository.GenerateMock<IWorldContext>();
            var drawCtx = MockRepository.GenerateMock<IDrawContext>();
            var canvas = MockRepository.GenerateMock<ICanvas>();
            drawCtx.Expect(d => d.Canvas).Return(canvas);

            var target = new CircleComponent(new Point(10, 20), 4, ctx);
			canvas.Expect(c => c.Draw(target, true, '#'));

			target.Draw(drawCtx);

            canvas.VerifyAllExpectations();
        }
	}
}
