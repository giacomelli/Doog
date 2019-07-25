namespace Doog
{
    /// <summary> 
    /// A Null object pattern IAnimationPipelineController's implementation.
    /// </summary>
    /// <seealso cref="Doog.IAnimationPipelineController" />
    public class NullAnimationPipelineController : IAnimationPipelineController
    {
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
                return AnimationState.NotPlayed;
            }
        }

        /// <summary>
        /// Destroys the animation pipeline.
        /// </summary>
        public void Destroy()
        {
            // Null object pattern.
        }

        /// <summary>
        /// Pauses the animation pipeline.
        /// </summary>
        public void Pause()
        {
            // Null object pattern.
        }

        /// <summary>
        /// Resumes the animation pipeline.
        /// </summary>
        public void Resume()
        {
            // Null object pattern.
        }
    }
}