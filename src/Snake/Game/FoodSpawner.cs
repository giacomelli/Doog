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
        private IntRectangle bounds;
        private Food food;

        public FoodSpawner(IntRectangle bounds, IWorldContext context)
        {
            this.bounds = bounds;
            food = new Food() { Enabled = false };
            context.AddComponent(food);
        }

        public void Update(IWorldContext context)
        {
            if(!food.Enabled)
            {
				do
				{
					food.Transform.Position = bounds.RandomIntPoint();
				} while (context.PhysicSystem.AnyCollision(food));

                food.Enabled = true;
            }
        }
    }
}
