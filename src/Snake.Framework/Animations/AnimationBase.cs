using System;
using System.Diagnostics;
using Snake.Framework.Behaviors;

namespace Snake.Framework.Animations
{
    /// <summary>
    /// Represents an animation.
    /// </summary>
    [DebuggerDisplay("{Name}: {State}")]
    public abstract class AnimationBase<TComponent> : ComponentBase, IAnimation<TComponent>, IUpdatable
        where TComponent : IComponent
    {
        public event EventHandler Started;
        public event EventHandler Ended;

        private float playStartedTime;
        private float pauseStartedTime;
        private float duration;
        private IEasing easing;

        protected AnimationBase(TComponent owner, float duration)
            : base(owner.Context)
        {
            Owner = owner;
       
            this.duration = duration;
            easing = Animations.Easing.Linear;
            owner.AddChild(this);
            State = AnimationState.NotPlayed;
            Direction = AnimationDirection.Any;
        }

        public TComponent Owner { get; private set; }

        public AnimationState State { get; private set; }
        public AnimationDirection Direction { get; set; }

        public IEasing Easing
        {
            get
            {
                return easing;
            }

            set
            {
                easing = value ?? Animations.Easing.Linear;
            }
        }

        protected int PlayCount { get; private set; }

        public virtual void Play()
        {
            Log.Debug("{0}: play", this);

            PlayCount++;
            playStartedTime = Context.Time.SinceSceneStart;
            State = AnimationState.Playing;

            OnStarted(EventArgs.Empty);
        }

        public void Pause()
        {
            Log.Debug("{0}: pause", this);
            pauseStartedTime = Context.Time.SinceSceneStart;
            State = AnimationState.Paused;
        }

        public void Resume()
        {
            Log.Debug("{0}: resume", this);
            playStartedTime = Context.Time.SinceSceneStart - (pauseStartedTime - playStartedTime);
            State = AnimationState.Playing;
        }

        public void Stop()
        {
            if (State != AnimationState.NotPlayed)
            {
                Log.Debug("{0}: stop", this);
                State = AnimationState.Stopped;
            }
        }

        public virtual void Reset()
        {
            Log.Debug("{0}: reset", this);
            playStartedTime = 0;
            State = AnimationState.NotPlayed;
        }

        public abstract void Reverse();
      
        public void Update()
        {
            if (State == AnimationState.Playing)
            {
                var elapsed = (Context.Time.SinceSceneStart - playStartedTime);

                if (elapsed < 0)
                {
                    return;
                }

                var time = elapsed / duration;

                if (time <= 1)
                {
                    UpdateValue(time);
                }
                else
                {
                    UpdateValue(1);
                    Stop();
                    OnEnded(EventArgs.Empty);
                }
            }
        }

        public override string ToString()
        {
            return GetType().Name;
        }

        protected override void OnEnabled()
        {
            Resume();
        }

        protected override void OnDisabled()
        {
            Pause();
        }

        protected virtual void OnStarted(EventArgs args)
        {
            if (Started != null)
            {
                Started(this, args);
            }
        }

        protected virtual void OnEnded(EventArgs args)
        {
            if (Ended != null)
            {
                Ended(this, args);
            }
        }

        protected abstract void UpdateValue(float time);
    }
}
