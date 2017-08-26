namespace Snake.Framework.Animations
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
        }

        public void Pause()
        {
        }

        public void Resume()
        {
        }
    }
}
