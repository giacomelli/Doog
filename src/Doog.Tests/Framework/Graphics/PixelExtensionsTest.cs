using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;

namespace Doog.Tests.Framework.Graphics
{
    [TestFixture]
    public class PixelExtensionsTest
    {        
        [Test]
        public void ColorMethod_Char_Pixel()
        {
            for (int color = (int)Color.Black; color <= (int)Color.White; color++)
            {
                var method = typeof(PixelExtensions).GetMethod(((Color)color).ToString(), BindingFlags.Public | BindingFlags.Static);

                for (int @char = 0; @char < 3; @char++)
                {
                    var actual = (Pixel)method.Invoke(null, new object[] { (char) @char });
                    Assert.AreEqual(@char, actual.Char);
                    Assert.AreEqual((Color)color, actual.ForegroundColor);
                    Assert.AreEqual(Pixel.DefaultBackgroundColor, actual.BackgroundColor);
                }
            }
        }
    }
}