using System.IO;

namespace Doog.Framework.Samples
{
    public class Sample9Scene : SceneBase
    {
        private SampleComponent actor;
        private Rectangle bounds;

        public Sample9Scene(IWorldContext context)
            : base(context)
        {

        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();
            actor = new SampleComponent(0, 0, Context) { Filled = true };

            var b = Context.Bounds;
            bounds = new Rectangle(b.Left + 10, b.Top + 10, b.Width - 10, b.Height - 15);

            inputStream = System.Console.OpenStandardInput(1);               
        }
        Stream inputStream;

        public override void Update()
        {
            Context.InputSystem
                   .IsKeyDown(Keys.W, () =>
                    {
                        actor.Transform.Position += Point.Up;
                    })
                   .IsKeyDown(Keys.D, () =>
                   {
                       actor.Transform.Position += Point.Right;
                   })
                   .IsKeyDown(Keys.S, () =>
                   {
                       actor.Transform.Position += Point.Down;
                   })
                   .IsKeyDown(Keys.A, () =>
                   {
                       actor.Transform.Position += Point.Left;
                   });
        }

        public override void Draw(IDrawContext drawContext)
        {
            drawContext.TextSystem
                   .Draw(1, 1, "Use WASD to move the object", "Default");
        }
    }
}
