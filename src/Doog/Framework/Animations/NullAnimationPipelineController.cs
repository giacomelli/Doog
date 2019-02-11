namespace Doog
{
    public class NullAnimationPipelineController : IAnimationPipelineController
    {
        public AnimationState State
        {
            get
            {
                return AnimationState.NotPlayed;
            }
        }

        public void Destroy()
        {
            // Null object pattern.
        }

        public void Pause()
        {
            // Null object pattern.
        }

        public void Resume()
        {
            // Null object pattern.
        }
    }
}
