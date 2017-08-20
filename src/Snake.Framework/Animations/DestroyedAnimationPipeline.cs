using System;
namespace Snake.Framework.Animations
{
    internal class DestroyedAnimationPipeline<TOwner> : AnimationPipeline<TOwner>
        where TOwner : IComponent
    {
        public DestroyedAnimationPipeline(TOwner owner)
        {
            Owner = owner;
        }

        public override AnimationState State
        {
            get
            {
                LogError("State");
                return AnimationState.Stopped;
            }
        }

        public override void Pause()
        {
			LogError("Pause");
        }


        public override void Resume()
        {
			LogError("Resume");
        }

        public override void Destroy()
        {
			LogError("Destroy");
        }

        protected override void Run()
        {
           LogError("Once/Loop/PingPong");
        }

        private void LogError(string method)
        {
            Owner.Context.LogSystem.Error("PIPELINE: cannot call '{0}' because this pipeline is destroyed", method);
        }
    }
}
