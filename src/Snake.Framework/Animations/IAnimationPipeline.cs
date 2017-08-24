namespace Snake.Framework.Animations
{
	public enum PipelineKind
	{
		Once = 0,
		Loop,
		PingPong
	}

    public enum PipelineDirection
    {
        Forward = 0,
        Backward
    }

    public interface IAnimationPipeline<TOwner>
		where TOwner : IComponent
	{
		TOwner Owner { get;  }
        PipelineKind Kind { get; }
        PipelineDirection Direction { get; }
        int Length { get; }
        void Add(IAnimation<TOwner> animation);
        IAnimation<TOwner> Get(int index);
        void Replace(int index, IAnimation<TOwner> animation);
        IAnimationPipelineController Once();
        IAnimationPipelineController PingPong(int times = 0);
        IAnimationPipelineController Loop(int times = 0);
	}
}
