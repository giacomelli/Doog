using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;

namespace Doog.Tests.Framework.Graphics
{
    [TestFixture]
    public class PixelTest
    {
        [Test]
        public void Equals_NotPixel_False()
        {
            var a = new Pixel('.', Color.Black);
            var actual = a.Equals(1);
            Assert.IsFalse(actual);
        }

        [Test]
        public void Equals_DiffCharOrColor_False()
        {
            var a = new Pixel('.', Color.Black);
            var b = new Pixel('.', Color.White);
            Assert.IsFalse(a.Equals(b));

            a = new Pixel('.', Color.Black);
            b = new Pixel('x', Color.Black);
            Assert.IsFalse(a.Equals(b));
        }

        [Test]
        public void Equals_EqualsCharAndColor_True()
        {
            var a = new Pixel('.', Color.Black);
            var b = new Pixel('.', Color.Black);
            Assert.IsTrue(a.Equals(b));
        }

        [Test]
        public void GetHashCode_DiffPixels_DiffHashCode()
        {
            var hashes = new List<int>();

            for (int @char = 0; @char < 10; @char++)
            {
                for (int color = (int) Color.Black; color <= (int)Color.White; color++)
                {
                    hashes.Add(new Pixel((char) @char, (Color) color).GetHashCode());
                }
            }

            CollectionAssert.AllItemsAreUnique(hashes);
        }

        [Test]
        public void DiffOperator_Equals_False()
        {
            var a = new Pixel('.', Color.Black);
            var b = new Pixel('.', Color.Black);

            Assert.IsFalse(a != b);
        }

        [Test]
        public void DiffOperator_Diff_True()
        {
            var a = new Pixel('.', Color.Black);
            var b = new Pixel('.', Color.White);

            Assert.IsTrue(a != b);
        }

        [Test]
        public void ToString_Pixel_CharAndColor()
        {
            var a = new Pixel('.', Color.Black);
            var b = new Pixel('x', Color.White);

            Assert.AreEqual(". Black", a.ToString());
            Assert.AreEqual("x White", b.ToString());
        }

        [Test]
        public void StaticColor_Char_Pixel()
        {
            for (int color = (int)Color.Black; color <= (int)Color.White; color++)
            {
                var method = typeof(Pixel).GetMethod(((Color)color).ToString(), BindingFlags.Public | BindingFlags.Static);

                for (int @char = 0; @char < 3; @char++)
                {
                    var actual = (Pixel)method.Invoke(null, new object[] { (char) @char });
                    Assert.AreEqual(@char, actual.Char);
                    Assert.AreEqual((Color)color, actual.ForegroundColor);
                }
            }
        }
    }
}