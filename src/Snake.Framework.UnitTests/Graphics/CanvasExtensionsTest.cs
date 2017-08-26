using System;
using NUnit.Framework;
using Rhino.Mocks;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

namespace Snake.Framework.UnitTests.Graphics
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
    }
}
