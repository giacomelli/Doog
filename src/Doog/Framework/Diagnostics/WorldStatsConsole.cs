using System.Linq;

namespace Doog
{
    /// <summary>
    /// A console to show stats of the game world.
    /// </summary>
    public class WorldStatsConsole : ComponentBase, IDrawable, ISceneSurvivable
    {
        private readonly Point _position;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldStatsConsole"/> class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="context">The context.</param>
        private WorldStatsConsole(float x, float y, IWorldContext context)
            : base(context)
        {
            this._position = new Point(x, y);
        }

        /// <summary>
        /// Creates the WorldStatsConsole on the specified position and context.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static WorldStatsConsole Create(float x, float y, IWorldContext context)
        {
            return new WorldStatsConsole(x, y, context);
        }

        /// <summary>
        /// Draws the instance on the specified draw context.
        /// </summary>
        /// <param name="drawContext">The draw context.</param>
        public void Draw(IDrawContext drawContext)
        {
            var components = Context.Components;
            var enabledComponentsCount = components.Count(c => c.Enabled);
            var disabledComponentsCount = components.Count(c => !c.Enabled);
            var updatablesCount = components.Count(c => c is IUpdatable);
            var drawablesCount = components.Count(c => c is IDrawable);
            var collidablesCount = components.Count(c => c is ICollidable);
            var sceneSurvivablescount = components.Count(c => c is ISceneSurvivable);

            var x = _position.X;
            var y = _position.Y;
            var ts = drawContext.TextSystem;

            ts
                .Draw(x, y,   $"FPS                        : {(1f / Context.Time.SinceLastFrame):N0}", "Debug")
                .Draw(x, ++y, $"Since scene start          : {Context.Time.SinceSceneStart:N0}", "Debug")
                .Draw(x, ++y, $"Components                 : {components.Count}", "Debug")
                .Draw(x, ++y, $"Enabled components         : {enabledComponentsCount}", "Debug")
                .Draw(x, ++y, $"Disabled components        : {disabledComponentsCount}", "Debug")
                .Draw(x, ++y, $"Updatable components       : {updatablesCount}", "Debug")
                .Draw(x, ++y, $"Drawable components        : {drawablesCount}", "Debug")
                .Draw(x, ++y, $"Collidable components      : {collidablesCount}", "Debug")
                .Draw(x, ++y, $"Scene survivable components: {sceneSurvivablescount}", "Debug");

        }

        /// <summary>
        /// Verify if this instance can survive when scene changes.
        /// </summary>
        /// <param name="fromScene">From scene.</param>
        /// <param name="toScene">To scene.</param>
        /// <returns>
        ///   <c>true</c>, if can survive, <c>false</c> otherwise.
        /// </returns>
        public bool CanSurvive(IScene fromScene, IScene toScene)
        {
            return true;
        }
    }
}
