namespace Doog.Samples
{
    public class Sample9Scene : SceneBase
    {
        private SampleComponent actor;
     
        public Sample9Scene(IWorldContext context)
            : base(context)
        {

        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();
            actor = new SampleComponent(0, 0, Context) { Filled = true };
        }

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
