namespace Snake.Framework.Animations
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
		TOwner Owner { get;  }
        PipelineKind Kind { get; }
        PipelineDirection Direction { get; }
        int Length { get; }
      
        void Add(IAnimation<TOwner> animation);
        IAnimation<TOwner> Get(int index);
        IAnimationPipelineController Once();
        IAnimationPipelineController PingPong(int times = 0);
        IAnimationPipelineController Loop(int times = 0);
	}
}
