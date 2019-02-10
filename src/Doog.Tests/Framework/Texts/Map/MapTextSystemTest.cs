using NUnit.Framework;
using System;
using NSubstitute;

namespace Doog.Tests.Framework.Texts.Map
{
    [TestFixture]
	public class MapTextSystemTest
	{
		[Test]
		public void GetFont_WrongFontName_Exception()
		{
		    var ctx = Substitute.For<IWorldContext>();
            ctx.GraphicSystem.Returns(Substitute.For<IGraphicSystem>());

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
			var ctx = Substitute.For<IWorldContext>();
            ctx.GraphicSystem.Returns(Substitute.For<IGraphicSystem>());

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
			var ctx = Substitute.For<IWorldContext>();
            var gfx = Substitute.For<IGraphicSystem>();
            ctx.GraphicSystem.Returns(gfx);
  
			var target = new MapTextSystem(ctx, "Avatar");
			target.Initialize();
			target.Draw(5, 10, "ABC", "Default");

            gfx.Received().Draw(5, 10, 'A');
            gfx.Received().Draw(6, 10, 'B');
            gfx.Received().Draw(7, 10, 'C');
        }
	}
}
