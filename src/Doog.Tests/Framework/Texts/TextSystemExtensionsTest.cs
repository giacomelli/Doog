using NUnit.Framework;
using NSubstitute;

namespace Doog.UnitTests
{
    [TestFixture]
	public class TextSystemExtensionsTest
	{
		[Test]
		public void DrawCenter_Text_Centralized()
		{
			var ts = Substitute.For<ITextSystem>();
			
			var font = Substitute.For<IFont>();
			ts.GetFont("Default").Returns(font);
            font.GetTextSize("Test").Returns(new Point(4, 1));

            ts.DrawCenter("Test", new Rectangle(10, 100, 10, 100), "Default");

            ts.Received().Draw(13, 149.5f, "Test", "Default");
        }

		[Test]
		public void Draw_TextAndPoint_TextDrawnAtPoint()
		{
			var ts = Substitute.For<ITextSystem>();
			ts.Draw(1, 2, "Test", "Default").Returns(ts);
            ts.Draw(new Point(1, 2), "Test", "Default");;
		}

		[Test]
		public void DrawCenter_OffsetAndText_OffsetCentralized()
		{
            var ts = Substitute.For<ITextSystem>();
		
			var font = Substitute.For<IFont>();
			font.GetTextSize("Test").Returns(new Point(4, 1));
			ts.GetFont("Default").Returns(font);
			
			ts.DrawCenter(10, 20, "Test", new Rectangle(10, 100, 10, 100), "Default");

            ts.Received().Draw(23, 169.5f, "Test", "Default");
        }

        [Test]
        public void DrawCenter_OffsetAndTextNoBoundsSpecified_OffsetCentralizedByContextBounds()
		{
            var wc = Substitute.For<IWorldContext>();
            wc.Bounds.Returns(new Rectangle(10, 100, 10, 100));

			var ts = Substitute.For<ITextSystem>();

			var font = Substitute.For<IFont>();
			font.GetTextSize("Test").Returns(new Point(4, 1));
			ts.GetFont("Default").Returns(font);
		    ts.Context.Returns(wc);

			ts.DrawCenter(10, 20, "Test", "Default");

            ts.Received().Draw(23, 169.5f, "Test", "Default");
        }

		[Test]
		public void DrawCenterX_YAndText_XCentralized()
		{
			var ts = Substitute.For<ITextSystem>();
		
			var font = Substitute.For<IFont>();
			font.GetTextSize("Test").Returns(new Point(4, 1));
			ts.GetFont("Default").Returns(font);
			
			ts.DrawCenterX(10, "Test", new Rectangle(10, 100, 10, 100), "Default");

            ts.Received().Draw(13, 10, "Test", "Default");
        }

        [Test]
        public void DrawCenterX_YTextNoBoundsSpecified_XCentralizedByContextBounds()
		{
			var wc = Substitute.For<IWorldContext>();
			wc.Bounds.Returns(new Rectangle(10, 100, 10, 100));

			var ts = Substitute.For<ITextSystem>();

			var font = Substitute.For<IFont>();
			font.GetTextSize("Test").Returns(new Point(4, 1));
			ts.GetFont("Default").Returns(font);
		    ts.Context.Returns(wc);
			ts.DrawCenterX(10, "Test", "Default");

            ts.Received().Draw(13, 10, "Test", "Default");
        }

		[Test]
		public void DrawCenterY_XAndText_YCentralized()
		{
			var ts = Substitute.For<ITextSystem>();
		
			var font = Substitute.For<IFont>();
			font.GetTextSize("Test").Returns(new Point(4, 1));
			ts.GetFont("Default").Returns(font);
			
			ts.DrawCenterY(10, "Test", new Rectangle(10, 100, 10, 100), "Default");

            ts.Received().Draw(10, 149.5f, "Test", "Default");
        }

        [Test]
        public void DrawCenterY_XTextNoBoundsSpecified_YCentralizedByContextBounds()
		{
			var wc = Substitute.For<IWorldContext>();
			wc.Bounds.Returns(new Rectangle(10, 100, 10, 100));

			var ts = Substitute.For<ITextSystem>();

			var font = Substitute.For<IFont>();
			font.GetTextSize("Test").Returns(new Point(4, 1));
			ts.GetFont("Default").Returns(font);
		    ts.Context.Returns(wc);
			ts.DrawCenterY(10, "Test", "Default");

            ts.Received().Draw(10, 149.5f, "Test", "Default");
        }
	}
}