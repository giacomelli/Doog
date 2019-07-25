namespace Doog
{
    /// <summary>
    /// Pipeline kind.
    /// </summary>
	public enum PipelineKind
	{
        /// <summary>
        /// Run only once.
        /// </summary>
		Once = 0,

        /// <summary>
        /// When finish, starts again.
        /// </summary>
		Loop,

        /// <summary>
        /// When finish, move backwards.
        /// </summary>
		PingPong
	}

    /// <summary>
    /// Pipeline direction.
    /// </summary>
    public enum PipelineDirection
    {
        /// <summary>
        /// In the forward direction.
        /// </summary>
        Forward = 0,

        /// <summary>
        /// In the backward direction.
        /// </summary>
        Backward
    }

    /// <summary>
    /// Defines an interface for an animation pipeline.
    /// </summary>
    /// <remarks>
    /// An animation pipeline runs a group of animations to a same owner and can be paused, resumed and destroy as an only one entity.
    /// </remarks>
    public interface IAnimationPipeline<TOwner>
		where TOwner : IComponent
	{
        /// <summary>
        /// Gets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        TOwner Owner { get;  }

        /// <summary>
        /// Gets the kind.
        /// </summary>
        /// <value>
        /// The kind.
        /// </value>
        PipelineKind Kind { get; }

        /// <summary>
        /// Gets the direction.
        /// </summary>
        /// <value>
        /// The direction.
        /// </value>
        PipelineDirection Direction { get; }

        /// <summary>
        /// Gets the length (number of animations in the pipeline.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        int Length { get; }

        /// <summary>
        /// Adds the specified animation to the pipeline.
        /// </summary>
        /// <param name="animation">The animation.</param>
        void Add(IAnimation<TOwner> animation);

        /// <summary>
        /// Gets the animation in the index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        IAnimation<TOwner> Get(int index);

        /// <summary>
        /// Play the pipeline once.
        /// </summary>
        /// <returns>The animation pipeline controller.</returns>
        IAnimationPipelineController Once();

        /// <summary>
        /// Play the pipeline in a ping-pong way (forward and backward).
        /// </summary>
        /// <param name="times">The number of times the pipeline should be played.</param>
        /// <returns>The animation pipeline controller.</returns>
        IAnimationPipelineController PingPong(int times = 0);

        /// <summary>
        /// Play the pipeline in a loop way (forward and back to first animation).
        /// </summary>
        /// <param name="times">The number of times the pipeline should be played.</param>
        /// <returns>The animation pipeline controller.</returns>
        IAnimationPipelineController Loop(int times = 0);
	}
}
