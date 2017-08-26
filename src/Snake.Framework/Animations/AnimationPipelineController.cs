using System;
using System.Collections.Generic;

namespace Snake.Framework.Animations
{
    public static class AnimationPipelineController
    {
     	private static List<IAnimationPipelineController> controllers = new List<IAnimationPipelineController>();

		public static void PauseAll()
		{
        	foreach (var c in controllers)
			{
				c.Pause();
			}
		}

  
        public static void ResumeAll()
		{
			foreach (var c in controllers)
			{
				c.Resume();
			}
		}

		public static void DestroyAll()
		{
			foreach (var c in controllers.ToArray())
			{
				c.Destroy();
			}

            controllers.Clear();
		}

        internal static void AddController(IAnimationPipelineController controller)
        {
            controllers.Add(controller);
        }

        internal static void RemoveController(IAnimationPipelineController controller)
        {
			controllers.Remove(controller);
		}

		internal static void Clear()
		{
			controllers.Clear();
		}

	}

	public class AnimationPipelineController<TOwner> : IAnimationPipelineController
		where TOwner : IComponent
    {
        private AnimationPipeline<TOwner> pipeline;

        internal AnimationPipelineController(AnimationPipeline<TOwner> pipeline)
        {
            this.pipeline = pipeline;
            AnimationPipelineController.AddController(this);
        }

        public AnimationState State
        {
            get
            {
                return pipeline.State;    
            }
        }

		public void Pause()
        {
            pipeline.Pause();
        }

		public void Resume()
		{
			pipeline.Resume();
		}

        public void Destroy()
        {
			pipeline.Destroy();

            if (!(pipeline is DestroyedAnimationPipeline<TOwner>))
            {
                pipeline = new DestroyedAnimationPipeline<TOwner>(pipeline.Owner);
                AnimationPipelineController.RemoveController(this);
            }
        }
    }
}
