using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake.Framework.Graphics
{
    public class DrawContext : IDrawContext
    {
        public DrawContext(ICanvas canvas)
        {
            Canvas = canvas;
        }

        public ICanvas Canvas { get; private set; }
    }
}
