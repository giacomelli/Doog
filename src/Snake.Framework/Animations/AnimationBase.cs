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

        protected AnimationBase(TComponent owner, string name, float duration)
            : base(owner.Context)
        {
            Id = new AnimationId(owner, name);
            Owner = owner;
            Name = name;

            this.duration = duration;
            easing = Animations.Easing.Linear;
            owner.AddChild(this);
            State = AnimationState.NotPlayed;
            Direction = AnimationDirection.Any;
        }

        public AnimationId Id { get; private set; }
        public string Name { get; private set; }

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
            Log.Debug("{0}: play", Name);

            PlayCount++;
            playStartedTime = Context.Time.SinceSceneStart;
            State = AnimationState.Playing;

            OnStarted(EventArgs.Empty);
        }

        public void Pause()
        {
            Log.Debug("{0}: pause", Name);
            pauseStartedTime = Context.Time.SinceSceneStart;
            State = AnimationState.Paused;
        }

        public void Resume()
        {
            Log.Debug("{0}: resume", Name);
            playStartedTime = Context.Time.SinceSceneStart - (pauseStartedTime - playStartedTime);
            State = AnimationState.Playing;
        }

        public void Stop()
        {
            if (State != AnimationState.NotPlayed)
            {
                Log.Debug("{0}: stop", Name);
                State = AnimationState.Stopped;
            }
        }

        public virtual void Reset()
        {
            Log.Debug("{0}: reset", Name);
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
                    Stop();
                    OnEnded(EventArgs.Empty);
                }
            }
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
