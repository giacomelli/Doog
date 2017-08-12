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
        public void Draw_TransformComponent_Draw()
        {
            var target = MockRepository.GenerateMock<ICanvas>();
            target.Expect(t => t.Draw(1, 2, '#'));

            target.Draw(new TransformComponent { Position = new Point(1, 2) }, '#');
            target.VerifyAllExpectations();
        }
    }
}