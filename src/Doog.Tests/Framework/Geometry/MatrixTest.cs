using NUnit.Framework;

namespace Doog.Tests.Framework.Geometry
{
    [TestFixture]
    public class MatrixTest
    {
        /// <summary>
        /// https://www.intmath.com/matrices-determinants/matrix-multiplication-examples.php
        /// </summary>
        [Test]
        public void MultiplyOperator_OtherMatrixSample1_ResultMatrix()
        {
            var left = new Matrix(-4, 4, -2,
                                  -1, 5,  0,
                                   1, 6,  2);

            var right = new Matrix(3, 7,  8,
                                   4, 5,  9,
                                   1, 6, -2);

            var expected = new Matrix(2, -20,  8,
                                     17,  18, 37,
                                     29,  49, 58);

            var actual = left * right;
            AssertMatrix(expected, actual);
        }

        [Test]
        public void Multiply_OtherMatrixSample2_ResultMatrix()
        {
            var left = new Matrix( 5, -4, -2,
                                  -3,  0,  1,
                                  -1,  2,  3);

            var right = new Matrix(4, 6, 5,
                                   7, 8, 0,
                                   1, 9, 3);

            var expected = new Matrix(-10, -20,  19,
                                      -11,  -9, -12,
                                       13,  37,   4);

            var actual = left * right;
            AssertMatrix(expected, actual);
        }

        [Test]
        public void EqualsOperator_AllNumbersEquals_True()
        {
            var target = new Matrix(-4, 4, -2,
                                  -1, 5, 0,
                                   1, 6, 2);

            var other = new Matrix(-4, 4, -2,
                                  -1, 5, 0,
                                   1, 6, 2);

            Assert.IsTrue(target == other);
            Assert.IsFalse(target != other);
        }

        [Test]
        public void EqualsOperator_AllNumbersAreNotEquals_False()
        {
            var target = new Matrix(-4, 4, -2,
                                  -1, 5, 0,
                                   1, 6, 2);

            var other = new Matrix(-4, 4, -2,
                                  -1, 5, 0,
                                   1, 6, 1);

            Assert.IsFalse(target == other);
            Assert.IsTrue(target != other);
        }

        [Test]
        public void CreateTranslation_XAndY_TranslationMatrix()
        {
            var expected = new Matrix(1f, 0f, 11f,
                                      0f, 1f, 22f,
                                      0f, 0f, 1f);

            var actual = Matrix.CreateTranslation(11, 22);
            AssertMatrix(expected, actual);

            expected = new Matrix(1f, 0f, 33f,
                                  0f, 1f, 44f,
                                  0f, 0f, 1f);

            actual = Matrix.CreateTranslation(33, 44);
            AssertMatrix(expected, actual);
        }

        [Test]
        public void CreateScale_XAndYScaleFactor_ScalingMatrix()
        {
            var expected = new Matrix(11f, 0f, 0f,
                                      0f, 22f, 0f,
                                      0f, 0f, 1f);

            var actual = Matrix.CreateScale(11, 22);
            AssertMatrix(expected, actual);

            expected = new Matrix(33f, 0f, 0f,
                                  0f, 44f, 0f,
                                  0f, 0f, 1f);

            actual = Matrix.CreateScale(33, 44);
            AssertMatrix(expected, actual);
        }

        [Test]
        public void CreateRotation_RotationDegree_RotationMatrix()
        {
            var expected = new Matrix(         0.5f,      -0.866025388f, 0f,
                                       0.866025388f,               0.5f, 0f,
                                                 0f,                 0f, 1f);

            var actual = Matrix.CreateRotation(60);
            AssertMatrix(expected, actual);

            var translation = Matrix.CreateTranslation(11, 22);
            var multiplication = translation * actual;
            Assert.IsFalse(actual == multiplication);
            Assert.IsFalse(translation == multiplication);
        }

        [Test]
        public void Translation_GetAndSet_Point()
        { 
            var actual = Matrix.CreateTranslation(11, 22);
            Assert.AreEqual(11, actual.Translation.X);
            Assert.AreEqual(22, actual.Translation.Y);

            actual.Translation = new Point(33, 44);
            Assert.AreEqual(33, actual.Translation.X);
            Assert.AreEqual(44, actual.Translation.Y);
        }

        private void AssertMatrix(Matrix expected, Matrix actual)
        {
            Assert.AreEqual(expected.M11, actual.M11);
            Assert.AreEqual(expected.M12, actual.M12);
            Assert.AreEqual(expected.M13, actual.M13);

            Assert.AreEqual(expected.M21, actual.M21);
            Assert.AreEqual(expected.M22, actual.M22);
            Assert.AreEqual(expected.M23, actual.M23);

            Assert.AreEqual(expected.M31, actual.M31);
            Assert.AreEqual(expected.M32, actual.M32);
            Assert.AreEqual(expected.M33, actual.M33);
        }
    }
}
