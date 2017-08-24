using System;
using System.Collections.Generic;

namespace Snake.Framework.Animations
{
    internal class AnimationPipeline<TOwner> : IAnimationPipeline<TOwner>
        where TOwner : IComponent
    {
        private int currentAnimationIndex;
        private int runTimes;
        private List<IAnimation<TOwner>> animations;
        private IAnimation<TOwner> currentAnimation;
        private IAnimationPipelineController controller;
        private int times;

        protected AnimationPipeline()
        {
            animations = new List<IAnimation<TOwner>>();
            Kind = PipelineKind.Once;
            Direction = PipelineDirection.Forward;
        }

        public TOwner Owner { get; protected set; }
        public PipelineKind Kind { get; private set; }
        public PipelineDirection Direction { get; private set; }
       
        public int Length 
        {
            get 
            {
                return animations.Count;
            }
        }

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

		public IAnimation<TOwner> Get(int index)
        {
            return animations[index];
        }

		public void Replace(int index, IAnimation<TOwner> animation)
        {
            animations[index] = animation;
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

        public IAnimationPipelineController Loop(int times = 0)
        {
            this.times = times;
            return Run(PipelineKind.Loop);
        }

        public IAnimationPipelineController PingPong(int times = 0)
        {
            this.times = times;
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
           
            // Looking for an animation that can be played in pipeline current direction.
            while(!CanPlay(currentAnimation))
            {
                currentAnimationIndex++;

                if(currentAnimationIndex >= animations.Count)
                {
                    CurrentAnimationEnded(currentAnimation, EventArgs.Empty);
                }
                else 
                {
                    currentAnimation = animations[currentAnimationIndex];
                }
            }

            currentAnimation.Ended -= CurrentAnimationEnded;
            currentAnimation.Ended += CurrentAnimationEnded;

            Log("Playing animation {0}", currentAnimation);

            if (runTimes > 1)
            {
                switch (Kind)
                {
                    case PipelineKind.Loop:
                        currentAnimation.Reset();
                        break;

                    case PipelineKind.PingPong:
                        currentAnimation.Reverse();
                        break;
                }
            }

            currentAnimation.Play();
        }

        private bool CanPlay(IAnimation<TOwner> animatino)
        {
            var animationDirection = animatino.Direction;

            return animationDirection == AnimationDirection.Any
                || (animationDirection == AnimationDirection.Forward && Direction == PipelineDirection.Forward)
                || (animationDirection == AnimationDirection.Backward && Direction == PipelineDirection.Backward);

		}

        private void CurrentAnimationEnded(object sender, EventArgs e)
        {
            var animation = (IAnimation)sender;
            Log("Animation {0} ended.", animation);

            animation.Ended -= CurrentAnimationEnded;

            if (currentAnimationIndex + 1 < animations.Count)
            {
                currentAnimationIndex++;
                PlayCurrent();
            }
            else
            {
                // Loop or PingPong with maxTimes.
                if (times > 0 && runTimes / 2 == times)
                {
                    Destroy();
                }
                else
                {
                    switch (Kind)
                    {
                        case PipelineKind.Loop:
                            Log("loop");
                            Run();
                            break;

                        case PipelineKind.PingPong:
                            Log("ping-pong");
                            animations.Reverse();
                            Direction = Direction == PipelineDirection.Forward
                                                   ? PipelineDirection.Backward
                                                   : PipelineDirection.Forward;

                            Run();
                            break;

                        case PipelineKind.Once:
                            Destroy();
                            Log("ended");
                            break;
                    }
                }
            }
        }

        private IAnimationPipelineController Run(PipelineKind kind)
        {
            if (controller == null)
            {
                this.Kind = kind;
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
