using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Snake.Framework.Behaviors;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Physics;
using Snake.Framework.Texts;

namespace Snake.Framework
{
	/// <summary>
	/// Responsible to control the game loop flow.
	/// </summary>
	public class World : IWorld
	{
		private IDrawContext drawContext;
		private IList<IUpdatable> updatables;
		private IList<IDrawable> drawables;
		private int updatablesCount;
		private int drawablesCount;
		private IList<IComponent> componentsToRemove;
		private IScene pendingSceneToOpen;
        private Time time;

		public World(IGraphicSystem graphicSystem, IPhysicSystem physicSystem, ITextSystem textSystem)
		{
            time = new Time();
			pendingSceneToOpen = new NullScene();

			graphicSystem.Initialize();
			drawContext = new DrawContext(graphicSystem);
			GraphicSystem = graphicSystem;

			Bounds = graphicSystem.Bounds;
			PhysicSystem = physicSystem;

			textSystem.Initialize();
			TextSystem = textSystem;

			Components = new List<IComponent>();
			componentsToRemove = new List<IComponent>();
			updatables = new List<IUpdatable>();
			drawables = new List<IDrawable>();
		}

		public IScene CurrentScene { get; private set; }

		public IntRectangle Bounds { get; private set; }

        public ITime Time
        {
            get
            {
                return time;
            }
        }

		public IGraphicSystem GraphicSystem { get; private set; }

		public IPhysicSystem PhysicSystem { get; private set; }

		public ITextSystem TextSystem { get; private set; }

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
			// TODO: maybe we should use another property (removed?) to mark a object to be removed.
			component.Enabled = false;
			componentsToRemove.Add(component);
		}

		public void OpenScene(IScene scene)
		{
			pendingSceneToOpen = scene;
		}

		private void OpenSceneIfPending(DateTime now)
		{
			if (pendingSceneToOpen != null)
			{
				// Call new scene initialization, in this moment the scene decide which components will be kept
				// on world and wich objects will be removed.
				pendingSceneToOpen.Initialize(this);

				// Remove the scene survivors from components to remove.
				var sceneSurvivables = componentsToRemove
					.Where(c => (c is ISceneSurvivable) && ((ISceneSurvivable)c).CanSurvive(CurrentScene, pendingSceneToOpen));
				sceneSurvivables.EnableAll();
				componentsToRemove = componentsToRemove.Except(sceneSurvivables).ToList();

				// Remove the components selected by the scene to be removed from world.
				foreach (var c in componentsToRemove)
				{
					Components.Remove(c as IComponent);
					updatables.Remove(c as IUpdatable);
					drawables.Remove(c as IDrawable);
					PhysicSystem.RemoveCollidable(c as ICollidable);
				}

				componentsToRemove.Clear();

				// Change the current world scene.
				CurrentScene = pendingSceneToOpen;

				pendingSceneToOpen = null;

                // Time.
                if(Time.SinceGameStart <= float.Epsilon)
                {
                    time.MarkAsGameStarted(now);
                }

                time.MarkAsSceneStarted(now);
			}
		}

		public void Update(DateTime now)
		{
           	OpenSceneIfPending(now);
			time.Update(now);
			CurrentScene.Update(this);

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
			CurrentScene.Draw(drawContext);

			for (int i = 0; i < drawablesCount; i++)
			{
				if (drawables[i].Enabled)
				{
					drawables[i].Draw(drawContext);
				}
			}

			GraphicSystem.Render();
		}
	}
}
