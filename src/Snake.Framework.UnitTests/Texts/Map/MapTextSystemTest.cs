using NUnit.Framework;
using System;
using Snake.Framework.Texts.Map;
using Rhino.Mocks;
using Snake.Framework.Graphics;

namespace Snake.Framework.UnitTests
{
	[TestFixture]
	public class MapTextSystemTest
	{
		[Test]
		public void GetFont_WrongFontName_Exception()
		{
		    var ctx = MockRepository.GenerateMock<IWorldContext>();
            ctx.Expect(c => c.GraphicSystem).Return(MockRepository.GenerateMock<IGraphicSystem>());

			var target = new MapTextSystem(ctx, "Avatar");
			target.Initialize();

			Assert.Catch<ArgumentException>(() =>
			{
				target.GetFont("Test");
			});
		}

		[Test]
		public void GetFont_FontName_Font()
		{
			var ctx = MockRepository.GenerateMock<IWorldContext>();
			ctx.Expect(c => c.GraphicSystem).Return(MockRepository.GenerateMock<IGraphicSystem>());

			var target = new MapTextSystem(ctx, "Avatar");
			target.Initialize();
			var actual = target.GetFont();
			Assert.AreEqual("Avatar", actual.Name);
			Assert.AreEqual(5, actual.Size.X);
			Assert.AreEqual(6, actual.Size.Y);
			Assert.AreEqual(17, actual.GetTextSize("Abc").X);

			actual = target.GetFont("Big");
			Assert.AreEqual("Big", actual.Name);
			Assert.AreEqual(5, actual.Size.X);
			Assert.AreEqual(8, actual.Size.Y);
			Assert.AreEqual(27, actual.GetTextSize("Abc").X);
		}

		[Test]
		public void Draw_Args_Drawn()
		{
			var ctx = MockRepository.GenerateMock<IWorldContext>();
            var gfx = MockRepository.GenerateMock<IGraphicSystem>();
			ctx.Expect(c => c.GraphicSystem).Return(gfx);

			gfx.Expect(g => g.Draw(5, 10, 'A'));
			gfx.Expect(g => g.Draw(6, 10, 'B'));
			gfx.Expect(g => g.Draw(7, 10, 'C'));
			var target = new MapTextSystem(ctx, "Avatar");
			target.Initialize();
			target.Draw(5, 10, "ABC", "Default");

			gfx.VerifyAllExpectations();
		}
	}
}
