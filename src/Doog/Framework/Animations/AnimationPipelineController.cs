using System;
using System.Collections.Generic;

namespace Doog
{
    /// <summary>
    /// An animation pipeline controller helper class that allows to pause, resume and destroy all animations.
    /// </summary>
    public static class AnimationPipelineController
    {
        /// <summary>
        /// An empty IAnimationPipelineController.
        /// </summary>
        public static readonly IAnimationPipelineController Empty = new NullAnimationPipelineController();

     	private static List<IAnimationPipelineController> controllers = new List<IAnimationPipelineController>();

        /// <summary>
        /// Pause all animations.
        /// </summary>
		public static void PauseAll()
		{
        	foreach (var c in controllers)
			{
				c.Pause();
			}
		}

        /// <summary>
        /// Resume all paused animations.
        /// </summary>
        public static void ResumeAll()
		{
			foreach (var c in controllers)
			{
				c.Resume();
			}
		}

        /// <summary>
        /// Resume all animations.
        /// </summary>
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

    /// <summary>
    /// The default IAnimationPipelineController's implementation used by the AnimationPipeline class.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner of the animation pipeline controller.</typeparam>
    public class AnimationPipelineController<TOwner> : IAnimationPipelineController
		where TOwner : IComponent
    {
        private AnimationPipeline<TOwner> pipeline;

        internal AnimationPipelineController(AnimationPipeline<TOwner> pipeline)
        {
            this.pipeline = pipeline;
            AnimationPipelineController.AddController(this);
        }

        /// <summary>
        /// Gets the animation state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public AnimationState State
        {
            get
            {
                return pipeline.State;    
            }
        }

        /// <summary>
        /// Pauses the animation pipeline.
        /// </summary>
        public void Pause()
        {
            pipeline.Pause();
        }

        /// <summary>
        /// Resumes the animation pipeline.
        /// </summary>
        public void Resume()
		{
			pipeline.Resume();
		}

        /// <summary>
        /// Destroys the animation pipeline.
        /// </summary>
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