﻿using System;
using System.Diagnostics;

namespace Doog
{
    /// <summary>
    /// Represents an animation.
    /// </summary>
    [DebuggerDisplay("{Name}: {State}")]
    public abstract class AnimationBase<TComponent, TValue> : ComponentBase, IAnimation<TComponent>, IUpdatable
        where TComponent : IComponent
    {
        public event EventHandler Started;
        public event EventHandler Ended;

        private float playStartedTime;
        private float pauseStartedTime;
        private IEasing easing;

        protected AnimationBase(TComponent owner, float duration)
            : base(owner.Context)
        {
            Owner = owner;
       
            this.Duration = duration;
            easing = Doog.Easing.Linear;
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
                easing = value ?? Doog.Easing.Linear;
            }
        }

        protected float Duration { get; private set; }

		protected TValue From { get; set; }
        protected TValue To { get; set; }

        public virtual void Play()
        {
            if (State == AnimationState.NotPlayed || State == AnimationState.Stopped)
            {
                Log.Debug("{0}: play", this);

                playStartedTime = Context.Time.SinceSceneStart;
                State = AnimationState.Playing;

                OnStarted(EventArgs.Empty);
            }
        }

        public void Pause()
        {
            if (State == AnimationState.Playing)
            {
                Log.Debug("{0}: pause", this);
                pauseStartedTime = Context.Time.SinceSceneStart;
                State = AnimationState.Paused;
            }
        }

        public void Resume()
        {
            if (State == AnimationState.Paused)
            {
                Log.Debug("{0}: resume", this);
                playStartedTime = Context.Time.SinceSceneStart - (pauseStartedTime - playStartedTime);
                State = AnimationState.Playing;
            }
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

        public virtual void Reverse()
        {
			var temp = From;
			From = To;
			To = temp;
        }
      
        public void Update()
        {
            if (State == AnimationState.Playing)
            {
                var elapsed = (Context.Time.SinceSceneStart - playStartedTime);

                if (elapsed < 0)
                {
                    return;
                }

                var time = elapsed / Duration;

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
            return "{0}<{1}>({2}..{3} in {4}s)".With(
                GetType().Name.TrimEnd('`', '1'), 
                Owner.GetType().Name, 
                From, 
                To, 
                Duration);
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
