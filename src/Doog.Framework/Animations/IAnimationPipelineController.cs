namespace Doog.Framework
{
	public interface IAnimationPipelineController
	{
		AnimationState State { get; }
		void Pause();
		void Resume();
        void Destroy();
	}
}
