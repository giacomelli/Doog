using System;
using System.Collections.Generic;
using System.Linq;
using Snake.Framework.Geometry;

namespace Snake.Framework.Animations
{
    public enum PipelineKind
    {
        Once = 0,
        Loop,
        PingPong
    }

    public class AnimationPipeline<TOwner>
        where TOwner : IComponent
    {
        private List<IAnimation<TOwner>> animations;
        private int currentAnimationIndex;
        private PipelineKind kind = PipelineKind.Once;
        private int runTimes;

        private AnimationPipeline()
        {
            animations = new List<IAnimation<TOwner>>();
        }

        public TOwner Owner { get; private set; }

        public static AnimationPipeline<TOwner> Create(IAnimation<TOwner> firstAnimation)
        {
            var pipeline = new AnimationPipeline<TOwner>();
            pipeline.Add(firstAnimation);
			pipeline.Owner = firstAnimation.Owner;

			return pipeline;
        }

        public void Add(IAnimation<TOwner> animation)
        {
            animations.Add(animation);
        }

        public void Join(AnimationPipeline<TOwner> other)
        {
            foreach (var a in other.animations)
            {
                Add(a);
            }
        }

        private void Run()
        {
            runTimes++;
            currentAnimationIndex = 0;
            PlayCurrent();
        }

        public void Once()
        {
            kind = PipelineKind.Once;
            Run();
        }

        private void PlayCurrent()
        {
            var current = animations[currentAnimationIndex];
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

        void CurrentAnimationEnded(object sender, EventArgs e)
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

                    default:
                        Log("ended");
                        break;
                }
            }
        }

        public void PingPong()
        {
            kind = PipelineKind.PingPong;
            Run();
        }

        public void Loop()
        {
            kind = PipelineKind.Loop;
            Run();
        }

        private void Log(string message, params object[] args)
        {
            Owner.Context.LogSystem.Debug("PIPELINE: {0}".With(message), args);
        }
    }
}
