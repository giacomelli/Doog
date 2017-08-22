using System;
using Snake.Framework;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Physics;

namespace Snake.Game
{
    public class Wall : ComponentBase, IDrawable, ICollidable
    {
        private bool shouldInvertSprite = true;

        private Wall(float x, float y, IWorldContext context)
            : base(context)
        {
            Transform = new Transform(x, y, context);

            this.Toogle(true, 10f, Easing.Linear, (v) => shouldInvertSprite = v)
               .Loop();
        }

        public static Wall Create(float x, float y, IWorldContext context)
        {
            return new Wall(x, y, context);
        }

        public Transform Transform { get; private set; }

        public void Draw(IDrawContext context)
        {
            context.Canvas.DrawRectangle(Transform.BoundingBox, true, shouldInvertSprite ? '#' : 'X');
        }

        public void OnCollision(Collision collision)
        {
        }
    }
}
