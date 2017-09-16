using System;
using NUnit.Framework;
using Rhino.Mocks;
using Doog.Framework.Geometry;
using Doog.Framework.Graphics;

namespace Doog.Framework.UnitTests.Graphics
{
    [TestFixture]
    public class CanvasExtensionsTest
    {
        [Test]
        public void Draw_Transform_Draw()
        {
            var target = MockRepository.GenerateMock<ICanvas>();
            target.Expect(t => t.Draw(1, 2, '#'));

            var context = MockRepository.GenerateMock<IWorldContext>();
            target.Draw(new Transform(context) { Position = new Point(1, 2)}, '#');
            target.VerifyAllExpectations();
        }

		[Test]
		public void Draw_mPoint_Draw()
		{
			var target = MockRepository.GenerateMock<ICanvas>();
            target.Expect(t => t.Draw(new Point(1, 2), '#'));

			var context = MockRepository.GenerateMock<IWorldContext>();
			target.Draw(new Point(1, 2), '#');
			target.VerifyAllExpectations();
		}

		[Test]
		public void Draw_RectangleNotFilled_Draw()
		{
			var target = MockRepository.GenerateMock<ICanvas>();
			target.Expect(t => t.Draw(1, 2, '#')).IgnoreArguments().Repeat.Times(32);

            var rect = new Rectangle(1, 1, 10, 10);
            target.Draw(rect, false, 'x');
			
			target.VerifyAllExpectations();
		}

		[Test]
		public void Draw_RectangleFilled_Draw()
		{
			var target = MockRepository.GenerateMock<ICanvas>();
			target.Expect(t => t.Draw(1, 2, '#')).IgnoreArguments().Repeat.Times(81);

			var rect = new Rectangle(1, 1, 10, 10);
			target.Draw(rect, true, 'x');

			target.VerifyAllExpectations();
		}

		[Test]
		public void Draw_Line_Draw()
		{
			var target = MockRepository.GenerateMock<ICanvas>();
			target.Expect(t => t.Draw(1, 2, '#')).IgnoreArguments().Repeat.Times(10);

            var line = new Line(1, 1, 10, 10);
			target.Draw(line, 'x');

			target.VerifyAllExpectations();
		}

		[Test]
		public void Draw_Lines_Draw()
		{
			var target = MockRepository.GenerateMock<ICanvas>();
			target.Expect(t => t.Draw(1, 2, '#')).IgnoreArguments().Repeat.Times(25);

			var line1 = new Line(1, 1, 10, 10);
            var line2 = new Line(10, 10, 25, 25);
            target.Draw(new ILine[] { line1, line2 }, 'x');

			target.VerifyAllExpectations();
		}
    }
}
