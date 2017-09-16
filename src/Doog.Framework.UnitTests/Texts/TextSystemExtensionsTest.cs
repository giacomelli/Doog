using NUnit.Framework;
using Rhino.Mocks;

namespace Doog.Framework.UnitTests
{
    [TestFixture]
	public class TextSystemExtensionsTest
	{
		[Test]
		public void DrawCenter_Text_Centralized()
		{
			var ts = MockRepository.GenerateMock<ITextSystem>();
			
			var font = MockRepository.GenerateMock<IFont>();
			font.Expect(f => f.GetTextSize("Test")).Return(new Point(4, 1));
			ts.Expect(t => t.GetFont("Default")).Return(font);
			ts.Expect(t => t.Draw(13, 149.5f, "Test", "Default")).Return(ts);
			ts.DrawCenter("Test", new Rectangle(10, 100, 10, 100), "Default");

			ts.VerifyAllExpectations();
		}

		[Test]
		public void Draw_TextAndPoint_TextDrawnAtPoint()
		{
			var ts = MockRepository.GenerateMock<ITextSystem>();

			ts.Expect(t => t.Draw(1, 2, "Test", "Default")).Return(ts);
            ts.Draw(new Point(1, 2), "Test", "Default");

			ts.VerifyAllExpectations();
		}

		[Test]
		public void DrawCenter_OffsetAndText_OffsetCentralized()
		{
            var ts = MockRepository.GenerateMock<ITextSystem>();
		
			var font = MockRepository.GenerateMock<IFont>();
			font.Expect(f => f.GetTextSize("Test")).Return(new Point(4, 1));
			ts.Expect(t => t.GetFont("Default")).Return(font);
			ts.Expect(t => t.Draw(23, 169.5f, "Test", "Default")).Return(ts);
			ts.DrawCenter(10, 20, "Test", new Rectangle(10, 100, 10, 100), "Default");

			ts.VerifyAllExpectations();
		}

        [Test]
        public void DrawCenter_OffsetAndTextNoBoundsSpecified_OffsetCentralizedByContextBounds()
		{
            var wc = MockRepository.GenerateMock<IWorldContext>();
            wc.Expect(c => c.Bounds).Return(new Rectangle(10, 100, 10, 100));

			var ts = MockRepository.GenerateMock<ITextSystem>();

			var font = MockRepository.GenerateMock<IFont>();
			font.Expect(f => f.GetTextSize("Test")).Return(new Point(4, 1));
			ts.Expect(t => t.GetFont("Default")).Return(font);
			ts.Expect(t => t.Draw(23, 169.5f, "Test", "Default")).Return(ts);
            ts.Expect(t => t.Context).Return(wc);
			ts.DrawCenter(10, 20, "Test", "Default");

			ts.VerifyAllExpectations();
		}

		[Test]
		public void DrawCenterX_YAndText_XCentralized()
		{
			var ts = MockRepository.GenerateMock<ITextSystem>();
		
			var font = MockRepository.GenerateMock<IFont>();
			font.Expect(f => f.GetTextSize("Test")).Return(new Point(4, 1));
			ts.Expect(t => t.GetFont("Default")).Return(font);
			ts.Expect(t => t.Draw(13, 10, "Test", "Default")).Return(ts);
			ts.DrawCenterX(10, "Test", new Rectangle(10, 100, 10, 100), "Default");

			ts.VerifyAllExpectations();
		}

        [Test]
        public void DrawCenterX_YTextNoBoundsSpecified_XCentralizedByContextBounds()
		{
			var wc = MockRepository.GenerateMock<IWorldContext>();
			wc.Expect(c => c.Bounds).Return(new Rectangle(10, 100, 10, 100));

			var ts = MockRepository.GenerateMock<ITextSystem>();

			var font = MockRepository.GenerateMock<IFont>();
			font.Expect(f => f.GetTextSize("Test")).Return(new Point(4, 1));
			ts.Expect(t => t.GetFont("Default")).Return(font);
			ts.Expect(t => t.Draw(13, 10, "Test", "Default")).Return(ts);
            ts.Expect(t => t.Context).Return(wc);
			ts.DrawCenterX(10, "Test", "Default");

			ts.VerifyAllExpectations();
		}

		[Test]
		public void DrawCenterY_XAndText_YCentralized()
		{
			var ts = MockRepository.GenerateMock<ITextSystem>();
		
			var font = MockRepository.GenerateMock<IFont>();
			font.Expect(f => f.GetTextSize("Test")).Return(new Point(4, 1));
			ts.Expect(t => t.GetFont("Default")).Return(font);
			ts.Expect(t => t.Draw(10, 149.5f, "Test", "Default")).Return(ts);
			ts.DrawCenterY(10, "Test", new Rectangle(10, 100, 10, 100), "Default");

			ts.VerifyAllExpectations();
		}

        [Test]
        public void DrawCenterY_XTextNoBoundsSpecified_YCentralizedByContextBounds()
		{
			var wc = MockRepository.GenerateMock<IWorldContext>();
			wc.Expect(c => c.Bounds).Return(new Rectangle(10, 100, 10, 100));

			var ts = MockRepository.GenerateMock<ITextSystem>();

			var font = MockRepository.GenerateMock<IFont>();
			font.Expect(f => f.GetTextSize("Test")).Return(new Point(4, 1));
			ts.Expect(t => t.GetFont("Default")).Return(font);
			ts.Expect(t => t.Draw(10, 149.5f, "Test", "Default")).Return(ts);
            ts.Expect(t => t.Context).Return(wc);
			ts.DrawCenterY(10, "Test", "Default");

			ts.VerifyAllExpectations();
		}
	}
}
