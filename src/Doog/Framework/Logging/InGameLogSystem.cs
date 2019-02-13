﻿using System;
using System.Collections.Generic;

namespace Doog
{
    /// <summary>
    /// An in-game log system that display logs directly in game screen.
    /// </summary>
    /// <remarks>
    /// Can be useful to debug purposes.
    /// </remarks>
    public class InGameLogSystem : LogSystemBase, IDrawable
    {
        private readonly Rectangle _bounds;
        private readonly List<string> _lines = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="InGameLogSystem"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="context">The context.</param>
        public InGameLogSystem(Rectangle bounds, IWorldContext context)
            : base(context)
        {
            this._bounds = bounds;
            Context = context;
            Enabled = true;
            Tag = "InGameLogSystem";
            context.AddComponent(this);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Doog.IComponent" /> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        public string Tag { get; private set; }

        /// <summary>
        /// Gets the world context.
        /// </summary> 
        public IWorldContext Context { get; private set; }

        /// <summary>
        /// Draws the instance on the specified draw context.
        /// </summary>
        /// <param name="drawContext">The draw context.</param>
        public void Draw(IDrawContext drawContext)
		{
            drawContext.Canvas.Draw(_bounds, false, Pixel.Default);

            for (int i = 0; i < _lines.Count; i++)
            {
                drawContext.TextSystem.Draw(_bounds.Left + 1, _bounds.Top + 2 + i, _lines[i], "Debug");
            }
        }

        /// <summary>
        /// Writes the specified full message.
        /// </summary>
        /// <param name="fullMessage">The full message.</param>
        protected override void Write(string fullMessage)
        {
            _lines.Add(fullMessage);

            if (_lines.Count > _bounds.Height - 1)
            {
                _lines.RemoveAt(0);
            }
        }

        /// <summary>
        /// Adds the child to the component.
        /// </summary>
        /// <param name="component">The child component.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddChild(IComponent component)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the children components.
        /// </summary>
        public IEnumerable<IComponent> GetChildren()
        {
            return new IComponent[0];
        }
    }
}
