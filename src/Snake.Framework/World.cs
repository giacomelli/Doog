using System.Collections.Generic;
using Snake.Framework.Behaviors;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Physics;

namespace Snake.Framework
{
    /// <summary>
    /// Responsible to control the game loop flow.
    /// </summary>
    public class World : IWorld
    {
        private IGraphicSystem graphicSystem;
        private IDrawContext drawContext;
        private IList<IUpdatable> updatables;
        private IList<IDrawable> drawables;
        private int updatablesCount;
        private int drawablesCount;
	
        public World(IGraphicSystem graphicSystem, IPhysicSystem physicSystem)
        {            
            graphicSystem.Initialize();
            drawContext = new DrawContext(graphicSystem);
            this.graphicSystem = graphicSystem;

			Bounds = graphicSystem.Bounds;
			PhysicSystem = physicSystem;

			Components = new List<IComponent>();
			updatables = new List<IUpdatable>();
			drawables = new List<IDrawable>();
		}

		public IntRectangle Bounds { get; private set; }

		public IPhysicSystem PhysicSystem { get; private set; }

		public IList<IComponent> Components { get; private set; }

		public void AddComponent(IComponent component)
		{
			Components.Add(component);

			var u = component as IUpdatable;

			if (u != null)
			{
				updatables.Add(u);
			}

			var d = component as IDrawable;

			if (d != null)
			{
				drawables.Add(d);
			}

			var c = component as ICollidable;

			if (c != null)
			{
				PhysicSystem.AddCollidable(c);
			}
		}

		public void RemoveComponent(IComponent component)
		{
			component.Enabled = false;
		}

		public void Update()
		{
			updatablesCount = updatables.Count;
			drawablesCount = drawables.Count;

			for (int i = 0; i < updatablesCount; i++)
			{
				if (updatables[i].Enabled)
				{
					updatables[i].Update(this);
				}
			}

			PhysicSystem.Update();
		}

		public void Draw()
		{
			for (int i = 0; i < drawablesCount; i++)
			{
				if (drawables[i].Enabled)
				{
					drawables[i].Draw(drawContext);
				}
			}

			graphicSystem.Render();
		}
	}
}
