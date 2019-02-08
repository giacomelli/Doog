﻿using System;
using System.Collections.Generic;

namespace Doog.Framework
{
    /// <summary>
    /// An in-game log system that display logs directly in game screen.
    /// </summary>
    /// <remarks>
    /// Can be useful to debug purposes.
    /// </remarks>
    public class InGameLogSystem : LogSystemBase, IDrawable
    {
        private Rectangle bounds;
        private List<string> lines = new List<string>();

        public InGameLogSystem(Rectangle bounds, IWorldContext context)
            : base(context)
        {
            this.bounds = bounds;
            Context = context;
            Enabled = true;
            Tag = "InGameLogSystem";
            context.AddComponent(this);
        }

        public bool Enabled { get; set; }

        public string Tag { get; private set; }

        public IWorldContext Context { get; private set; }

		public void Draw(IDrawContext ctx)
		{
            ctx.Canvas.Draw(bounds);

            for (int i = 0; i < lines.Count; i++)
            {
                ctx.TextSystem.Draw(bounds.Left + 1, bounds.Top + 2 + i, lines[i], "Debug");
            }
        }

        protected override void Write(string fullMessage)
        {
            lines.Add(fullMessage);

            if (lines.Count > bounds.Height - 1)
            {
                lines.RemoveAt(0);
            }
        }

        public void AddChild(IComponent component)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IComponent> GetChildren()
        {
            return new IComponent[0];
        }
    }
}
