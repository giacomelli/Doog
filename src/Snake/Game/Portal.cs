using System;
using Snake.Framework;
using Snake.Framework.Geometry;
using Snake.Framework.Physics;
using Snake.Framework.Animations;

namespace Snake.Game
{
    public class Portal : RectangleComponent, ICollidable
    {
        public static readonly Point DefaultScale = new Point(3, 1);
        private const float TeleportTime = 5f;
        private bool recharging;
        private RectangleComponent teleportEffect;
        private char originalSprite;


        public Portal(Point position, IWorldContext ctx)
            : base(position, ctx)
        {
            Transform.Scale = DefaultScale;
            teleportEffect = new RectangleComponent(Transform.Position, 3, ctx)
            {
                Sprite = '.',
                Enabled = false
            };
            teleportEffect.Transform.CentralizePivotX();
        }

        public Action<Snake> SomethingEnteredCallback { get; set; }


        public void ExitSomething(Snake something)
        {
            something.Enabled = false;
            recharging = true;
            originalSprite = Sprite;
            Sprite = '.';
        
            teleportEffect.Transform.Position = something.Transform.Position;
            teleportEffect.Enabled = true;
            teleportEffect
                .Transform
                .RotateTo(360, TeleportTime, Easing.OutSin)
                .Once();
            
            teleportEffect
                .Transform
                .MoveTo(Transform.Position, TeleportTime, Easing.OutSin)
                .Do(() =>
                {
                    teleportEffect.Enabled = false;
					something.Transform.Position = Transform.Position;
                    something.Enabled = true; 
				})
                .Once();

            this.Delay(TeleportTime * 10, () =>
            {
                recharging = false;
                Sprite = originalSprite;
            }).Once();
        }

        void ICollidable.OnCollision(Collision collision)
        {
            if (!recharging && SomethingEnteredCallback != null && collision.Other is Snake)
            {
                SomethingEnteredCallback(collision.Other as Snake);
            }
        }
    }
}
