using System;
using Snake.Framework;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Physics;

namespace Snake.Game
{
    public class Wall : RectangleComponent, IDrawable, ICollidable
    {
        private Wall(float x, float y, IWorldContext context)
            : base(x, y, context)
        {
            this.Toogle(true, 10f, Easing.Linear, v => Sprite = v ? '#' : 'X')
               .Loop();
        }

        public static Wall Create(float x, float y, IWorldContext context)
        {
            return new Wall(x, y, context);
        }

        public void OnCollision(Collision collision)
        {
        }
    }
}
