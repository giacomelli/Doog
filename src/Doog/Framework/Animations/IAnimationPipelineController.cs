namespace Doog
{
    /// <summary>
    /// Defines an interface for an animation pipeline controller.
    /// </summary>
	public interface IAnimationPipelineController
	{
        /// <summary>
        /// Gets the animation state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        AnimationState State { get; }

        /// <summary>
        /// Pauses the animation pipeline.
        /// </summary>
        void Pause();

        /// <summary>
        /// Resumes the animation pipeline.
        /// </summary>
        void Resume();

        /// <summary>
        /// Destroys the animation pipeline.
        /// </summary>
        void Destroy();
	}
}
