using System;
using Snake.Framework;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

namespace Snake.Game.Scenes.Samples
{
    public class Sample6Scene : SceneBase
    {
        public Sample6Scene(IWorldContext context)
            : base(context)
        {
            
        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();
			
        }

        public override void Draw(IDrawContext drawContext)
        {
            base.Draw(drawContext);

            drawContext.TextSystem
                   .DrawCenterX(5, "Abc - 012", "Avatar")
                   .DrawCenterX(10, "Abc - 012", "Big")
                   .DrawCenterX(15, "Abc - 012", "Blocks")
                   .DrawCenterX(20, "Abc - 012", "Debug")
                   .DrawCenterX(25, "Abc - 012", "Default")
                   .DrawCenterX(30, "Abc - 012", "Doom")
                   .DrawCenterX(35, "Abc - 012", "Graceful")
                   .DrawCenterX(40, "Abc - 012", "Modular")
                   .DrawCenterX(45, "Abc - 012", "Slant");
        }
    }
}
