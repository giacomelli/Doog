using System.Linq;
using Doog.Framework.Behaviors;
using Doog.Framework.Geometry;
using Doog.Framework.Graphics;
using Doog.Framework.Physics;

namespace Doog.Framework.Diagnostics
{
    /// <summary>
    /// A console to show stats by game world.
    /// </summary>
    public class WorldStatsConsole : ComponentBase, IDrawable, ISceneSurvivable
    {
        private readonly Point position;
   
        private WorldStatsConsole(float x, float y, IWorldContext context)
            : base(context)
        {
            this.position = new Point(x, y);
        }

        public static WorldStatsConsole Create(float x, float y, IWorldContext context)
        {
            return new WorldStatsConsole(x, y, context);
        }

        public void Draw(IDrawContext ctx)
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
            var ts = ctx.TextSystem;

            ts
                .Draw(x, y,   "FPS                        : {0:N0}".With(1f / Context.Time.SinceLastFrame), "Debug")
                .Draw(x, ++y, "Since scene start          : {0:N0}".With(Context.Time.SinceSceneStart), "Debug")
                .Draw(x, ++y, "Components                 : {0}".With(components.Count), "Debug")
                .Draw(x, ++y, "Enabled components         : {0}".With(enabledComponentsCount), "Debug")
                .Draw(x, ++y, "Disabled components        : {0}".With(disabledComponentsCount), "Debug")
                .Draw(x, ++y, "Updatable components       : {0}".With(updatablesCount), "Debug")
                .Draw(x, ++y, "Drawable components        : {0}".With(drawablesCount), "Debug")
                .Draw(x, ++y, "Collidable components      : {0}".With(collidablesCount), "Debug")
                .Draw(x, ++y, "Scene survivable components: {0}".With(sceneSurvivablescount), "Debug");

        }

        public bool CanSurvive(IScene fromScene, IScene toScene)
        {
            return true;
        }
    }
}
