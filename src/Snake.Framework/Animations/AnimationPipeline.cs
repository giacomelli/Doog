using System;
using System.Collections.Generic;

namespace Snake.Framework.Animations
{
    internal class AnimationPipeline<TOwner> : IAnimationPipeline<TOwner>
        where TOwner : IComponent
    {
        private int currentAnimationIndex;
        private PipelineKind kind = PipelineKind.Once;
        private int runTimes;
        private List<IAnimation<TOwner>> animations;
        private IAnimation<TOwner> currentAnimation;
        private IAnimationPipelineController controller;

        protected AnimationPipeline()
        {
            animations = new List<IAnimation<TOwner>>();
        }

        public TOwner Owner { get; protected set; }

        public virtual AnimationState State
        {
            get
            {
                return currentAnimation.State;
            }
        }

        public static AnimationPipeline<TOwner> Create(IAnimation<TOwner> firstAnimation)
        {
            var pipeline = new AnimationPipeline<TOwner>();
            pipeline.Add(firstAnimation);
            pipeline.Owner = firstAnimation.Owner;
            pipeline.currentAnimation = firstAnimation;

            return pipeline;
        }

        public void Add(IAnimation<TOwner> animation)
        {
            animations.Add(animation);
        }

        protected virtual void Run()
        {
            runTimes++;
            currentAnimationIndex = 0;
            PlayCurrent();
        }

        public IAnimationPipelineController Once()
        {
            return Run(PipelineKind.Once);
        }

        public IAnimationPipelineController Loop()
        {
           return Run(PipelineKind.Loop);
        }

        public IAnimationPipelineController PingPong()
        {
            return Run(PipelineKind.PingPong);
        }

        public virtual void Pause()
        {
            currentAnimation.Pause();
        }

        public virtual void Resume()
        {
            currentAnimation.Resume();
        }

        public virtual void Destroy()
        {
            if (animations.Count > 0)
            {
                currentAnimation.Pause();

                foreach (var a in animations)
                {
                    var component = a as IComponent;

                    if (component != null)
                    {
                        component.Enabled = false;
                        a.Owner.Context.RemoveComponent(component);
                    }
                }

                animations.Clear();
                controller.Destroy();
            }
        }

        private void PlayCurrent()
        {
            currentAnimation = animations[currentAnimationIndex];
            var current = currentAnimation;
            current.Ended -= CurrentAnimationEnded;
            current.Ended += CurrentAnimationEnded;

            Log("Playing animation {0}", current.Name);

            if (runTimes > 1)
            {
                switch (kind)
                {
                    case PipelineKind.Loop:
                        current.Reset();
                        break;

                    case PipelineKind.PingPong:
                        current.Reverse();
                        break;
                }
            }

            current.Play();
        }

        private void CurrentAnimationEnded(object sender, EventArgs e)
        {
            var animation = (IAnimation)sender;
            Log("Animation {0} ended.", animation.Name);

            animation.Ended -= CurrentAnimationEnded;

            if (currentAnimationIndex + 1 < animations.Count)
            {
                currentAnimationIndex++;
                PlayCurrent();
            }
            else
            {
                switch (kind)
                {
                    case PipelineKind.Loop:
                        Log("loop");
                        Run();
                        break;

                    case PipelineKind.PingPong:
                        Log("ping-pong");
                        animations.Reverse();
                        Run();
                        break;

                    case PipelineKind.Once:
                        Destroy();
                        Log("ended");
                        break;
                }
            }
        }

        private IAnimationPipelineController Run(PipelineKind kind)
        {
            if (controller == null)
            {
                this.kind = kind;
                Run();

                controller = new AnimationPipelineController<TOwner>(this);
                return controller;
            }
            else 
            {
                throw new InvalidOperationException("You can call Once/Loop/PingPong just once by pipeline.");    
            }
        }

        private void Log(string message, params object[] args)
        {
            Owner.Context.LogSystem.Debug("PIPELINE: {0}".With(message), args);
        }
    }
}
