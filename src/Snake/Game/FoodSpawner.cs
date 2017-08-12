using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snake.Framework;
using Snake.Framework.Behaviors;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

namespace Snake.Game
{
    public class FoodSpawner : ComponentBase, IUpdatable
    {
        private Rectangle bounds;
        private Food food;

        public FoodSpawner(IWorldContext context)
        {
            this.bounds = context.Bounds;
            food = new Food() { Enabled = false };
            context.AddComponent(food);
        }

        public void Update(IWorldContext context)
        {
            if(!food.Enabled)
            {
				do
				{
					food.Transform.Position = bounds.RandomPoint().Truncate();
				} while (context.PhysicSystem.AnyCollision(food));

                food.Enabled = true;
            }
        }
    }
}
