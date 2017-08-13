﻿using System.Linq;
using Snake.Framework.Behaviors;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Physics;

namespace Snake.Framework.Diagnostics
{
	/// <summary>
	/// A console to show stats by game world.
	/// </summary>
	public class WorldStatsConsole : ComponentBase, IUpdatable, ISceneSurvivable
	{
		private readonly Point position;

		public WorldStatsConsole(int x, int y, IWorldContext Context)
            : base(Context)
		{
			this.position = new Point(x, y);
		}

		public void Update()
		{
			var components = Context.Components;
			var enabledComponentsCount = components.Count(c => c.Enabled);
			var disabledComponentsCount = components.Count(c => !c.Enabled);
			var updatablesCount = components.Count(c => c is IUpdatable);
			var drawablesCount = components.Count(c => c is IDrawable);
			var collidablesCount = components.Count(c => c is ICollidable);
			var sceneSurvivablescount = components.Count(c => c is ISceneSurvivable);

			var x = position.X;
			var y = position.Y;
			var ts = Context.TextSystem;

			ts.Draw(x, y,   "Components                 : {0}".With(components.Count), "Debug");
			ts.Draw(x, ++y, "Enabled components         : {0}".With(enabledComponentsCount), "Debug");
			ts.Draw(x, ++y, "Disabled components        : {0}".With(disabledComponentsCount), "Debug");

			ts.Draw(x, ++y, "Updatable components       : {0}".With(updatablesCount), "Debug");
			ts.Draw(x, ++y, "Drawable components        : {0}".With(drawablesCount), "Debug");
			ts.Draw(x, ++y, "Collidable components      : {0}".With(collidablesCount), "Debug");
			ts.Draw(x, ++y, "Scene survivable components: {0}".With(sceneSurvivablescount), "Debug");
		}

		public bool CanSurvive(IScene fromScene, IScene toScene)
		{
			return true;
		}
	}
}
