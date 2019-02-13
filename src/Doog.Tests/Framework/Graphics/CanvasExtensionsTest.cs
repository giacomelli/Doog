using NUnit.Framework;
using NSubstitute;

namespace Doog.Tests.Framework.Graphics
{
    [TestFixture]
    public class CanvasExtensionsTest
    {
        [Test]
        public void Draw_Transform_Draw()
        {
            var target = Substitute.For<ICanvas>();
            var context = Substitute.For<IWorldContext>();
            target.Draw(new Transform(context) { Position = new Point(1, 2)}, Pixel.Gray('#'));

            target.Received().Draw(1, 2, Pixel.Gray('#'));
        }

		[Test]
		public void Draw_Point_Draw()
		{
			var target = Substitute.For<ICanvas>();
        	var context = Substitute.For<IWorldContext>();
			target.Draw(new Point(1, 2), Pixel.Gray('#'));

            target.Received().Draw(1, 2, Pixel.Gray('#'));
        }

		[Test]
		public void Draw_RectangleNotFilled_Draw()
		{
			var target = Substitute.For<ICanvas>();
	        var rect = new Rectangle(1, 1, 10, 10);
            target.Draw(rect, false, Pixel.Gray('x'));

            target.ReceivedWithAnyArgs(44).Draw(1, 2, Pixel.Gray('#'));
        }

		[Test]
		public void Draw_RectangleFilled_Draw()
		{
			var target = Substitute.For<ICanvas>();
			var rect = new Rectangle(1, 1, 10, 10);
			target.Draw(rect, true, Pixel.Gray('x'));

            target.ReceivedWithAnyArgs().Draw(1, 2, Pixel.Gray('#'));
        }

		[Test]
		public void Draw_Line_Draw()
		{
			var target = Substitute.For<ICanvas>();
		    var line = new Line(1, 1, 10, 10);
			target.Draw(line, Pixel.Gray('x'));

            target.ReceivedWithAnyArgs(10).Draw(1, 2, Pixel.Gray('#'));
        }

		[Test]
		public void Draw_Lines_Draw()
		{
			var target = Substitute.For<ICanvas>();
			var line1 = new Line(1, 1, 10, 10);
            var line2 = new Line(10, 10, 25, 25);
            target.Draw(new ILine[] { line1, line2 }, Pixel.Gray('x'));

            target.ReceivedWithAnyArgs(26).Draw(1, 2, Pixel.Gray('#'));
        }
    }
}