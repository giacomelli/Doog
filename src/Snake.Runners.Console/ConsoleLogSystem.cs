using System;
using System.Collections.Generic;
using Snake.Framework;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Logging;

namespace Snake.Runners.Console
{
    // TODO: move to the Framework project, because it do not have any dependency to Console
    // Maybe we can change the name to something like DebugLogSystem.
    public class ConsoleLogSystem : LogSystemBase, IDrawable
    {
        private Rectangle bounds;
        private List<string> lines = new List<string>();

        public ConsoleLogSystem(Rectangle bounds, IWorldContext context)
            : base(context)
        {
            this.bounds = bounds;
            Context = context;
            Enabled = true;
            Tag = "ConsoleLogSystem";
            context.AddComponent(this);
        }

        public bool Enabled { get; set; }

        public string Tag { get; private set; }

        public IWorldContext Context { get; private set; }

		public void Draw(IDrawContext ctx)
		{
            Context.GraphicSystem.Draw(bounds);

            for (int i = 0; i < lines.Count; i++)
            {
                ctx.TextSystem.Draw(bounds.Left + 1, bounds.Top + 1 + i, lines[i], "Debug");
            }
        }

        protected override void Write(string fullMessage)
        {
            lines.Add(fullMessage);

            if (lines.Count > bounds.Height - 2)
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
            throw new NotImplementedException();
        }
    }
}
